using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DT1
{
    public delegate double GradeCalc(List<int> s);
    public enum GradeLevel { FirstYear = 1, SecondYear, ThirdYear, FourthYear };

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public GradeLevel Year;
        public List<int> ExamScores;
        public double Grade { get; set; }
    }

    public class StudentClass
    {
        public Func<Student, string, bool> studentSelector = (s, name) => s.LastName == name;
        public GradeCalc gradeCalculator = (s) => Math.Round(((s.Average() * 5) / 100 + 1) * 2.0) / 2.0;
        public Func<Student, bool> passedSelector = (s) => s.Year == GradeLevel.FourthYear && s.Grade >= 4.0;

        #region data
        public List<Student> students = new List<Student> {
        new Student {FirstName = "Terry", LastName = "Adams", ID = 120,
            Year = GradeLevel.SecondYear,
            ExamScores = new List<int>{ 99, 82, 81, 79}},
        new Student {FirstName = "Fadi", LastName = "Fakhouri", ID = 116,
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 99, 86, 90, 94}},
        new Student {FirstName = "Hanying", LastName = "Feng", ID = 117,
            Year = GradeLevel.FirstYear,
            ExamScores = new List<int>{ 93, 92, 80, 87}},
        new Student {FirstName = "Cesar", LastName = "Garcia", ID = 114,
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 97, 89, 85, 82}},
        new Student {FirstName = "Debra", LastName = "Garcia", ID = 115,
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 35, 72, 91, 70}},
        new Student {FirstName = "Hugo", LastName = "Garcia", ID = 118,
            Year = GradeLevel.SecondYear,
            ExamScores = new List<int>{ 92, 90, 83, 78}},
        new Student {FirstName = "Sven", LastName = "Mortensen", ID = 113,
            Year = GradeLevel.FirstYear,
            ExamScores = new List<int>{ 88, 94, 65, 91}},
        new Student {FirstName = "Claire", LastName = "O'Donnell", ID = 112,
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 75, 84, 91, 39}},
        new Student {FirstName = "Svetlana", LastName = "Omelchenko", ID = 111,
            Year = GradeLevel.SecondYear,
            ExamScores = new List<int>{ 97, 92, 81, 60}},
        new Student {FirstName = "Lance", LastName = "Tucker", ID = 119,
            Year = GradeLevel.ThirdYear,
            ExamScores = new List<int>{ 68, 79, 88, 92}},
        new Student {FirstName = "Michael", LastName = "Tucker", ID = 122,
            Year = GradeLevel.FirstYear,
            ExamScores = new List<int>{ 94, 92, 91, 91}},
        new Student {FirstName = "Eugene", LastName = "Zabokritski", ID = 121,
            Year = GradeLevel.FourthYear,
            ExamScores = new List<int>{ 96, 85, 91, 60}}
    };
        #endregion

        public List<Student> AddGrades(GradeCalc calc)
        {
            foreach (Student s in students)
            {
                s.Grade = calc(s.ExamScores);
            }
            return students;
        }

        public List<Student> SearchStudent(Func<Student, string, bool> select, String lastName)
        {
            List<Student> result = new List<Student>();
            foreach (Student s in students)
            {
                if (select(s, lastName)) result.Add(s);
            }
            return result;
        }

        public IEnumerable<Student> QueryPassed(Func<Student, bool> passed)
        {
            return students.What(passed);
        }

        static void show(String titel, List<Student> students)
        {
            Console.WriteLine(titel);
            foreach (var item in students)
            {
                Console.WriteLine(String.Format("{0} {1} {2}", item.FirstName, item.LastName, item.Grade));
            }
        }

        public static void Main(string[] args)
        {
            StudentClass sc = new StudentClass();
            show("Grades", sc.AddGrades(sc.gradeCalculator));
            show("\nStudent Carcia", sc.SearchStudent(sc.studentSelector, "Garcia"));
            show("\nPassed 4th", sc.QueryPassed(sc.passedSelector).ToList<Student>());
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }


    }
    public static class ListUtils
    {
        public static IEnumerable<T> What<T>(this IList<T> list, Func<T, bool> predicate)
        {
            return list.Where(predicate);
        }

        //public static IEnumerable<T>... /* TO BE DONE */
    }

}