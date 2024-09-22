
using ConsoleApp1.BookService;
using ConsoleApp1.BookService.Implementation;
using ConsoleApp1.BookService.Interface;

public class Program
{
    // Initializes the Services
    private static readonly IBook bookService = new BookService();

    public static void Main(string[] args)
    {       
        // Book Details
        Book book = new Book
        {
            Title = "The Great Gatsby",
            Author = "F. Scott Fitzgerald",
            Pages = 180,
            Genre = "Fiction",
            Publisher = "Scribner",
            ISBN = "978-3-16-148410-0"
        };

        // Book Validation
        bookService.ValidateBook(book);

        string bookFilePath = "book.txt";

        // Write book details to file
        bookService.WriteToFile(book, bookFilePath);

        // Read book details from book.txt file
        Book loadedBook = bookService.ReadFromFile(bookFilePath);

        Console.WriteLine(loadedBook);
    }
}