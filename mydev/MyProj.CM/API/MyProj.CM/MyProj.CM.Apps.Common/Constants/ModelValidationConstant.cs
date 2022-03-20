using System;
using System.Collections.Generic;
using System.Text;

namespace MyProj.CM.Apps.Common.Constants
{
    public static class ModelValidationConstant
    {
        public const string InvalidCharacters = "^[^<>/\\\\`&]+$";
        public const string InvalidCharacterErrorMessage = "Invalid Characters";
    }
}
