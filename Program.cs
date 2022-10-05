﻿using System.Xml.Linq;

namespace Classes_programming_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> listOfStudents = new List<Students>();
            
            listOfStudents.Add(new Students("John", "Ross"));
            listOfStudents.Add(new Students("Hunter", "Wilson"));
            listOfStudents.Add(new Students("Kian", "Dufraimont"));
            listOfStudents.Add(new Students("Quinese", "Laurenze"));
            listOfStudents.Add(new Students("John", "Doe"));

            int choice = 0;
            while (choice != 8)
            {
                Console.Clear();
                Console.WriteLine("Here is the Student menu. Please select an option:");
                Console.WriteLine("1 - Display Students");
                Console.WriteLine("2 - Student Details");
                Console.WriteLine("3 - Add a Student");
                Console.WriteLine("4 - Remove a Student");
                Console.WriteLine("5 - Search for a Student");
                Console.WriteLine("6 - Edit a Student");
                Console.WriteLine("7 - Sort Students");
                Console.WriteLine("8 - Quit");
                Int32.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Here are the students: \n");
                    foreach (Students person in listOfStudents)
                    {
                        Console.WriteLine(person);
                    }
                    Console.WriteLine("\nPress enter to return to the menu");
                    Console.ReadLine();
                }
                else if (choice == 2)
                    StudentDetails(listOfStudents);
                else if (choice == 3)
                    AddAStudent(listOfStudents);
                else if (choice == 4)
                    RemoveStudent(listOfStudents);
                else if (choice == 5) { }
                else if (choice == 6) { }
                else if (choice == 7) { }
                else if (choice == 8)
                    Console.WriteLine("Goodbye");
                else
                {
                    Console.WriteLine("Invalid choice, press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

        }
        public static void RemoveStudent(List<Students> listStudent)
        {

        }
        public static void AddAStudent(List<Students> list)
        {
            string fName = "";
            while (fName == "")
            {
                Console.WriteLine("Please enter the students First Name?");
                fName = Console.ReadLine();
                if (fName == "")
                    Console.WriteLine("This is not a valid First Name");
            }
            fName = char.ToUpper(fName[0]) + fName.Substring(1);
            Console.Clear();
            string lName = "";
            while (lName == "")
            {
                Console.WriteLine("Please enter the students Last Name?");
                lName = Console.ReadLine();
                if (lName == "")
                    Console.WriteLine("This is not a valid Last Name");
            }
            lName = char.ToUpper(lName[0]) + lName.Substring(1);
            Students person = new Students(fName, lName);
            while (true)
            {
                bool exists = false;
                foreach (Students student in list)
                {
                    if (person.Equals(student)){
                        exists = true;
                        person.ResetStudentNumber();
                    }
                }
                if (!exists)
                    break;
            }
        }
        public static void StudentDetails(List<Students> list)
        {
            Console.Clear();
            int choice = 0;
            while (choice == 0)
            {
                Console.WriteLine("How would you like to select the student?");
                Console.WriteLine("1 - First Name");
                Console.WriteLine("2 - Last Name");
                Console.WriteLine("3 - Both");
                Int32.TryParse(Console.ReadLine(), out choice);
                if (choice != 1 && choice != 2 && choice != 3)
                {
                    choice = 0;
                    Console.WriteLine("Invalid choice, press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.Clear();
            if (choice == 1){
                string fName = "";
                while (fName == "")
                {
                    Console.WriteLine("What is the students First Name?");
                    fName = Console.ReadLine();
                    if (fName == "")
                        Console.WriteLine("This is not a valid First Name");
                }
                fName = char.ToUpper(fName[0]) + fName.Substring(1);
                int count = 0;
                bool occured = false;
                while (true)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i<list.Count; i++)
                    {
                        if (list[i].FirstName == fName){
                            indexOfStudent = i;
                            occured = true;
                            count = i+1;
                            break;
                        }
                    }
                    if (indexOfStudent == -1 && !occured){
                        Console.WriteLine("We couldnt find that first name in the database");
                        break;
                    }
                    else if(indexOfStudent == -1 && occured)
                        break;
                    else{
                        Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                    }
                }
            }
            if (choice == 2){
                string lName = "";
                while (lName == "")
                {
                    Console.WriteLine("What is the students Last Name?");
                    lName = Console.ReadLine();
                    if (lName == "")
                        Console.WriteLine("This is not a valid Last Name");
                }
                lName = char.ToUpper(lName[0]) + lName.Substring(1);
                int count = 0;
                bool occured = false;
                while (true)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i < list.Count; i++)
                    {
                        if (list[i].LastName == lName){
                            indexOfStudent = i;
                            occured = true;
                            count = i + 1;
                            break;
                        }
                    }
                    if (indexOfStudent == -1 && !occured){
                        Console.WriteLine("We couldnt find that last name in the database");
                        break;
                    }
                    else if (indexOfStudent == -1 && occured)
                        break;
                    else{
                        Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                    }
                }
            }
            if (choice == 3){
                string fName = "";
                while (fName == "")
                {
                    Console.WriteLine("What is the students First Name?");
                    fName = Console.ReadLine();
                    if (fName == "")
                        Console.WriteLine("This is not a valid First Name");
                }
                fName = char.ToUpper(fName[0]) + fName.Substring(1);
                Console.Clear();
                string lName = "";
                while (lName == "")
                {
                    Console.WriteLine("What is the students Last Name?");
                    lName = Console.ReadLine();
                    if (lName == "")
                        Console.WriteLine("This is not a valid Last Name");
                }
                lName = char.ToUpper(lName[0]) + lName.Substring(1);
                int count = 0;
                bool occured = false;
                while (true)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i < list.Count; i++)
                    {
                        if (list[i].LastName == lName && list[i].FirstName == fName){
                            indexOfStudent = i;
                            occured = true;
                            count = i + 1;
                            break;
                        }
                    }
                    if (indexOfStudent == -1 && !occured){
                        Console.WriteLine("We couldnt find that name in the database");
                        break;
                    }
                    else if (indexOfStudent == -1 && occured)
                        break;
                    else{
                        Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                    }
                }
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
    }
}