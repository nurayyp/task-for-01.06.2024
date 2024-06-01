using task_3;

public static class Program
{
    public static void Main()
    {
        Hospital hospital = new Hospital();
        while (true)
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1 - Add doctor");
            Console.WriteLine("2 - View all doctors");
            Console.WriteLine("3 - Schedule appointment");
            Console.WriteLine("4 - View appointments of doctor");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Birini secin");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddDoctor(hospital);
                    break;
                case "2":
                    ViewAllDoctors(hospital);
                    break;
                case "3":
                    ScheduleAppointment(hospital);
                    break;
                case "4":
                    ViewAppointmentsOfDoctor(hospital);
                    break;
                case "5":
                    return;
            }
        }
    }
    static void AddDoctor(Hospital hospital)
    {
        Console.WriteLine("Name of the doctor");
        string name = Console.ReadLine();
        hospital.AddDoctor(new Doctor(name));
    }
    static void ViewAllDoctors(Hospital hospital)
    {
        foreach (var doctor in hospital.Doctors)
        {
            Console.WriteLine(doctor.Name);
        }
    }
    static void ScheduleAppointment(Hospital hospital)
    {
        Console.WriteLine("Name of the doctor");
        string doctorName = Console.ReadLine();
        var doctor = hospital.Doctors.FirstOrDefault(d => d.Name == doctorName);
        Console.WriteLine("Name of the patient");
        string patientName = Console.ReadLine();
        Input:  Console.WriteLine("Time of the appointment (year-month-day time)");
        DateTime meetingTime;
        if (!DateTime.TryParse(Console.ReadLine(), out meetingTime))
        {
            Console.WriteLine("Add time again");
            goto Input;
        }
        if (doctor.Appointments.Any(d => d.Date < meetingTime  && d.Date > meetingTime))
        {
            Console.WriteLine("Add time again");
            goto Input ;
        }
        doctor.Appointments.Add(new Appointment { PatientName = patientName, Date = meetingTime });
        Console.WriteLine("Come in time");
    }
    static void ViewAppointmentsOfDoctor(Hospital hospital)
    {
        Console.WriteLine("Name of the doctor");
        string doctorName = Console.ReadLine();
        var doctor = hospital.Doctors.FirstOrDefault(n => n.Name == doctorName);
        foreach (var appointment in doctor.Appointments)
        {
            Console.WriteLine($"{appointment.PatientName}, {appointment.Date}");
        }
    }
}