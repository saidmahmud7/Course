using Library.Model;
using Library.Service;
using Npgsql;

StudentService studentService = new StudentService();
MentorService mentorService = new MentorService();
CourseService courseService = new CourseService();
GroupService groupService = new GroupService();

for (; ; )
{
    System.Console.WriteLine("1. Добавить студента");
    System.Console.WriteLine("2. Добавить ментора");
    System.Console.WriteLine("3. Добавить курс");
    System.Console.WriteLine("4. Добавить группу");
    System.Console.WriteLine("5. Показать все студентов");
    System.Console.WriteLine("6. Показать все менторов");
    System.Console.WriteLine("7. Показать все курсы");
    System.Console.WriteLine("8. Показать все группы");
    System.Console.WriteLine("0. Выйти");
    System.Console.Write("Выберите действие:");
    int choice = int.Parse(System.Console.ReadLine());
    if (choice == 1)
    {
        try
        {
            System.Console.Write("Введите имя студента:");
            string name = System.Console.ReadLine();
            System.Console.Write("Введите возраст студента:");
            int age = int.Parse(System.Console.ReadLine());
            System.Console.Write("Введите телефон студента:");
            string phone = System.Console.ReadLine();
            System.Console.Write("Введите ID курса: ");
            foreach (var el in courseService.GetCourses())
            {
                System.Console.WriteLine($"ID: {el.CourseId}\nНазвание: {el.Name}\nОписание: {el.Description}");
            }
            System.Console.Write("Введите ID курса: ");
            int id = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Введите ID группы");
            foreach (Group group in groupService.GetGroups())
            {
                System.Console.WriteLine($"ID {group.GroupId}\nНазвание: {group.GroupName}");
            }
            System.Console.Write("Введите ID группы: ");
            int groupid = int.Parse(Console.ReadLine());
            studentService.Insert(new Student { Name = name, Age = age, Phone = phone, CourseId = id, GroupId = groupid });
            System.Console.WriteLine("Успешно добавлено");
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
    if (choice == 2)
    {
        try
        {
            System.Console.Write("Введите имя ментора:");
            string name = System.Console.ReadLine();
            System.Console.Write("Введите Email ментора:");
            string email = System.Console.ReadLine();
            System.Console.Write("Введите телефон ментора:");
            string phone = System.Console.ReadLine();
            mentorService.Insert(new Mentor { Name = name, Email = email, Phone = phone });
            System.Console.WriteLine("Успешно добавлено");
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
    if (choice == 3)
    {
        try
        {
            System.Console.Write("Введите название курса:");
            string name = System.Console.ReadLine();
            System.Console.Write("Введите описание курса:");
            string description = System.Console.ReadLine();
            courseService.Insert(new Course { Name = name, Description = description });
            System.Console.WriteLine("Успешно добавлено");
        }
        catch (NpgsqlException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
    if (choice == 4)
    {
        System.Console.WriteLine("Введите название группы: ");
        string name = System.Console.ReadLine();
        foreach (var el in courseService.GetCourses())
        {
            System.Console.WriteLine($"ID: {el.CourseId}\nНазвание: {el.Name}\nОписание: {el.Description}");
        }
        System.Console.Write("Введите Id группы: ");
        int id = int.Parse(Console.ReadLine());
        groupService.Insert(new Group { GroupName = name,CourseId = id });
        System.Console.WriteLine("Успешно добавлено!");
    }
    if (choice == 0)
    {
        break;
    }
}
