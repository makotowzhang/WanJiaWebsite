using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common
{
    public class FileHelper
    {
        public static bool CopyFile(string oldFile,string newFile,bool isOverWrite=true)
        {
            if (!File.Exists(oldFile))
            {
                return false;
            }
            string dir = Path.GetDirectoryName(newFile);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            try
            {
                File.Copy(oldFile, newFile, isOverWrite);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool CutFile(string oldFile, string newFile, bool isOverWrite = true)
        {
            if (CopyFile(oldFile, newFile, isOverWrite))
            {
                File.Delete(oldFile);
            }
            return false;
        }

        public static string GetNewFile(string dir, string oldFile)
        {
            string ext = Path.GetExtension(oldFile);
            if (!dir.EndsWith("/")&&!dir.EndsWith("\\"))
            {
                dir += "/";
            }
            return dir + Guid.NewGuid() + ext;
        }
    }
}
