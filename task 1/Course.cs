namespace task1
{
    internal class Course
    {
        private static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Group> Groups { get; }
        public Course(string name)
        {
            Id = id++;
            Name = name;
            Groups = new List<Group>();
        }
        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }
    }
}
