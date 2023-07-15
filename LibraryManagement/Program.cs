using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static List<Book> books = new List<Book>();
        static List<Author> authors = new List<Author>();
        static List<Borrower> borrowers = new List<Borrower>();
        static List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. Add Author");
                Console.WriteLine("5. Update Author");
                Console.WriteLine("6. Delete Author");
                Console.WriteLine("7. Add Borrower");
                Console.WriteLine("8. Update Borrower");
                Console.WriteLine("9. Delete Borrower");
                Console.WriteLine("10. Register Book to Borrower");
                Console.WriteLine("11. Display All Books");
                Console.WriteLine("12. Display All Authors");
                Console.WriteLine("13. Display All Borrowers");
                Console.WriteLine("14. Search Books");
                Console.WriteLine("15. Filter Books by Status");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice:");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        UpdateBook();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        AddAuthor();
                        break;
                    case 5:
                        UpdateAuthor();
                        break;
                    case 6:
                        DeleteAuthor();
                        break;
                    case 7:
                        AddBorrower();
                        break;
                    case 8:
                        UpdateBorrower();
                        break;
                    case 9:
                        DeleteBorrower();
                        break;
                    case 10:
                        RegisterBookToBorrower();
                        break;
                    case 11:
                        DisplayAllBooks();
                        break;
                    case 12:
                        DisplayAllAuthors();
                        break;
                    case 13:
                        DisplayAllBorrowers();
                        break;
                    case 14:
                        SearchBooks();
                        break;
                    case 15:
                        FilterBooksByStatus();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.WriteLine("Enter the book title:");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the author's first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the author's last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the publication year:");
            int publicationYear = Convert.ToInt32(Console.ReadLine());

            Author author = FindOrCreateAuthor(firstName, lastName);

            Book book = new Book(title, author, publicationYear);
            books.Add(book);

            Console.WriteLine("Book added successfully.");
        }

        static void UpdateBook()
        {
            Console.WriteLine("Enter the book title to update:");
            string title = Console.ReadLine();

            Book book = books.FirstOrDefault(b => b.Title == title);

            if (book != null)
            {
                Console.WriteLine("Enter the new publication year:");
                int publicationYear = Convert.ToInt32(Console.ReadLine());

                book.PublicationYear = publicationYear;

                Console.WriteLine("Book updated successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void DeleteBook()
        {
            Console.WriteLine("Enter the book title to delete:");
            string title = Console.ReadLine();

            Book book = books.FirstOrDefault(b => b.Title == title);

            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void AddAuthor()
        {
            Console.WriteLine("Enter the author's first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the author's last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the author's date of birth (YYYY-MM-DD):");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Author author = new Author(firstName, lastName, dateOfBirth);
            authors.Add(author);

            Console.WriteLine("Author added successfully.");
        }

        static void UpdateAuthor()
        {
            Console.WriteLine("Enter the author's first name to update:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the author's last name to update:");
            string lastName = Console.ReadLine();

            Author author = authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);

            if (author != null)
            {
                Console.WriteLine("Enter the new date of birth (YYYY-MM-DD):");
                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                author.DateOfBirth = dateOfBirth;

                Console.WriteLine("Author updated successfully.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        static void DeleteAuthor()
        {
            Console.WriteLine("Enter the author's first name to delete:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the author's last name to delete:");
            string lastName = Console.ReadLine();

            Author author = authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);

            if (author != null)
            {
                authors.Remove(author);
                Console.WriteLine("Author deleted successfully.");
            }
            else
            {
                Console.WriteLine("Author not found.");
            }
        }

        static void AddBorrower()
        {
            Console.WriteLine("Enter the borrower's first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the borrower's last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the borrower's email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter the borrower's phone number:");
            string phoneNumber = Console.ReadLine();

            Borrower borrower = new Borrower(firstName, lastName, email, phoneNumber);
            borrowers.Add(borrower);

            Console.WriteLine("Borrower added successfully.");
        }

        static void UpdateBorrower()
        {
            Console.WriteLine("Enter the borrower's first name to update:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the borrower's last name to update:");
            string lastName = Console.ReadLine();

            Borrower borrower = borrowers.FirstOrDefault(b => b.FirstName == firstName && b.LastName == lastName);

            if (borrower != null)
            {
                Console.WriteLine("Enter the new email:");
                string email = Console.ReadLine();

                Console.WriteLine("Enter the new phone number:");
                string phoneNumber = Console.ReadLine();

                borrower.Email = email;
                borrower.PhoneNumber = phoneNumber;

                Console.WriteLine("Borrower updated successfully.");
            }
            else
            {
                Console.WriteLine("Borrower not found.");
            }
        }

        static void DeleteBorrower()
        {
            Console.WriteLine("Enter the borrower's first name to delete:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the borrower's last name to delete:");
            string lastName = Console.ReadLine();

            Borrower borrower = borrowers.FirstOrDefault(b => b.FirstName == firstName && b.LastName == lastName);

            if (borrower != null)
            {
                borrowers.Remove(borrower);
                Console.WriteLine("Borrower deleted successfully.");
            }
            else
            {
                Console.WriteLine("Borrower not found.");
            }
        }

        static void RegisterBookToBorrower()
        {
            Console.WriteLine("Enter the book title:");
            string title = Console.ReadLine();

            Book book = books.FirstOrDefault(b => b.Title == title);

            if (book != null)
            {
                Console.WriteLine("Enter the borrower's first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter the borrower's last name:");
                string lastName = Console.ReadLine();

                Borrower borrower = borrowers.FirstOrDefault(b => b.FirstName == firstName && b.LastName == lastName);

                if (borrower != null)
                {
                    Console.WriteLine("Enter the due date (YYYY-MM-DD):");
                    DateTime dueDate = Convert.ToDateTime(Console.ReadLine());

                    BorrowedBook borrowedBook = new BorrowedBook(book, borrower, DateTime.Now, dueDate);
                    borrowedBooks.Add(borrowedBook);

                    book.IsAvailable = false;

                    Console.WriteLine("Book registered to borrower successfully.");
                }
                else
                {
                    Console.WriteLine("Borrower not found.");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void DisplayAllBooks()
        {
            Console.WriteLine("All Books:");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FullName}, Publication Year: {book.PublicationYear}, Available: {(book.IsAvailable ? "Yes" : "No")}");
            }
        }

        static void DisplayAllAuthors()
        {
            Console.WriteLine("All Authors:");
            foreach (Author author in authors)
            {
                Console.WriteLine($"Name: {author.FullName}, Date of Birth: {author.DateOfBirth.ToShortDateString()}");
            }
        }

        static void DisplayAllBorrowers()
        {
            Console.WriteLine("All Borrowers:");
            foreach (Borrower borrower in borrowers)
            {
                Console.WriteLine($"Name: {borrower.FullName}, Email: {borrower.Email}, Phone Number: {borrower.PhoneNumber}");
            }
        }

        static void SearchBooks()
        {
            Console.WriteLine("Enter the search keyword:");
            string keyword = Console.ReadLine();

            var searchResults = books.Where(b =>
                b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                b.Author.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                borrowedBooks.Any(bb => bb.Borrower.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) && bb.Book == b)
            );

            Console.WriteLine("Search Results:");
            foreach (Book book in searchResults)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FullName}, Publication Year: {book.PublicationYear}, Available: {(book.IsAvailable ? "Yes" : "No")}");
            }
        }

        static void FilterBooksByStatus()
        {
            Console.WriteLine("Enter the book status (available/borrowed):");
            string status = Console.ReadLine();

            bool isAvailable = status.Equals("available", StringComparison.OrdinalIgnoreCase);

            var filteredBooks = books.Where(b => b.IsAvailable == isAvailable);

            Console.WriteLine("Filtered Books:");
            foreach (Book book in filteredBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FullName}, Publication Year: {book.PublicationYear}, Available: {(book.IsAvailable ? "Yes" : "No")}");
            }
        }

        static Author FindOrCreateAuthor(string firstName, string lastName)
        {
            Author author = authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);

            if (author == null)
            {
                author = new Author(firstName, lastName);
                authors.Add(author);
            }

            return author;
        }
    }

    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, Author author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            IsAvailable = true;
        }
    }

    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Author(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }

    class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public Borrower(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }

    class BorrowedBook
    {
        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        public BorrowedBook(Book book, Borrower borrower, DateTime borrowDate, DateTime dueDate)
        {
            Book = book;
            Borrower = borrower;
            BorrowDate = borrowDate;
            DueDate = dueDate;
        }
    }
}
