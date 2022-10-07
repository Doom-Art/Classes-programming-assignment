using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Classes_programming_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> listOfStudents = new List<Students>();
            
            listOfStudents.Add(new Students("Robert", "Ross"));
            listOfStudents.Add(new Students("Hunter", "Wilson"));
            listOfStudents.Add(new Students("Kian", "Dufraimont"));
            listOfStudents.Add(new Students("Quinese", "Ross"));
            listOfStudents.Add(new Students("John", "Doe"));
            for (int i = 0; i < listOfStudents.Count; i++)
            {
                foreach (Students person in listOfStudents)
                {
                    if (listOfStudents[i].StudentNumber == person.StudentNumber && person != listOfStudents[i])
                        person.ResetStudentNumber();
                }
            }
            
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

                if (choice == 1){
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
                else if (choice == 5)
                    StudentSearch(listOfStudents);
                else if (choice == 6)
                    EditStudent(listOfStudents);
                else if (choice == 7)
                    BubbleSort(listOfStudents);
                else if (choice == 8)
                    Console.WriteLine("Goodbye");
                else{
                    Console.WriteLine("Invalid choice, press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        public static void RemoveStudent(List<Students> listStudent)
        {
            Console.Clear();
            int choice = 0;
            while (choice == 0)
            {
                Console.WriteLine("How would you like to select the student to remove?");
                Console.WriteLine("1 - By Index");
                Console.WriteLine("2 - By Student Number");
                Console.WriteLine("3 - By Full Name (If more than one will remove all)");
                Int32.TryParse(Console.ReadLine(), out choice);
                if (choice != 1 && choice != 2 && choice != 3){
                    choice = 0;
                    Console.WriteLine("Invalid choice, press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Console.Clear();
            if (choice == 1){
                for (int i = 0; i<listStudent.Count; i++)
                {
                    Console.WriteLine($"{i+1} - {listStudent[i]}");
                }
                Console.WriteLine();
                bool loop = false;
                int indexRemove = -1;
                while (!loop)
                {
                    Console.WriteLine("\nWhich student index would you like to remove?");
                    loop = Int32.TryParse(Console.ReadLine(), out indexRemove);
                    if (!loop)
                    {
                        Console.WriteLine("This is an Invalid Choice");
                    }
                    else if (indexRemove <1 || indexRemove > listStudent.Count){
                        loop = false;
                        Console.WriteLine("This is an invalid Number please try again");
                    }
                }
                indexRemove -= 1;
                Console.WriteLine($"The student {listStudent[indexRemove]} was removed at index {indexRemove+1}");
                listStudent.RemoveAt(indexRemove);
            }
            else if (choice == 2){
                foreach (Students person in listStudent)
                {
                    Console.WriteLine($"Name: {person}, Student Number: {person.StudentNumber}");
                }
                Console.WriteLine();
                bool loop = false;
                int numRemove = -1;
                while (!loop)
                {
                    Console.WriteLine("\nWhich student number would you like to remove?");
                    loop = Int32.TryParse(Console.ReadLine(), out numRemove);
                    if (!loop){
                        Console.WriteLine("This is an Invalid Choice");
                    }
                    else if (numRemove.ToString().Length != 6){
                        loop = false;
                        Console.WriteLine("This is an invalid Number please try again");
                    }
                }
                int indexRemove = -1;
                for (int i = 0; i < listStudent.Count; i++)
                {
                    if (listStudent[i].StudentNumber == numRemove){
                        indexRemove = i;
                        break;
                    }
                }
                if (indexRemove == -1){
                    Console.WriteLine($"The student number {numRemove} was not found in the database");
                }
                else{
                    Console.WriteLine($"The student {listStudent[indexRemove]} was removed with student number {numRemove}");
                    listStudent.RemoveAt(indexRemove);
                }
            }
            else if (choice == 3){
                foreach (Students person in listStudent)
                {
                    Console.WriteLine($"Name: {person}, Student Number: {person.StudentNumber}");
                }
                Console.WriteLine();
                string fName = "";
                while (fName == "")
                {
                    Console.WriteLine("What is the students First Name?");
                    fName = Console.ReadLine();
                    if (fName == "")
                        Console.WriteLine("This is not a valid First Name");
                }
                fName = char.ToUpper(fName[0]) + fName.Substring(1).ToLower();
                Console.Clear();
                string lName = "";
                while (lName == "")
                {
                    Console.WriteLine("What is the students Last Name?");
                    lName = Console.ReadLine();
                    if (lName == "")
                        Console.WriteLine("This is not a valid Last Name");
                }
                lName = char.ToUpper(lName[0]) + lName.Substring(1).ToLower();
                int count = 0;
                bool occured = false;
                while (true)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i < listStudent.Count; i++)
                    {
                        if (listStudent[i].LastName == lName && listStudent[i].FirstName == fName){
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
                        Console.WriteLine($"The student {listStudent[indexOfStudent]} was removed with student number of {listStudent[indexOfStudent].StudentNumber}");
                        listStudent.RemoveAt(indexOfStudent);
                    }
                }
            }
            Console.WriteLine("\nPress enter to return to the Menu");
            Console.ReadLine();
        }
        public static void AddAStudent(List<Students> list)
        {
            Console.Clear();
            string fName = "";
            while (fName == "")
            {
                Console.WriteLine("Please enter the students First Name?");
                fName = Console.ReadLine().Trim();
                if (fName == "" || fName.Contains(" ")){
                    Console.WriteLine("This is not a valid First Name");
                    fName = "";
                }
            }
            fName = char.ToUpper(fName[0]) + fName.Substring(1).ToLower();
            Console.Clear();
            string lName = "";
            while (lName == "")
            {
                Console.WriteLine("Please enter the students Last Name?");
                lName = Console.ReadLine().Trim();
                if (lName == "" || fName.Contains(" ")){
                    Console.WriteLine("This is not a valid Last Name");
                    lName = "";
                }
            }
            lName = char.ToUpper(lName[0]) + lName.Substring(1).ToLower();
            Students person = new Students(fName, lName);
            bool exists = true;
            while (exists)
            {
                exists = false;
                foreach (Students student in list)
                {
                    if (person.StudentNumber == student.StudentNumber){
                        exists = true;
                        person.ResetStudentNumber();
                    }
                }
            }
            list.Add(person);
            Console.WriteLine($"The student {person} has been added");
            Console.WriteLine("\nPress enter to return to the Menu");
            Console.ReadLine();
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
                Console.WriteLine("What is the students First Name?");
                string fName = Console.ReadLine().Trim().ToUpper();
                int count = 0;
                bool occured = false;
                bool end = true;
                Console.Clear();
                while (end)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i < list.Count; i++)
                    {
                        if ((list[i].FirstName.ToUpper()) == fName){
                            indexOfStudent = i;
                            count = i + 1;
                            break;
                        }
                    }
                    if (indexOfStudent == -1 && !occured){
                        Console.WriteLine("We couldnt find that first name in the database");
                        end = false;
                    }
                    else if (indexOfStudent == -1 && occured)
                        end = false;
                    else{
                        if (!occured){
                            Console.WriteLine("Here are all the students with that first name: \n");
                            occured = true;
                        }
                        Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                    }
                }
            }
            else if (choice == 2){
                Console.WriteLine("What is the students Last Name?");
                string lName = Console.ReadLine().Trim().ToUpper();
                int count = 0;
                bool occured = false;
                bool end = true;
                Console.Clear();
                while (end)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i < list.Count; i++)
                    {
                        if ((list[i].LastName.ToUpper()) == lName){
                            indexOfStudent = i;
                            count = i + 1;
                            break;
                        }
                    }
                    if (indexOfStudent == -1 && !occured){
                        Console.WriteLine("We couldnt find that last name in the database");
                        end = false;
                    }
                    else if (indexOfStudent == -1 && occured)
                        end = false;
                    else{
                        if (!occured){
                            Console.WriteLine("Here are all the students with that last name: \n");
                            occured = true;
                        }
                        Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                    }
                }
            }
            else if (choice == 3){
                Console.WriteLine("What is the students First Name?");
                string fName = Console.ReadLine().Trim().ToUpper();
                Console.Clear();
                Console.WriteLine("What is the students Last Name?");
                string lName = Console.ReadLine().Trim().ToUpper();
                Console.Clear();
                int count = 0;
                bool occured = false;
                bool end = true;
                while (end)
                {
                    int indexOfStudent = -1;
                    for (int i = count; i < list.Count; i++)
                    {
                        if ((list[i].LastName.ToUpper()) == lName && list[i].FirstName.ToUpper() == fName){
                            indexOfStudent = i;
                            count = i + 1;
                            break;
                        }
                    }
                    if (indexOfStudent == -1 && !occured){
                        Console.WriteLine("We couldnt find that name in the database");
                        end = false;
                    }
                    else if (indexOfStudent == -1 && occured)
                        end = false;
                    else{
                        if (!occured){
                            Console.WriteLine("Here are all the students with that name: \n");
                            occured = true;
                        }
                        Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                    }
                }
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
        public static void StudentSearch(List<Students> list)
        {
            Console.Clear();
            Console.WriteLine("Welcome to student Search! \nYou can enter part of any students first name or last name to search for.");
            Console.WriteLine("After Searching for all students who match the criteria of the searched name they will have their info printed.");
            string fName = "";
            Console.WriteLine("Please search for a name?");
            fName = Console.ReadLine().Trim().ToUpper();
            int count = 0;
            bool occured = false;
            bool end = true;
            while (end)
            {
                int indexOfStudent = -1;
                for (int i = count; i < list.Count; i++)
                {
                    if ((list[i].FirstName.ToUpper()).Contains(fName) || list[i].LastName.ToUpper().Contains(fName)){
                        indexOfStudent = i;
                        count = i + 1;
                        break;
                    }
                }
                if (indexOfStudent == -1 && !occured){
                    Console.WriteLine("We couldnt find any names that match your criteria in the database");
                    end = false;
                }
                else if (indexOfStudent == -1 && occured)
                    end = false;
                else{
                    if (!occured){
                        Console.WriteLine("Here are all the names that match your criteria: \n");
                        occured = true;
                    }
                    Console.WriteLine($"Name: {list[indexOfStudent]} \nEmail: {list[indexOfStudent].Email} \nStudent Number: {list[indexOfStudent].StudentNumber}\n");
                }
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
        public static void EditStudent(List<Students> listStudent)
        {
            Console.Clear();
            int indexRemove = 0;
            bool continueTo = true;
            while (continueTo)
            {
                bool loop = false;
                indexRemove = -1;
                while (!loop)
                {
                    for (int i = 0; i < listStudent.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {listStudent[i]}");
                    }
                    Console.WriteLine("\nWhich student index would you like to edit?");
                    loop = Int32.TryParse(Console.ReadLine(), out indexRemove);
                    if (!loop){
                        Console.WriteLine("This is an Invalid Choice");
                    }
                    else if (indexRemove < 1 || indexRemove > listStudent.Count){
                        loop = false;
                        Console.WriteLine("This is an invalid Number please try again");
                    }
                }
                Console.WriteLine($"You have selected student: {listStudent[indexRemove-1]} \nIs this the student you wish to edit?\n'Y' or 'N'");
                string correct = Console.ReadLine().ToUpper().Trim();
                if (correct == "Y")
                    continueTo = false;
                Console.Clear();
            }
            indexRemove -= 1;
            int choice = 0;
            while (choice == 0)
            {
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine("1 - First Name");
                Console.WriteLine("2 - Last Name");
                Console.WriteLine("3 - New Student Number");
                Int32.TryParse(Console.ReadLine(), out choice);
                if (choice != 1 && choice != 2 && choice != 3){
                    choice = 0;
                    Console.WriteLine("Invalid choice, press ENTER to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            Students tempStudent = new Students (listStudent[indexRemove].FirstName, listStudent[indexRemove].LastName);
            if (choice == 1){
                string fName = "";
                while (fName == "")
                {
                    Console.WriteLine("Please enter the students First Name?");
                    fName = Console.ReadLine().Trim();
                    if (fName == "")
                        Console.WriteLine("This is not a valid First Name");
                }
                fName = char.ToUpper(fName[0]) + fName.Substring(1).ToLower();
                Console.Clear();
                listStudent[indexRemove].FirstName = fName;
                Console.WriteLine($"The Name {tempStudent} has been changed to {listStudent[indexRemove]}");
            }
            else if (choice == 2){
                string lName = "";
                while (lName == "")
                {
                    Console.WriteLine("Please enter the students Last Name?");
                    lName = Console.ReadLine().Trim();
                    if (lName == "")
                        Console.WriteLine("This is not a valid Last Name");
                }
                lName = char.ToUpper(lName[0]) + lName.Substring(1).ToLower();
                Console.Clear();
                listStudent[indexRemove].LastName = lName;
                Console.WriteLine($"The Name {tempStudent} has been changed to {listStudent[indexRemove]}");
            }
            else if(choice == 3){
                bool exists = true;
                int tempNum = listStudent[indexRemove].StudentNumber;
                listStudent[indexRemove].ResetStudentNumber();
                while (exists)
                {
                    exists = false;
                    foreach (Students student in listStudent)
                    {
                        if (listStudent[indexRemove].StudentNumber == student.StudentNumber && student != listStudent[indexRemove]){
                            exists = true;
                            listStudent[indexRemove].ResetStudentNumber();
                        }
                    }
                }
                Console.WriteLine($"The student number {tempNum} has been changed to {listStudent[indexRemove].StudentNumber}");
            }
            Console.WriteLine("Press enter to return to the main menu");
            Console.ReadLine();
        }
        public static void BubbleSort(List<Students> arr)
        {
            Console.Clear();
            Console.WriteLine("How would you like to sort the List? \n1 - By Student Number \n2 - By Last Name");
            bool correct = Int32.TryParse(Console.ReadLine(), out int type);
            if (!correct || (type != 1 && type != 2))
                Console.WriteLine("You did not enter a valid option so we will just leave the list as is");
            else if (type == 1){
                Students temp;
                for (int j = 0; j < arr.Count - 1; j++)
                {
                    for (int i = 0; i < arr.Count - 1; i++)
                    {
                        if (arr[i].StudentNumber > arr[i + 1].StudentNumber){
                            temp = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i]= temp;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Here is the sorted list of students: \n");
                foreach (Students person in arr)
                {
                    Console.WriteLine($"{person}, {person.StudentNumber}");
                }
            }
            else
            {
                arr.Sort();
                Console.Clear();
                Console.WriteLine("Here is the sorted list of students: \n");
                foreach (Students person in arr)
                {
                    Console.WriteLine(person);
                }
            }
            Console.WriteLine("\nPress enter to return to the menu");
            Console.ReadLine();

        }
    }
}