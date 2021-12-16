using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace FileConverter
{
    class Utility
    {
        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            if (filename == null || string.IsNullOrWhiteSpace(filename)) return Encoding.Default;
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        public static string GetLocalPath()
        {
            string pathWithEnv = string.Empty;
            string localPath = string.Empty;

            var driveInfo = DriveInfo.GetDrives();
            foreach (var drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    if (drive.Name == @"D:\")
                    {
                        pathWithEnv = @"D:\" + Environment.UserName + @"\Desktop\Wordpads\id.txt";
                    }
                    else
                    {
                        pathWithEnv = @"%USERPROFILE%\Desktop\Wordpads\id.txt";
                    }
                }

                localPath = Environment.ExpandEnvironmentVariables(pathWithEnv);
                if (File.Exists(localPath)) break;
            }
            
            return localPath;
        }

        public static string GetExternalPath()
        {
            string externalPath = "";
            var driveInfo = DriveInfo.GetDrives();
            foreach (var drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Removable &&
                    File.Exists(drive.Name + @"Wordpads\id.txt"))
                {
                    externalPath = drive.Name + @"Wordpads\id.txt";
                    break;
                }
            }
            return externalPath;
        }
    }
    
}
