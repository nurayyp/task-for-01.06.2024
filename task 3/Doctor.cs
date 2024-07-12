using System.Text.RegularExpressions;

namespace task_3
{
    internal class Doctor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Appointment> Appointments { get; private set; }
        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
    }
}
