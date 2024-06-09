namespace task1
{
    internal class Group
    {
        private static int id = 1;
        public int Id { get; set; }  
        public string Name { get; set; }
        public CustomList<Student> Students = new CustomList<Student>();
        public Group(string name)
        {   
            Name = name;
            Id = id++ ;
        }
        public void GetGroupDetails()
        {
            Console.WriteLine($"Group Name - {Id}, {Name}");
        }
    }
}
