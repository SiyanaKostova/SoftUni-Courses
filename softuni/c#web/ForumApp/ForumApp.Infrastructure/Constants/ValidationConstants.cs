using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Constants
{
    /// <summary>
    /// Validation Constants
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Maximal Post Title Length
        /// </summary>
        public const int TitleMaxLength = 50;
        /// <summary>
        /// Minimal Post Title Length
        /// </summary>
        public const int TitleMinLength = 10;
        /// <summary>
        /// Maximal Content Title Length
        /// </summary>
        public const int ContentMaxLength = 1500;
        /// <summary>
        /// Minimal Post Title Length
        /// </summary>
        public const int ContentMinLength = 30;
        /// <summary>
        /// Required Error Message
        /// </summary>
        public const string RequiredErrorMessage = "The {0} field is required";
        /// <summary>
        /// Length Error Message
        /// </summary>
        public const string StringLengthErrorMessage = "The {0} field must be between {2} and {1} characters long";
    }
}
