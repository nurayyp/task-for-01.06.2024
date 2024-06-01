namespace task_3
{
    internal class Hospital
    {
        public List<Doctor> Doctors { get; private set; }
        public Hospital()
        {
            Doctors = new List<Doctor>();
        }
        public void AddDoctor(Doctor doctor)
        {
            Doctors.Add(doctor);
        }
    }
}
