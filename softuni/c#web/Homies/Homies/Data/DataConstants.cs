using System.Runtime.CompilerServices;

namespace Homies.Data
{
    public static class DataConstants
    {
        public const int EventNameMinLength = 5;
        public const int EventNameMaxLength = 20;

        public const int EventDescriptionMinLength = 15;
        public const int EventDescriptionMaxLength = 150;

        public const string DateFormat = "yyyy-MM-dd H:mm";

        public const int TypeNameMinLength = 5;
        public const int TypeNameMaxLength = 15;

        public const string RequireErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";
    }
}
