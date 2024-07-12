using System.Text.RegularExpressions;
using task_3;

public static class Program
{
    public static void Main()
    {
        Hospital hospital = new Hospital();
        Menu:  Console.WriteLine("MENU");
        Console.WriteLine("1 - Add doctor");
        Console.WriteLine("2 - View doctors");
        Console.WriteLine("3 - Create appointment");
        Console.WriteLine("4 - Show appointments of doctor");
        Console.WriteLine("5 - Exit");
        Console.WriteLine("Choose one of them");
        int choice;
        string Mchoice = Console.ReadLine();
        bool isTrue = int.TryParse(Mchoice, out choice);
        switch (choice)
        {
            case (int)Menu.AddDoctor:
                Input: Console.WriteLine("add doctor name");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    Sname: Console.WriteLine("add doctor surname");
                    string surname = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(surname))
                    {
                        hospital.AddDoctor(new Doctor { Name = name, Surname = surname });
                    }
                    else
                    {
                        Console.WriteLine("try again for surname");
                        goto Sname;
                    }
                }
                else
                {
                    Console.WriteLine("try again for name");
                    goto Input;
                }
                break;
            case (int)Menu.ViewDoctors:
                foreach (var doctor in hospital.Doctors)
                {
                    Console.WriteLine(doctor.Name, doctor.Surname);
                }
                break;
            case (int)Menu.CreateAppointment:
                Dname:  Console.WriteLine("the name of the doctor");
                string dName = Console.ReadLine();
                var Doctor = hospital.Doctors.FirstOrDefault(d => d.Name == dName);
                if (Doctor == null)
                {
                    Console.WriteLine("try again for doctor name");
                    goto Dname;
                }
                else
                {
                    Dsurname: Console.WriteLine("the surname of the doctor");
                    string dsurname = Console.ReadLine();
                    var sdoctor = hospital.Doctors.FirstOrDefault(d => d.Name == dsurname);
                    if (sdoctor == null)
                    {
                        Console.WriteLine("try again for doctor surname");
                        goto Dsurname;
                    }
                }
                Console.WriteLine("the name of the patient");
                string pName = Console.ReadLine();
                Console.WriteLine("the surname of the patient");
                string pSurname = Console.ReadLine();
                Date: Console.WriteLine("datetime of appointment");
                DateTime Date;
                if (!DateTime.TryParse(Console.ReadLine(), out Date))
                {
                    Console.WriteLine("try again for date");
                    goto Date;
                }
                Doctor.Appointments.Add(new Appointment { PatientName = pName, PatientSurname =pSurname, Date = Date });
                break;
            case (int)Menu.ShowAppointmentsOfDoctor:
                D:  Console.WriteLine("the name of the doctor");
                string Dname = Console.ReadLine();
                var selectedDoctor = hospital.Doctors.FirstOrDefault(d => d.Name == Dname);
                if (selectedDoctor == null)
                {
                    Console.WriteLine("try again for doctor");
                    goto D;
                }
                foreach (var appointment in selectedDoctor.Appointments)
                {
                    Console.WriteLine($" {appointment.PatientName} {appointment.PatientSurname} - {appointment.Date}");
                }
                break;
            case (int)Menu.Exit:
                break;
        }
    }
}