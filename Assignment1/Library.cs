using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment1
{

    //Custom exception to make sure that the book id has 5 digits
    class NumericBookId : Exception
    {
        public NumericBookId()
        {
            Console.Write("Book Id should have only 5 digits: ");
        }
    }

    //Custom exception class to make sure that the book id is not empty
    class EmptyBookId : Exception
    {
        public EmptyBookId()
        {
            Console.Write("Book Id should not be Empty: ");
        }
    }

    //custom exception class for checking that the book name is not empty
    class EmptyBookName : Exception
    {
        public EmptyBookName()
        {
            Console.Write("Book Name should not be Empty: ");
        }
    }

    //Custom exception class for making sure the lot values are entered as specified
    class NotContains : Exception
    {
        public NotContains()
        {
            Console.Write("LoT should have values from the given list: ");
        }
    }

    //Book class with the variables that will store all the details of the books
    class Book
    {
        public string bookId;
        public string bookName;
        public int isbn;
        public int price;
        public string publisher;
        public int numpages;
        public string lang;
        public string LoT;
        public string summary;

    }
    
    class Library
    {
       // static Dictionary<string, List<Book>> dict1 = new Dictionary<string, List<Book>>();
        static List<Book> arr = new List<Book>();
        static Book b1 = new Book();

        //Inserting the details of the books in the container
        public static void getdata(string _bookId, string _bookName, int _isbn, int _price, string _publisher, int _numpage, string _summary, string _lang = "English", string _lot = "Technical")
        {
            Book b1 = new Book();
            b1.bookId = _bookId;
            b1.bookName = _bookName;
            b1.isbn = _isbn;
            b1.price = _price;
            b1.publisher = _publisher;
            b1.numpages = _numpage;
            b1.summary = _summary;
            b1.lang = _lang;
            b1.LoT = _lot;
            //dict1.Add(_bookId, b1);
            arr.Add(b1);
        }

        //Displaying the detail of Every book stored in the Container
        public static void displaydata()
        {
            foreach(var bookdisplay in arr)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("The bookid is: " + bookdisplay.bookId);
                Console.WriteLine("The bookname is: " + bookdisplay.bookName);
                Console.WriteLine("The isbn is: " + bookdisplay.isbn);
                Console.WriteLine("The price is: " + bookdisplay.price);
                Console.WriteLine("The publisher is: " + bookdisplay.publisher);
                Console.WriteLine("The number of pages are: " + bookdisplay.numpages);
                Console.WriteLine("The language is: " + bookdisplay.lang);
                Console.WriteLine("The LoT is: " + bookdisplay.LoT);
                Console.WriteLine("The summary is: " + bookdisplay.summary);
                Console.WriteLine("=================================================");
            }
            
        }

        // to remove the details of the books using BookId
        public static void removeBookDetail()
        {
            Console.Write("Enter the Book Id: ");
            string BookId = Console.ReadLine();
            foreach(var item in arr)
            {
                if (item.bookId==BookId)
                {
                    arr.Remove(item);
                }
                else
                {
                    Console.WriteLine("Invalid Book ID");
                }
            }
        }

        //Main function to execute the program
        public static void Main()
        {

            bool flag = true;
            string bookId = "", bookName = "", LoT = "";
           
            while (flag)
            {
                Console.WriteLine("1--> Data Entry\n 2--> Display Data\n 3--> Delete Data\n 4--> Exit\n");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //try catch block to check for the validation of book id
                        try
                        {
                            Console.Write("Enter the book id: ");
                            bookId = Console.ReadLine();
                            if (bookId.Length == 0)
                            {
                                throw new EmptyBookId();
                            }
                            if (bookId.Length != 5)
                            {
                                throw new NumericBookId();

                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        try
                        {
                            Console.Write("Ener the book name: ");
                            bookName = Console.ReadLine();
                            if (bookName.Length == 0)
                            {
                                throw new EmptyBookName();
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }

                        Console.Write("Ener the Isbn number: ");
                        int isbn = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ener the Price: ");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ener the publisher name: ");
                        string publisher = Console.ReadLine();
                        Console.Write("Ener the number of pages: ");
                        int numpages = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ener the Language: ");
                        string lang = Console.ReadLine();
                        try
                        {
                            Console.WriteLine("Ener the LoT Values");
                            Console.Write("Please Enter values from the given options: “.NET”, “Java”, “IMS”, “V&V”, “BI”, “RDBMS”: ");
                            string[] lotval = { ".NET", "Java", "IMS", "V & V", "BI", "RDBMS" };
                            LoT = Console.ReadLine();
                            bool b = lotval.Contains(LoT);
                            if (!b)
                            {
                                throw new NotContains();
                            }

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message+" If left empty by default value would be taken as technical");
                            
                        }

                        Console.Write("Ener the Summary: ");
                        string summary = Console.ReadLine();
                        if (lang.Length == 0 && LoT.Length == 0)
                        {
                            getdata(bookId, bookName, isbn, price, publisher, numpages, summary);
                        }
                        if (lang.Length != 0 && LoT.Length == 0)
                        {
                           getdata(bookId, bookName, isbn, price, publisher, numpages, summary, _lang: lang);
                        }
                        if (lang.Length == 0 && LoT.Length != 0)
                        {
                            getdata(bookId, bookName, isbn, price, publisher, numpages, summary, _lot: LoT);
                        }
                        if (lang.Length != 0 && LoT.Length != 0)
                        {
                            getdata(bookId, bookName, isbn, price, publisher, numpages, summary, lang, LoT);
                        }

                        break;
                    case 2:
                        displaydata();
                        break;
                    case 3:
                        
                        removeBookDetail();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Please choose the correct option");
                        break;
                }

            }
        }
    }
}

