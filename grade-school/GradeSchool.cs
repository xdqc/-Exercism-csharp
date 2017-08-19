using System;
using System.Linq;
using System.Collections.Generic;

public class School
{
    readonly Dictionary<string, int> Students = new  Dictionary<string, int>();

    public void Add(string student, int grade)
    {
        Students.Add(student,grade);
    }

    public IEnumerable<string> Roster()
    {
        return from s in Students
                orderby s.Value, s.Key
                select s.Key;
    }

    public IEnumerable<string> Grade(int grade)
    {
        return from s in Students
                where s.Value == grade
                orderby s.Key
                select s.Key;
    }
}