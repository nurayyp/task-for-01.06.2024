using System;
using task_1;
using task1;
using static System.Runtime.InteropServices.JavaScript.JSType;

public static class Program
{
    public static void Main()
    {
        Course course = new Course("kimya");
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
            Console.WriteLine("8 - Search Student");
            Console.WriteLine("9 - Delete Student");
            Console.WriteLine("10 - Edit Student");
            Console.WriteLine("11 - Exit");
            string input = Console.ReadLine();
            int result;
            bool isTrue = int.TryParse(input, out result);
            if (isTrue)
            {
                switch (result)
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
                            group.GetDetails();
                        break;
                    case (int)Menu.EditGroup:
                        Console.WriteLine("Enter the name of Group you want to change");
                        string groupName = Console.ReadLine();
                        if (course.Groups.Any(g => g.Name == groupName))
                        {
                            for (int i = 0; i < course.Groups.Count(); i++)
                            {
                                Group group = course.Groups[i];
                                if (group.Name == groupName)
                                {
                                    Description: Console.WriteLine("Enter new name");
                                    string editedName = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(editedName) && editedName.Length > 2)
                                    {
                                        if (!course.Groups.Any(g => g.Name == editedName))
                                        {
                                            group.Name = editedName;
                                        }
                                        else
                                        {
                                            Console.WriteLine("try again");
                                            goto Description;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("try again");
                                        goto Description;
                                    } 
                                }
                            }
                        }
                        break;
                    case (int)Menu.DeleteGroup:
                        Console.WriteLine("name of the group");
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
                            Console.WriteLine("group does not exist");
                        }
                        break;
                    case (int)Menu.AddStudent:
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
