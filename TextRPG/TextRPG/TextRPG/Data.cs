using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextRPG
{
    public class DataManager
    {
        private const string FilePath = "savedData.txt";

        public void SaveVariable(string key, string value)
        {
            string data = $"{key}:{value}\n";
            File.AppendAllText(FilePath, data);
        }

        public string LoadVariable(string key)
        {
            if (File.Exists(FilePath))
            {
                string[] lines = File.ReadAllLines(FilePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && parts[0] == key)
                    {
                        return parts[1];
                    }
                }
            }
            return string.Empty;
        }

        public void InitializeFile()
        {
            File.WriteAllText(FilePath, string.Empty);
        }
    }
}

