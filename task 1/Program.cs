using System;
using task_1;
using task1;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class Program
{
    public static void Main()
    {
        Course course = new Course("kimya");
        int count = 0;
        while (true)
        {
            MENU: Console.WriteLine("MENU");
            Console.WriteLine("1 - Add Group");
            Console.WriteLine("2 - List of Groups");
            Console.WriteLine("3 - Edit Group");
            Console.WriteLine("4 - Delete Group");
            Console.WriteLine("5 - Add Student");
            Console.WriteLine("6 - List of Students in Course");
            Console.WriteLine("7 - List of students in Group");
            Console.WriteLine("8 - Edit Student");
            Console.WriteLine("9 - Search Student");
            Console.WriteLine("10 - Delete Student");
            Console.WriteLine("0 - Exit");
            string input = Console.ReadLine();
            int given;
            bool isTrue = int.TryParse(input, out given);
            if (isTrue)
            {
                switch (given)
                {
                    case (int)Menu.AddGroup:
                        Console.WriteLine("qrup adi daxil edin");
                    Input: string name = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(name))
                        {
                            if (!course.Groups.Any(g => g.Name == name))
                            {
                                course.AddGroup(new Group(name));
                            }
                            else
                            {
                                Console.WriteLine("daxil etdiyiniz adda qrup artiq movcuddur, yeniden daxil edin");
                            }
                        }
                        else
                        {
                            Console.WriteLine("yeniden daxil edin");
                            goto Input;
                        }
                        break;
                    case (int)Menu.ListOfGroups:
                        foreach (var group in course.Groups)
                            group.GetGroupDetails();
                        break;
                    case (int)Menu.EditGroup:
                        Console.WriteLine("qrup adi daxil edin");
                        string editedGroupName = Console.ReadLine();
                        if (course.Groups.Any(g => g.Name == editedGroupName))
                        {
                            for (int i = 0; i < course.Groups.Count(); i++)
                            {
                                Group group = course.Groups[i];
                                if (group.Name == editedGroupName)
                                {
                                Description: Console.WriteLine("yeni adi daxil edin");
                                    string newName = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(newName))
                                    {
                                        if (!course.Groups.Any(g => g.Name == newName))
                                        {
                                            group.Name = newName;
                                        }
                                        else
                                        {
                                            Console.WriteLine("bu adda qrup artiq movcuddur");
                                            goto Description;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("yeniden daxil edin");
                                        goto Description;
                                    }
                                }
                            }
                        }
                        break;
                    case (int)Menu.DeleteGroup:
                        NU:  Console.WriteLine("qrupun adini daxil edin");
                        string deletedGroupName = Console.ReadLine();
                        if (course.Groups.Any(g => g.Name == deletedGroupName))
                        {
                            for (int i = 0; i < course.Groups.Count(); i++)
                            {
                                Group group = course.Groups[i];
                                if (group.Name == deletedGroupName)
                                {
                                    course.Groups.Remove(group);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("bele qrup movcud deyil, yeniden daxil edin");
                            goto NU;
                        }
                        break;
                    case (int)Menu.AddStudent:
                        Nur: Console.WriteLine("sagird elave etmek istediyiniz qrupu secin");
                        string wantedGroupName = Console.ReadLine();
                        var currentGroup = course.Groups.FirstOrDefault(g => g.Name == wantedGroupName);
                        if (currentGroup == null)
                        {
                            Console.WriteLine("bele qrup yoxdur, yeniden daxil edin");
                            goto Nur;
                        }
                        Console.WriteLine("sagirdin adi: ");
                        string sName = Console.ReadLine();
                        Console.WriteLine("sagirdin soyadi: ");
                        string Surname = Console.ReadLine();
                        Console.WriteLine("sagirdin yasi: ");
                        int Age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("sagirdin final qiymeti: ");
                        decimal FinalGrade = Convert.ToDecimal(Console.ReadLine());
                        var newStudent = new Student(sName, Surname, Age, FinalGrade);
                        currentGroup.Students.Add(newStudent);
                        break;
                    case (int)Menu.ListOfStudentsInCourse:
                        foreach (var group in course.Groups)
                        {
                            foreach (var student in group.Students)
                            {
                                Console.WriteLine(student.Name, student.Surname, student.Age, student.FinalGrade);
                            }
                        }
                        break;
                    case (int)Menu.ListOfStudentsInGroup:
                        Console.WriteLine("qrupun adini daxil edin");
                        string Name = Console.ReadLine();
                        currentGroup = course.Groups.FirstOrDefault(g => g.groupName == Name);
                        foreach (var student in currentGroup.Students)
                        {
                            Console.WriteLine(student.Name, student.Surname, student.Age, student.FinalGrade);
                        }
                        break;
                    case (int)Menu.EditStudent:
                        AY: Console.WriteLine("Sagird deyismek istediyiniz qrupun adini qeyd edin");
                        string grName = Console.ReadLine();
                        var group1 = course.Groups.FirstOrDefault(g =>g.Name == grName);
                        if (group1 == null)
                        {
                            Console.WriteLine("bele qrup yoxdur");
                            goto AY;
                        }
                        Ay:  Console.WriteLine("deyismek istediyiniz sagirdin adini daxil edin");
                        string stName = Console.ReadLine();
                        var student1 = group1.Students.FirstOrDefault(s => s.Name == stName);
                        if (student1 == null)
                        {
                            Console.WriteLine("bele sagird yoxdur");
                            goto Ay;
                        }
                        Console.WriteLine("sagirdin adinin yeni hali");
                        student1.Name = Console.ReadLine();
                        Console.WriteLine("sagirdin soyadinin yeni hali");
                        student1.Surname = Console.ReadLine();
                        Console.WriteLine("sagirdin yasinin yeni hali");
                        student1.Age = Console.ReadLine();
                        Console.WriteLine("sagirdin qiymetinin yeni hali");
                        student1.FinalGrade = Console.ReadLine();
                        break;
                    case (int)Menu.DeleteStudent:
                        Nury: Console.WriteLine("sagird silmek istediyiniz qrupu daxil edin");
                        string GroupName = Console.ReadLine();
                        Group searchedGroup = course.Groups.FirstOrDefault(g => g.Name == GroupName);
                        if (GroupName == null)
                        {
                            Console.WriteLine("yeniden daxil edin");
                            goto Nury;
                        }
                        Nuray: Console.WriteLine("sagirdin adini daxil edin");
                        string StudentName = Console.ReadLine();
                        var deletedStudent = searchedGroup.Students.FirstOrDefault(g => g.Name == StudentName );
                        searchedGroup.Students.Remove(deletedStudent);
                        break;
                }
            }
            else
            {
                goto MENU;
            }
        }
    }
}