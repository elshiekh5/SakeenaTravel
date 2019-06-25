using System;
using System.IO;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using System.Web.Configuration;
using System.Configuration;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for Encryption
    /// </summary>
    public class SMSEncryption
    {
        /// <summary>
        /// The Encryption Types
        /// </summary>
        /// <example>SMSEncryptiontypes.Des</example> 
        public enum SMSEncryptiontypes : int
        {
            Mine, FormAuth, Des, Rijndal
        }

        #region StaticMethods
        /// <summary>
        ///		This Method Encrypts Any Value To String With FormAuthWay
        /// </summary>
        /// <example>string Encryption.Encrypt("BlaBlaBla");</example> 
        public static string Encrypt(string strToEncrypt)
        {
            return Encrypt(strToEncrypt, SMSEncryptiontypes.Des);
        }

        /// <summary>
        /// This Method Decrypt Any String To Original String With FormAuthWay
        /// </summary>
        /// <example>string Encryption.Decrypt("BlaBlaBla");</example> 
        public static string Decrypt(string strToDecrypt)
        {
            return Decrypt(strToDecrypt, SMSEncryptiontypes.Des);
        }

        /// <summary>
        ///		This Method Encrypts Any Value To String With Specific Ways Described In The Type 
        /// </summary>
        /// <example>string Encryption.Encrypt("BlaBlaBla",Ecryptiontypes.FormAuth);</example> 
        public static string Encrypt(string strToEncrypt, SMSEncryptiontypes type)
        {
            string back = "";
            try
            {
                switch (type)
                {
                    case SMSEncryptiontypes.Mine:
                        MyEncryption my = new MyEncryption();
                        back = my.Encrypt(strToEncrypt);
                        break;
                    case SMSEncryptiontypes.FormAuth:
                        SMSEncryption en = new SMSEncryption();
                        back = en.EncryptFrmAuth(strToEncrypt);
                        break;
                    case SMSEncryptiontypes.Des:
                        SymmCrypto sy = new SymmCrypto(SymmCrypto.SymmProvEnum.DES);
                        back = sy.Encrypting(strToEncrypt, "AlHammadKey");
                        break;
                    case SMSEncryptiontypes.Rijndal:
                        SymmCrypto syy = new SymmCrypto(SymmCrypto.SymmProvEnum.Rijndael);
                        back = syy.Encrypting(strToEncrypt, "AlHammadKey");
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                back = "";
            }
            return back;
        }
        /// <summary>
        /// This Method Decrypts Any Value To Original String With Specific Ways Described In The Type 
        /// </summary>
        /// <example>string Encryption.Decrypt("BlaBlaBla",Ecryptiontypes.FormAuth);</example> 

        public static string Decrypt(string strToDecrypt, SMSEncryptiontypes type)
        {
            string back = "";
            try
            {
                switch (type)
                {
                    case SMSEncryptiontypes.Mine:
                        MyEncryption my = new MyEncryption();
                        back = my.Decrypt(strToDecrypt);
                        break;
                    case SMSEncryptiontypes.FormAuth:
                        SMSEncryption en = new SMSEncryption();
                        back = en.DecryptFrmAuth(strToDecrypt);
                        break;
                    case SMSEncryptiontypes.Des:
                        SymmCrypto sy = new SymmCrypto(SymmCrypto.SymmProvEnum.DES);
                        back = sy.Decrypting(strToDecrypt, "AlHammadKey");
                        break;
                    case SMSEncryptiontypes.Rijndal:
                        SymmCrypto syy = new SymmCrypto(SymmCrypto.SymmProvEnum.Rijndael);
                        back = syy.Decrypting(strToDecrypt, "AlHammadKey");
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                back = "";
            }
            return back;

        }
        /// <summary>
        /// This Method Hashs Any String To String With MD5
        /// </summary>
        /// <example>string Encryption.Hash("BlaBlaBla");</example> 
        public static string Hash(string strToHash)
        {
            return Hash(strToHash, "MD5");
        }
        /// <summary>
        /// This Method Hashs Any String To String With Ways Described In The Provider Parameter
        /// </summary>
        /// <example>string Encryption.Hash("BlaBlaBla" , "SHA1");</example> 
        /// <exception cref="> Fires Excpetion If Provider Is Not Found Or Return Empty String"
        public static string Hash(string strToHash, string provider)
        {
            SMSEncryption en = new SMSEncryption();
            return en.HashMD5(strToHash, provider);
        }

        /// <summary>
        /// This Method Conevrts Any Byte Array To String That Can Be Passed In The QueryString Seperated By The Separator Parameter
        /// </summary>
        /// <example>string Encryption.ByteArrayToUrlString(bytearray , '-');</example> 

        public static string ByteArrayToUrlString(byte[] by)
        {
            string ba = "";
            foreach (byte b in by)
            {
                if (b != 0)
                {
                    ba += b.ToString("000");
                }
            }
            ba = ba.Replace("00", "Z");
            ba = ba.Replace("0", "A");
            return ba;
        }
        /// <summary>
        /// This Method Conevrts Any String Passed In The QueryString  Seperated By The Separator ParameterTo Byte Array 
        /// </summary>
        /// <example>bytearray Encryption.UrlStringToByteArray("1-2-3" , '-');</example> 

        public static byte[] UrlStringToByteArray(string qstr)
        {
            string tempstr = qstr.Replace("Z", "00");
            tempstr = tempstr.Replace("A", "0");
            char[] chrs = new char[tempstr.Length];
            chrs = tempstr.ToCharArray();
            byte[] by = new byte[(int)(chrs.Length / 3)];
            int j = 0;
            for (int i = 0; i < chrs.Length; i += 3)
            {
                if (chrs[i].ToString() != "" && chrs[i + 1].ToString() != "" && chrs[i + 2].ToString() != "")
                    by[j] = Convert.ToByte(chrs[i].ToString() + chrs[i + 1].ToString() + chrs[i + 2].ToString());
                j++;
            }
            return by;
        }

        /// <summary>
        /// This Method Encrypts Any Section In the Web.Config File Then Saves The New Web.Config File
        /// </summary>
        /// <example>void Encryption.EncryptConnStr("ConnectionStrings");</example> 
        public static void EncryptConnStr(string sectionToEncrypt)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            ConfigurationSection section = config.Sections[sectionToEncrypt];
            //DataProtectionConfigurationProvider OR //RsaProtectedConfigurationProvider
            section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            config.Save();
        }

        /// <summary>
        /// This Method Decrypts Any Section In the Web.Config File Then Saves The New Web.Config File
        /// </summary>
        /// <example>void Encryption.DecryptConnStr("ConnectionStrings");</example> 
        public static void DecryptConnStr(string sectionToDecrypt)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
            ConfigurationSection section = config.Sections[sectionToDecrypt];
            section.SectionInformation.UnprotectSection();
            config.Save();
        }


        #endregion

        #region NonStaticMthods

        public string HashMD5(string strToHash, string provider)
        {
            try
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                System.Security.Cryptography.HashAlgorithm alg = System.Security.Cryptography.HashAlgorithm.Create(provider);
                return ByteArrayToUrlString(alg.ComputeHash(encoding.GetBytes(strToHash)));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string DecryptFrmAuth(string stringToDecrypt)
        {
            string hashedPwd = FormsAuthentication.Decrypt(stringToDecrypt).Name;
            return hashedPwd;
        }
        public string EncryptFrmAuth(string stringToEncrypt)
        {
            string hashedPwd = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(stringToEncrypt, true, 10));
            return hashedPwd;
        }

        public string EncryptDes(string val)
        {
            SymmCrypto sy = new SymmCrypto(SymmCrypto.SymmProvEnum.DES);
            return sy.Encrypting(val, "AlHammadKey");
        }

        public string DecryptDes(string val)
        {
            SymmCrypto sy = new SymmCrypto(SymmCrypto.SymmProvEnum.DES);
            return sy.Decrypting(val, "AlHammadKey");
        }

        public string EncryptRijndael(string val)
        {
            SymmCrypto sy = new SymmCrypto(SymmCrypto.SymmProvEnum.Rijndael);
            return sy.Encrypting(val, "AlHammadKey");
        }

        public string DecryptRijndael(string val)
        {
            SymmCrypto sy = new SymmCrypto(SymmCrypto.SymmProvEnum.DES);
            return sy.Decrypting(val, "AlHammadKey");
        }
        public string EncryptMine(string val)
        {
            MyEncryption my = new MyEncryption();
            return my.Encrypt(val);
        }
        public string DecryptMine(string val)
        {
            MyEncryption my = new MyEncryption();
            return my.Decrypt(val);
        }
        #endregion

        #region MyEcryption
        private class MyEncryption
        {
            private byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            private byte[] iv = { 65, 110, 68, 26, 69, 178, 200, 219 };

            public string Encrypt(string plainText)
            {
                UTF8Encoding utf8encoder = new UTF8Encoding();
                byte[] inputInBytes = utf8encoder.GetBytes(plainText);
                TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
                ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(this.key, this.iv);
                MemoryStream encryptedStream = new MemoryStream();
                CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);
                cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
                cryptStream.FlushFinalBlock();
                encryptedStream.Position = 0;
                byte[] result = new byte[encryptedStream.Length];
                encryptedStream.Read(result, 0, (int)encryptedStream.Length);
                cryptStream.Close();
                return ByteArrayToUrlString(result);//Convert.ToBase64String(result);
            }

            public string Decrypt(string inputStr)
            {
                UTF8Encoding utf8encoder = new UTF8Encoding();
                //byte[] inputInBytes = utf8encoder.GetBytes(inp);
                TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
                ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(this.key, this.iv);
                MemoryStream decryptedStream = new MemoryStream();
                CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
                byte[] inputInBytes = UrlStringToByteArray(inputStr);
                cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
                cryptStream.FlushFinalBlock();
                decryptedStream.Position = 0;
                byte[] result = new byte[decryptedStream.Length];
                decryptedStream.Read(result, 0, (int)decryptedStream.Length);
                cryptStream.Close();
                UTF8Encoding myutf = new UTF8Encoding();
                return myutf.GetString(result);
            }



        }


        #endregion

        #region SymmCrypto
        private class SymmCrypto
        {
            /// <remarks>
            /// Supported .Net intrinsic SymmetricAlgorithm classes.
            /// </remarks>
            public enum SymmProvEnum : int
            {
                DES, /*RC2,*/ Rijndael
            }

            private SymmetricAlgorithm mobjCryptoService;

            /// <remarks>
            /// Constructor for using an intrinsic .Net SymmetricAlgorithm class.
            /// </remarks>
            public SymmCrypto(SymmProvEnum NetSelected)
            {
                switch (NetSelected)
                {
                    case SymmProvEnum.DES:
                        mobjCryptoService = new DESCryptoServiceProvider();
                        break;
                    /*case SymmProvEnum.RC2:
                        mobjCryptoService = new RC2CryptoServiceProvider();
                        break;*/
                    case SymmProvEnum.Rijndael:
                        mobjCryptoService = new RijndaelManaged();
                        break;
                }
            }

            /// <remarks>
            /// Constructor for using a customized SymmetricAlgorithm class.
            /// </remarks>
            public SymmCrypto(SymmetricAlgorithm ServiceProvider)
            {
                mobjCryptoService = ServiceProvider;
            }

            /// <remarks>
            /// Depending on the legal key size limitations of a specific CryptoService provider
            /// and length of the private key provided, padding the secret key with space character
            /// to meet the legal size of the algorithm.
            /// </remarks>
            private byte[] GetLegalKey(string Key)
            {
                string sTemp = Key;
                if (mobjCryptoService.LegalKeySizes.Length > 0)
                {
                    int moreSize = mobjCryptoService.LegalKeySizes[0].MinSize;
                    // key sizes are in bits
                    if (sTemp.Length * 8 > mobjCryptoService.LegalKeySizes[0].MaxSize)
                        // get the left of the key up to the max size allowed
                        sTemp = sTemp.Substring(0, mobjCryptoService.LegalKeySizes[0].MaxSize / 8);
                    else if (sTemp.Length * 8 < moreSize)
                        if (mobjCryptoService.LegalKeySizes[0].SkipSize == 0)
                            // simply pad the key with spaces up to the min size allowed
                            sTemp = sTemp.PadRight(moreSize / 8, ' ');
                        else
                        {
                            while (sTemp.Length * 8 > moreSize)
                                moreSize += mobjCryptoService.LegalKeySizes[0].SkipSize;

                            sTemp = sTemp.PadRight(moreSize / 8, ' ');
                        }
                }

                // convert the secret key to byte array
                return ASCIIEncoding.ASCII.GetBytes(sTemp);
            }

            public string Encrypting(string Source, string Key)
            {
                byte[] bytIn = System.Text.ASCIIEncoding.ASCII.GetBytes(System.Web.HttpUtility.UrlEncode(Source));

                // create a MemoryStream so that the process can be done without I/O files
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                byte[] bytKey = GetLegalKey(Key);

                // set the private key
                mobjCryptoService.Key = bytKey;
                mobjCryptoService.IV = bytKey;

                // create an Encryptor from the Provider Service instance
                ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();

                // create Crypto Stream that transforms a stream using the encryption
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);

                // write out encrypted content into MemoryStream
                cs.Write(bytIn, 0, bytIn.Length);
                cs.FlushFinalBlock();

                // get the output and trim the '\0' bytes
                byte[] bytOut = ms.GetBuffer();
                int i = 0;
                for (i = 0; i < bytOut.Length; i++)
                    if (bytOut[i] == 0)
                        break;

                // convert into Base64 so that the result can be used in xml
                return ByteArrayToUrlString(bytOut);//System.Convert.ToBase64String(bytOut, 0, i);
            }

            public string Decrypting(string Source, string Key)
            {
                // convert from Base64 to binary
                byte[] bytIn = UrlStringToByteArray(Source);//System.Convert.FromBase64String(Source);
                // create a MemoryStream with the input
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);

                byte[] bytKey = GetLegalKey(Key);

                // set the private key
                mobjCryptoService.Key = bytKey;
                mobjCryptoService.IV = bytKey;

                // create a Decryptor from the Provider Service instance
                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();

                // create Crypto Stream that transforms a stream using the decryption
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

                // read out the result from the Crypto Stream
                System.IO.StreamReader sr = new System.IO.StreamReader(cs);
                string sEncoded = sr.ReadToEnd();
                return System.Web.HttpUtility.UrlDecode(sEncoded);
            }
        }
        #endregion

    }
}