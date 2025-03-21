using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DVLD_UI.GlobalClasses
{
    public class clsUtil
    {

        public static string GenerateGUID()
        {
            return Guid.NewGuid().ToString();
        }

        public static  bool CreateFolderIfDoesNotExist(string FolderPath)
        {
        
            if(!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                } catch (Exception ex){

                    MessageBox.Show($"Couldn't create folder {ex.ToString()}");
                    return false;
                }
            }
            return true;

        }

        public static string ReplaceFileNameWithGUID(string FileName)
        {
            FileInfo fi=new FileInfo(FileName);
            string extn= fi.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesPath(ref string sourceFile)
        {
            string DestinationFolder = @"D:\Courses\Course19\DVLD\Solution_Pics\";

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
                return false;

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);

            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch
            {
                MessageBox.Show("Couldn't Copy th file");
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

    }
}
