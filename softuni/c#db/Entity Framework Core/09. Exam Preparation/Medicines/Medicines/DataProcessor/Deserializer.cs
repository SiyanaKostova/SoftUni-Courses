namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Medicines.Helpers;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var patientsDto = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            List<Patient> patientsList = new List<Patient>();

            var uniqueMedicineIds = context.Medicines.Select(m => m.Id).ToArray();

            foreach (ImportPatientDto patientDto in patientsDto)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (patientDto.Gender != 0 && patientDto.Gender != 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (patientDto.AgeGroup != 0 && patientDto.AgeGroup != 1 && patientDto.AgeGroup != 2) 
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (patientDto.FullName.Length < 5 || patientDto.FullName.Length > 100)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender,
                };

                foreach (var medicineId in patientDto.MedicinesIds)
                {
                    if (patient.PatientsMedicines.Any(x => x.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!uniqueMedicineIds.Contains(medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine pm = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };

                    patient.PatientsMedicines.Add(pm);
                }

                patientsList.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count()));
            }

            context.AddRange(patientsList);
            context.SaveChanges();

            return sb.ToString();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var pharmaciesDto = XmlSerializationHelper.Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            StringBuilder sb = new StringBuilder();

            List<Pharmacy> pharmaciesList = new List<Pharmacy>();

            foreach (var pharmacyDto in pharmaciesDto.Distinct())
            {
                if (!IsValid(pharmacyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!IsValid(pharmacyDto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(pharmacyDto.NonStop))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(pharmacyDto.PhoneNumber))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (pharmacyDto.NonStop != "true" && pharmacyDto.NonStop != "false")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    PhoneNumber = pharmacyDto.PhoneNumber,
                    IsNonStop = pharmacyDto.NonStop.ToLower() == "true"
                };

                foreach (var medicine in pharmacyDto.Medicines.Distinct())
                {
                    if (pharmacy.Medicines.Any(m => m.Name == medicine.Name && m.Producer == medicine.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!IsValid(medicine))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    DateTime prDate = DateTime.ParseExact(medicine.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime exDate = DateTime.ParseExact(medicine.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

                    if (prDate == exDate || prDate > exDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (medicine.Producer is null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!IsValid(medicine.Category))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (medicine.Price < 0.01m || medicine.Price > 1000)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (medicine.Category < 0 || medicine.Category > 4)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    pharmacy.Medicines.Add(new Medicine()
                    {
                        Name = medicine.Name,
                        Price = medicine.Price,
                        ProductionDate = DateTime.ParseExact(medicine.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        ExpiryDate = DateTime.ParseExact(medicine.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Producer = medicine.Producer,
                        Category = (Category)medicine.Category
                    });
                }

                pharmaciesList.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count()));
            }

            context.Pharmacies.AddRange(pharmaciesList);
            context.SaveChanges();

            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
