using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjectRepository;
        private StudentRepository studentRepository;
        private UniversityRepository universityRepository;

        public Controller()
        {
            subjectRepository = new SubjectRepository();
            studentRepository = new StudentRepository();
            universityRepository = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            if (studentRepository.Models.Any(s=> s.FirstName == firstName && s.LastName == lastName))
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            IStudent student = new Student(0, firstName, lastName);
            studentRepository.AddModel(student);
            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, studentRepository.GetType().Name);
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(EconomicalSubject))
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            if (subjectRepository.Models.FirstOrDefault(s => s.Name == subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }

            ISubject subject;

            if (subjectType == nameof(TechnicalSubject))
            {
                subject = new TechnicalSubject(0, subjectName);
            }
            else if (subjectType == nameof(EconomicalSubject))
            {
                subject = new EconomicalSubject(0, subjectName);
            }
            else
            {
                subject = new HumanitySubject(0, subjectName);
            }

            subjectRepository.AddModel(subject);
            return String.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, subjectRepository.GetType().Name);
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universityRepository.Models.Any(u=> u.Name == universityName))
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }

            List<int> subjectIds = new List<int>();
            foreach (var subject in requiredSubjects)
            {
                subjectIds.Add(subjectRepository.FindByName(subject).Id);
            }
            IUniversity university = new University(0, universityName, category, capacity, subjectIds);
            universityRepository.AddModel(university);
            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, universityRepository.GetType().Name);
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] splitted = studentName.Split(' ');
            string firstName = splitted[0];
            string lastName = splitted[1];

            IStudent student = studentRepository.Models.FirstOrDefault(s=> s.FirstName == firstName && s.LastName == lastName);
            if (student == null)
            {
                return String.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            IUniversity university = universityRepository.FindByName(universityName);
            if (university == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            bool isCovered = true;

            foreach (var exam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(exam))
                {
                    isCovered = false;
                    return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (student.University == university)
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            student.JoinUniversity(university);
            return String.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = studentRepository.Models.FirstOrDefault(s => s.Id == studentId);
            ISubject subject = subjectRepository.Models.FirstOrDefault(s => s.Id == subjectId);
            if (student == null)
            {
                return String.Format(OutputMessages.InvalidStudentId);
            }
            if (subject == null)
            {
                return String.Format(OutputMessages.InvalidSubjectId);
            }
            if (student.CoveredExams.Any(s => s == subjectId))
            {
                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, student.FirstName, student.LastName, subject.Name);
            }
            student.CoverExam(subject);
            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universityRepository.FindById(universityId);

            int countOfStudents = 0;
            foreach (var student in studentRepository.Models)
            {
                if (student.University == university)
                {
                    countOfStudents++;
                }
            }
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {countOfStudents}");
            sb.AppendLine($"University vacancy: {university.Capacity - countOfStudents}");

            return sb.ToString().Trim();
        }
    }
}
