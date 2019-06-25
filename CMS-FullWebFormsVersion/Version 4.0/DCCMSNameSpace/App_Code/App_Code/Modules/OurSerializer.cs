using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for OurBinary
    /// </summary>
    public class OurSerializer
    {
        //-----------------------------------------------------------
        public static string Serialize(List<string> stringsList)
        {

            int noOfStrings = stringsList.Count;
            string allStrings = "";
            string MetaTag = noOfStrings + "#";
            int startChar = 0;
            int endChar = -1;
            int stringLength = 0;
            for (int i = 0; i < noOfStrings; i++)
            {
                stringLength = stringsList[i].Length;
                if (stringLength > 0)
                {
                    startChar = endChar + 1;
                    endChar = startChar + stringLength - 1;
                    MetaTag += startChar + ":" + stringLength + ",";
                    allStrings += stringsList[i];
                }
                else
                {
                    MetaTag += -1 + ":" + -1 + ",";

                }
            }
            allStrings = MetaTag + ";" + allStrings;
            return allStrings;

        }
        //----------------------------------------------------------
        public static List<string> Deserialize(string allStrings)
        {
            try
            {

                //------------------------------------
                //if happend return empty 
                //------------------------------------
                if (string.IsNullOrEmpty(allStrings))
                    return new List<string>();
                //------------------------------------

                string MetaTag = "";
                string ClearStrings = "";
                int metaTagIndex = allStrings.IndexOf(';');
                //------------------------------------
                //if happend return empty 
                //------------------------------------
                if (metaTagIndex < 0)
                    return new List<string>();
                //------------------------------------

                MetaTag = allStrings.Substring(0, metaTagIndex + 1);
                ClearStrings = allStrings.Substring(metaTagIndex + 1);
                int hashIndex = allStrings.IndexOf('#');
                int noOfStrings = Convert.ToInt32(MetaTag.Substring(0, hashIndex));
                //remove noOfStrings + # from meta
                string clearMeta = MetaTag.Remove(0, hashIndex + 1);
                //remove ; and last ,
                clearMeta = clearMeta.Remove(clearMeta.Length - 2, 2);
                string[] stringsMeta = clearMeta.Split(new char[] { ',' });
                int x;
                int startChar;
                //int endChar;
                int stringLength = 0;
                List<string> stringsList = new List<string>();
                string item;
                foreach (string smeta in stringsMeta)
                {
                    x = smeta.IndexOf(':');
                    startChar = Convert.ToInt32(smeta.Substring(0, x));
                    stringLength = Convert.ToInt32(smeta.Substring(x + 1));
                    if (startChar > -1)
                    {
                        item = ClearStrings.Substring(startChar, stringLength);
                    }
                    else
                    {
                        item = "";
                    }
                    stringsList.Add(item);

                }
                return stringsList;
            }
            catch
            {
                //------------------------------------
                //if happend return empty 
                //------------------------------------
                return new List<string>();
                //------------------------------------
            }

        }
        //----------------------------------------------------------
    }
}
