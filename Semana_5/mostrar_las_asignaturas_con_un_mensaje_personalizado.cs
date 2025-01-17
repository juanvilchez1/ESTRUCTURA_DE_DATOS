using System;
using System.Collections.Generic;

public class PersonalizedCourse
{
    private List<string> subjects;

    public PersonalizedCourse()
    {
        subjects = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
    }

    public void DisplaySubjectsWithMessage()
    {
        foreach (var subject in subjects)
        {
            Console.WriteLine($"Yo estudio {subject}");
        }
    }
}

class Program2
{
    static void Main()
    {
        PersonalizedCourse course = new PersonalizedCourse();
        course.DisplaySubjectsWithMessage();
    }
}
