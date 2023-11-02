using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntArray obj1 = new IntArray(new int[] { 1, 2, 3, 4 });
            IntArray obj2 = new IntArray(new int[] { 2, 3 });
            Console.WriteLine("Массив: " + obj1.ToString());
            obj1++;
            Console.WriteLine("Инкрементированный массив: " + obj1.ToString());
            obj1--;
            IntArray obj3 = obj1 + obj2;
            Console.WriteLine("Массив1 (" + obj1.ToString() + ") + Массив2 (" + obj2.ToString() + ") = " + obj3.ToString());
            FileInfo file = new FileInfo(@"E:\C#\ЛР15\test file.txt");
            IntArray obj4 = new IntArray(file);
            Console.WriteLine($"Массив из файла \"{file.Name}\" : {obj4}");
            var indexes = new IntArray(obj4.FindIndexesNearAvg().ToArray());
            Console.WriteLine($"Индексы ближайшие к среднему арифметическому для массива из файла : {indexes}");
            Console.ReadLine();
        }
    }
}
