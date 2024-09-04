using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BookService
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return $"{Title}\n{Author}\n{Pages}\n{Genre}\n{Publisher}\n{ISBN}";
        }
    }
}
