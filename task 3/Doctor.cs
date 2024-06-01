namespace task_3
{
    internal class Doctor
    {
        public string Name { get; set; }
        public List<Appointment> Appointments { get; private set; }

        public Doctor(string name)
        {
            Name = name;
            Appointments = new List<Appointment>();
        }
    }
}
