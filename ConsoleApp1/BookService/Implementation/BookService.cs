using ConsoleApp1.BookService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.BookService.Implementation
{
    public class BookService : IBook
    {
        // Book Validation
        public void ValidateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Title cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(book.Author))
                throw new ArgumentException("Author cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(book.Genre))
                throw new ArgumentException("Genre cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(book.Publisher))
                throw new ArgumentException("Publisher cannot be null or empty.");

            if (book.Pages <= 0)
                throw new ArgumentException("Pages must be a positive number.");

            if (!Regex.IsMatch(book.ISBN, @"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$"))
                throw new ArgumentException("Invalid ISBN format.");
        }

        // Write the book details to file
        public void WriteToFile(Book book, string filePath)
        {
            ValidateBook(book);
            File.WriteAllText(filePath, book.ToString());
        }

        // Read the book details from the file
        public Book ReadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length < 6)
            {
                throw new InvalidOperationException("The file format is incorrect or incomplete. Please ensure the file contains all the required book information.");
            }
            return new Book
            {
                Title = lines[0],
                Author = lines[1],
                Pages = int.Parse(lines[2]),
                Genre = lines[3],
                Publisher = lines[4],
                ISBN = lines[5]
            };
        }
    }
}
