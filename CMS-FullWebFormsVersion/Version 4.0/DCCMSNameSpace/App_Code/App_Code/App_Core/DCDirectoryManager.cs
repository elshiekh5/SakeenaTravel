using System;
using System.Collections.Generic;

using System.Web;
using System.IO;

/// <summary>
/// Summary description for DCDirectoryManager
/// </summary>
public class DcDirectoryManager
{

    public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        if (source.FullName.ToLower() == target.FullName.ToLower())
        {
            return;
        }

        // Check if the target directory exists, if not, create it.
        if (Directory.Exists(target.FullName) == false)
        {
            Directory.CreateDirectory(target.FullName);
        }

        // Copy each file into it's new directory.
        foreach (FileInfo fi in source.GetFiles())
        {
            //Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
            fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
        }

        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir =
                target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
        }
    }

    public static void GetDirectorySize(DirectoryInfo dir, ref long folderSize)
    {
        // 1
        // Get array of all file names.
        FileInfo[] dirFiles = dir.GetFiles();// Directory.GetFiles(p, "*.*");

        // 2
        // Calculate total bytes of all files in a loop.
        foreach (FileInfo file in dirFiles)
        {
            folderSize += file.Length;
        }
        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            GetDirectorySize(subDir, ref folderSize);
        }
    }
    public static string CalculateSizeToRead(long _Size)
    { 
        string CaulatedSizeForReading = "0 Bytes";
        double finalResult = 0.0;
        double Size=_Size;
        if (Size > 0)
        {
            long KB = 1024;
            long MB = KB * 1024;
            long GB = MB * 1024;
            long TB = GB * 1024;
            if (Size >= TB)
            {
                finalResult = (Size / TB);
                finalResult = Math.Round(finalResult, 3);
                CaulatedSizeForReading = finalResult + " TB";
            }
            else if (Size >= GB)
            {
                finalResult = (Size / GB);
                finalResult = Math.Round(finalResult, 3);
                CaulatedSizeForReading = finalResult + " GB";
            }
            else if (Size >= MB)
            {
                finalResult = (Size / MB);
                finalResult = Math.Round(finalResult, 3);
                CaulatedSizeForReading = finalResult + " MB";
            }
            else if (Size >= KB)
            {
                finalResult = (Size / KB);
                finalResult = Math.Round(finalResult, 2);
                CaulatedSizeForReading = finalResult + " KB";
            }
            else
            {
                finalResult = (Size);
                CaulatedSizeForReading = finalResult + " Bytes";
            }
        }
        return CaulatedSizeForReading;

    }

    public static void DeletDirectory(DirectoryInfo dir)
    {

        // Check if the target directory exists, if not, create it.
        if (!Directory.Exists(dir.FullName))
        {
            return;
        }

        // Copy each file into it's new directory.
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }

        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in dir.GetDirectories())
        {
            DeletDirectory(diSourceSubDir);
        }
        dir.Delete();
    }
}