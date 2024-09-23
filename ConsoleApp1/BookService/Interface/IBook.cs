using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BookService.Interface
{
    public interface IBook
    {
        void WriteToFile(Book book, string filePath);
        Book ReadFromFile(string filePath);
    }
}
