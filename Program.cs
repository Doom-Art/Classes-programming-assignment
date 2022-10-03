namespace Classes_programming_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> listOfStudents = new List<Students>();
            
            Students person1 = new Students("Robert", "Ross");
            Students person2 = new Students("Hunter", "Wilson");
            Students person3 = new Students("Kian", "Dufraimont");
            listOfStudents.Add(person1);
            listOfStudents.Add(person2);
            listOfStudents.Add(person3);

            
            foreach (Students people in listOfStudents)
            {
                Console.WriteLine(people);
            }

        }
    }
}