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
        // Write the book details to file
        public void WriteToFile(Book book, string filePath)
        {
            // Book Validation
            BookValidation(book);

            // Validate the filePath
            FilePathValidation(filePath);

            File.WriteAllText(filePath, book.ToString());
        }

        // Read the book details from the file
        public Book ReadFromFile(string filePath)
        {
            // FilePath Validate
            FilePathValidation(filePath);

            var lines = File.ReadAllLines(filePath);

            ReadFromFileValdation(lines);

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

        private static void ReadFromFileValdation(string[] lines)
        {
            if (lines == null || lines.Length == 0)
            {
                throw new ArgumentException("File content cannot be null or empty.");
            }

            if (lines.Length < 6)
            {
                throw new InvalidOperationException("The file format is incorrect or incomplete. Please ensure the file contains all the required book information.");
            }
        }

        private static void FilePathValidation(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or whitespace.", nameof(filePath));
            }

            if (filePath.Length < 6)
            {
                throw new InvalidOperationException("The file format is incorrect or incomplete. Please ensure the file contains all the required book information.");
            }
        }

        public static void BookValidation(Book book)
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
    }
}
