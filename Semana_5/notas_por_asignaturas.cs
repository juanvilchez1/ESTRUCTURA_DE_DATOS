using System;
using System.Collections.Generic;

public class Student
{
    private List<string> subjects;
    private Dictionary<string, int> grades;

    public Student()
    {
        subjects = new List<string> { "Matemáticas", "Física", "Química", "Historia", "Lengua" };
        grades = new Dictionary<string, int>();
    }

    public void AddGrades()
    {
        foreach (var subject in subjects)
        {
            Console.Write($"¿Qué nota has sacado en {subject}? ");
            int grade = int.Parse(Console.ReadLine());
            grades[subject] = grade;
        }
    }

    public void DisplayGrades()
    {
        foreach (var subject in grades)
        {
            Console.WriteLine($"En {subject.Key} has sacado {subject.Value}");
        }
    }
}

class Program3
{
    static void Main()
    {
        Student student = new Student();
        student.AddGrades();
        student.DisplayGrades();
    }
}
