namespace task1
{
    internal class Group
    {
        private static int id = 1;
        public int Id { get; set; }  
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public Group(string name)
        {   
            Name = name;
            Id = id++ ;
            Students = new List<Student>();
        }
        public void GetDetails()
        {
            Console.WriteLine($"Group Name - {Id}, {Name}");
        }
    }
}
