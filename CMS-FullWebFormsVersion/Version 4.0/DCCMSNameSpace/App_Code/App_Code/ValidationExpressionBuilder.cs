using System;
using System.Collections.Generic;

using System.Web;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ValidationExpressionBuilder
    /// </summary>
    public class ValidationExpressionBuilder
    {
        //-------------------------------------------------------------
        public static string CreateExpression(string extensions)
        {
            if (!string.IsNullOrEmpty(extensions))
            {
                string[] extensionsArray = extensions.Split(new char[] { ',' });
                int dotIndex;
                for (int i = 0; i < extensionsArray.Length; i++)
                {
                    dotIndex = extensionsArray[i].IndexOf('.');
                    if (dotIndex > -1)
                        extensionsArray[i] = extensionsArray[i].Remove(0, 1);

                }
                return @CreateExpressionForAllExtentions(extensionsArray);
            }
            else
            {
                return "";
            }

        }
        //-------------------------------------------------------------
        #region Create Validation Expression
        private static string CreateExpressionForOneExtention(string ext)
        {
            //(.*\.([Mm][Pp][3])$)
            string vx = "(.*\\.(";
            string Lvx = ext.ToLower();
            string Uvx = ext.ToUpper();
            int Lenvx = ext.Length;
            for (int i = 0; i < Lenvx; i++)
            {
                vx += "[" + Uvx.Substring(i, 1) + Lvx.Substring(i, 1) + "]";
            }
            vx += ")$)";
            return vx;
        }
        //EX. rgxControl.ValidationExpression = @VldExpression(new string[] { "mp3","ra","wav",.....});

        private static string CreateExpressionForAllExtentions(string[] extensions)
        {
            string vx = "";
            foreach (string item in extensions)
            {
                vx += CreateExpressionForOneExtention(item) + "|";
            }
            return vx.Substring(0, vx.Length - 1);
        }
        #endregion
    }
}