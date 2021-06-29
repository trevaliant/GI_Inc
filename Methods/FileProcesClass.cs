using System;
using System.IO;

namespace GI_Inc
{
    public class FileProcesClass
    {
        public bool FileExists(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new
                    ArgumentNullException("fileName");
            }
            return File.Exists(fileName);

        }
    }
}
