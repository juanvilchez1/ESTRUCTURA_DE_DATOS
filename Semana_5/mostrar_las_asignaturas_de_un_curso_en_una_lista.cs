using System;
using System.Collections.Generic;

public class Course
{
    private List<string> subjects;

    public Course()
    {
        subjects = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
    }

    public void DisplaySubjects()
    {
        Console.WriteLine("Asignaturas del curso:");
        foreach (var subject in subjects)
        {
            Console.WriteLine(subject);
        }
    }
}

class Program1
{
    static void Main()
    {
        Course course = new Course();
        course.DisplaySubjects();
    }
}
