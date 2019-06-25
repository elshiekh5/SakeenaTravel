using DC;
using System;
namespace DCCMSNameSpace
{
    public class DCValidationManager
    {
        public static void SetClientValidationFunction(DCCustomValidator cv, Languages lang)
        {
            cv.ClientValidationFunction = "Check" + lang.ToString() + "Validation";
        }
    }
}