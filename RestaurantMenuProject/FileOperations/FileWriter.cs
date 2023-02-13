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
        private string filePath;

        public string FilePath
        {
            get => filePath;
            set { if (value != null) filePath = value; }
        }

        public FileWriter()
        {
            filePath = @"..\\..\\..\\Files\\AddedProducts.txt";
        }

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public void WriteExpression(object obj, string filePath)
        {
            throw new NotImplementedException();
        }
    }
}

