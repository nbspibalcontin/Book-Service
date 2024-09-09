
using ConsoleApp1.BookService;
using ConsoleApp1.BookService.Implementation;
using ConsoleApp1.BookService.Interface;
using ConsoleApp1.EmailService.Implementation;
using ConsoleApp1.EmailService.Interface;
using ConsoleApp1.StudentService;
using ConsoleApp1.StudentService.Implementation;
using ConsoleApp1.StudentService.Interface;

public class Program
{
    // Initializes the Services
    private static readonly IBook bookService = new BookService();
    private static readonly IEmail emailService = new EmailExtractorService();
    private static readonly IStudent studentService = new StudentService();

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

        Console.WriteLine();

        // Email Extractor Service
        string text = "Contact us at support@example.com or sales@example.com.";
        var emails = emailService.ExtractEmails(text);

        Console.WriteLine(string.Join(", ", emails));

        Console.WriteLine();

        // Student Service

        // Add Student Details
        studentService.AddStudent("A001", new Student("Alice", 85));
        studentService.AddStudent("B002", new Student("Bob", 92));

        // Display all student details
        studentService.DisplayAllStudents();
    }
}