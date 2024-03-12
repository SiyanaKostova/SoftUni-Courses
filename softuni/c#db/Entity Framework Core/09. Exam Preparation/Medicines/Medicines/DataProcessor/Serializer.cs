namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {

            DateTime newDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var patients = context.Patients
            .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > newDate))
           .Select(p => new ExportPatientDto
           {
               Name = p.FullName,
               AgeGroup = p.AgeGroup.ToString(),
               Gender = p.Gender.ToString().ToLower(),
               Medicines = p.PatientsMedicines
                   .Where(pm => pm.Medicine.ProductionDate > newDate)
                   .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                   .ThenBy(pm => pm.Medicine.Price)
                   .Select(pm => new ExportMedicine2Dto
                   {
                       Name = pm.Medicine.Name,
                       Price = pm.Medicine.Price.ToString("F2"),
                       Category = pm.Medicine.Category.ToString().ToLower(),
                       Producer = pm.Medicine.Producer,
                       BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                   })
                   .ToArray()
           })
           .OrderByDescending(p => p.Medicines.Length)
           .ThenBy(p => p.Name)
           .ToArray();

            return XmlSerializationHelper.Serialize(patients, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
            .Where(m => (int)m.Category == medicineCategory && m.Pharmacy.IsNonStop)
            .OrderBy(m => m.Price)
            .ThenBy(m => m.Name)
            .Select(m => new ExportMedicineDto
            {
                Name = m.Name,
                Price = m.Price.ToString("F2", CultureInfo.InvariantCulture),
                Pharmacy = new ExportPharmacyDto
                {
                    Name = m.Pharmacy.Name,
                    PhoneNumber = m.Pharmacy.PhoneNumber
                }
            })
            .ToList();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
    }
}