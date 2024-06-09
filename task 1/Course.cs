namespace task1
{
    internal class Course
    {
        private static int id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public CustomList<Group> Groups = new CustomList<Group>();
        public Course(string name)
        {
            Id = id++;
            Name = name;
        }
        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }
    }
}
