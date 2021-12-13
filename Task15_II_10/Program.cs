﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Task15_II_10
{
    class main
    {
        struct Employee
        {
            public string name, lastname, otch, dolzh, year, pay, exp;
            public Employee(string name, string lastname, string otch, string year, string dolzh, string pay, string exp)
            {
                this.name = name;
                this.lastname = lastname;
                this.otch = otch;
                this.year = year;
                this.dolzh = dolzh;
                this.pay = pay;
                this.exp = exp;
            }
        }
        public static void Main()
        {
            StreamReader filein = new StreamReader("input.txt");
            int n = int.Parse(filein.ReadLine());
            List<Employee> list = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] text = filein.ReadLine().Split(" ");
                list.Add(new Employee(text[0], text[1], text[2], text[3], text[4], text[5], text[6]));
            }
            var Sorted =
            from x in list
            orderby x.name
            orderby x.lastname
            orderby x.otch
            select x;
            var query =
            from student in Sorted
            group student by student.dolzh;
            using (StreamWriter fileout = new StreamWriter("output.txt"))
            {
                foreach (var items in query)
                {
                    Console.Write("Группа {0}: ", items.Key);
                    foreach (var item in items)
                    {
                        Console.Write("{0} ", item.name);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
