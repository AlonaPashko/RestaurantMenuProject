using RestaurantMenuProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenuProject.FileOperations
{
    internal class FileWriter : IExpressionWriter
    {
      
        public string FilePath { get; set; }

        public FileWriter() : this (@"..\\..\\..\\Files\\Result.txt") { }

        public FileWriter(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            FilePath = filePath;
        }

        public void WriteExpression(object obj)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.Write(obj.ToString());
            }
        }
    }
}

