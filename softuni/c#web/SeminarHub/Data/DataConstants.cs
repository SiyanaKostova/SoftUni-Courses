namespace SeminarHub.Data
{
    public static class DataConstants
    {
        public static class Seminar
        {
            public const int TopicMinLength = 3;
            public const int TopicMaxLength = 100;
            public const int LecturerMinLength = 5;
            public const int LecturerMaxLength = 60;
            public const int DetailsMinLength = 10;
            public const int DetailsMaxLength = 500;
            public const int DurationMin = 30;
            public const int DurationMax = 180;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public const string DateFormat = "dd/MM/yyyy HH:mm";

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
        public const string IntLengthErrorMessage = "The field {0} must be between {1} and {2} characters long";
    }
}
