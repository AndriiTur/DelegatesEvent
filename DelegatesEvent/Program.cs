using System;
using System.Collections.Generic;

namespace DelegatesEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TaskHW10_1
            //Tabulation(Sinus, 1, 10, 5);
            //Console.WriteLine();

            //Tabulation(Function, 1, 10, 5);

            //Console.ReadKey();
            #endregion

            #region TaskHW10_2
            Student vasia = new Student();
            Parent vasiaParent = new Parent();
            Accounting babaKatya = new Accounting();
            vasia.MarkChange += new MyDel(vasiaParent.OnMarkChange);
            vasia.MarkChange += new MyDel(babaKatya.PaymentScholarship);

            vasia.addMark(5);
            vasia.addMark(10);
            vasia.addMark(20);
            vasia.addMark(50);

            Console.ReadKey();
            #endregion
        }

        #region TakHW10_1 Delegate&methods
        public delegate double Funct(double x);

        public static double Sinus(double x)
        {
            return Math.Sin(x);
        }

        public static double Function(double x)
        {
            //return Math.Pow(2 * x, 2) + 3 * x * Math.Cos(Math.Pow(x, 3);
            return ((2 * x) * (2 * x)) + 3 * x * Math.Cos(x * x * x);
        }

        public static void Tabulation(Funct fun, double a, double b, int n)
        {
            for (int k = 0; k < n; k++)
            {
                double result = a + k * (b - a) / n;
                Console.WriteLine($"{result}    {fun(result)}");
            }
        }
        #endregion
    }
    public delegate void MyDel(int m);

    class Student
    {
        private string name;
        private static List<int> marks = new List<int>();

        public static List<int> Marks { get => marks; set => marks = value; }

        public event MyDel MarkChange;

        public void addMark(int m)
        {
            Marks.Add(m);
            if (MarkChange != null)
            {
                MarkChange(m);
            }
        }
    }

    class Parent
    {
        public void OnMarkChange(int m)
        {
            Console.WriteLine($"I am in OnMarkChange and rating = {m}");
        }
    }

    class Accounting
    {
        public void PaymentScholarship(int m)
        {
            if (m < 10)
            {
                Console.WriteLine("Student don't have scholarship");
            }
            else
            {
                Console.WriteLine("Student has a scholarship");
            }
        }
    }
}
