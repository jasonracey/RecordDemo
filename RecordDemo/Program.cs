using System;

namespace RecordDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var frodoRecord1 = new Record1("Frodo", "Baggins");
            var frodoRecord2 = new Record1("Frodo", "Baggins");

            var frodoClass1 = new Class1("Frodo", "Baggins");
            var frodoClass2 = new Class1("Frodo", "Baggins");

            Console.WriteLine("Record Type:");
            Console.WriteLine($"To String: {frodoRecord1}");
            Console.WriteLine($"Are the two objects equal: {Equals(frodoRecord1, frodoRecord2)}");
            Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(frodoRecord1, frodoRecord2)}");
            Console.WriteLine($"Are the two objects ==: {frodoRecord1 == frodoRecord2}");
            Console.WriteLine($"Hash code of object a: {frodoRecord1.GetHashCode()}");
            Console.WriteLine($"Hash code of object b: {frodoRecord2.GetHashCode()}");

            Console.WriteLine();
            Console.WriteLine("**********");
            Console.WriteLine();

            Console.WriteLine("Class Type:");
            Console.WriteLine($"To String: {frodoClass1}");
            Console.WriteLine($"Are the two objects equal: {Equals(frodoClass1, frodoClass2)}");
            Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(frodoClass1, frodoClass2)}");
            Console.WriteLine($"Are the two objects ==: {frodoClass1 == frodoClass2}");
            Console.WriteLine($"Hash code of object a: {frodoClass1.GetHashCode()}");
            Console.WriteLine($"Hash code of object b: {frodoClass2.GetHashCode()}");

            Console.WriteLine();

            var (fn, ln) = frodoRecord1;
            Console.WriteLine($"Deconstructed Name: {fn} {ln}");

            var bilboRecord = frodoRecord1 with
            {
                FirstName = "Bilbo"
            }; 
            Console.WriteLine($"Bilbo's Record: {bilboRecord}");

            Console.WriteLine();
            Record2 pippinRecord = new ("Peregrin", "Took");
            Console.WriteLine($"Pippin record value: {pippinRecord}");
            Console.WriteLine($"Pippin fn: {pippinRecord.FirstName} ln: {pippinRecord.LastName}");
            Console.WriteLine(pippinRecord.SayHello());
        }
    }

    public record Record1(string FirstName, string LastName);

    public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName);

    public record Record2(string FirstName, string LastName)
    {
        private string _firstName = FirstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init { }
        }

        public string FullName { get => $"{FirstName} {LastName}"; }

        public string SayHello()
        {
            return $"Hello, {FullName}!";
        }
    }

    public class Class1
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
