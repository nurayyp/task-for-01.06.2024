namespace task1
{
    internal class Student
    {
        private static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Grade { get; set; }
        public Student(string name, string surname, int age, decimal grade)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Grade = grade;
            Id = id++;
        }
    }
}
