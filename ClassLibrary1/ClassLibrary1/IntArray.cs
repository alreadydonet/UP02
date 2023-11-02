using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ClassLibrary1
{    
    public class IntArray
    {
        private int[] array;
        public int Length { get { return array.Length; } }
        private int min = 0, max = 100;
        public ArgumentException argumentException = new ArgumentException("Длина массива не может быть отрицательной");
        public FileLoadException fileLoadException = new FileLoadException("Некорректный файл");
        public IntArray(Random random, int length)
        {
            if (length < 0)
                throw argumentException;
            array = new int[length];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }
        }
        public IntArray(Random random, int minimum, int maximum, int length)
        {
            int min = minimum <= maximum ? minimum : maximum;
            int max = minimum < maximum ? maximum : minimum;
            if (length < 0)
                throw argumentException;
            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(min, max);
            }
        }
        public IntArray(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                array = new int[0];
            }
            else
            {
                array = arr;               
            }
        }
        public IntArray(IntArray obj)
        {
            array = obj.array.ToArray();
        }
        public IntArray(FileInfo file)
        {
            try
            {
                string fileText = File.ReadAllText(file.FullName);
                string[] strings = fileText.Split(';',' ','\n');
                List<int> arr = new List<int>();
                for (int i = 0; i < strings.Length; i++)
                {          
                    if (strings[i].Length == 0)
                        continue;
                    arr.Add(int.Parse(strings[i]));
                }
                array = arr.ToArray();
            }
            catch 
            {
                throw fileLoadException;
            }
        }       
        public override bool Equals(object obj)
        {
            if (obj is IntArray elem && array.SequenceEqual(elem.array))
            {
                return true;
            }
            else
            {
                return false;
            }   
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }           
        public override string ToString()
        {
            string result = "";
            for(int i=0; i < array.Length; i++)
            {
                result += $"{array[i]}; ";
            }
            result = result.Remove(result.Length - 2);            
            result += ".";
            return result;
        }
        public void FillInTable(DataGridView table)
        {
            table.RowCount = 1;
            table.ColumnCount = array.Length;
            for (int i=0; i < array.Length; i++)
            {
               table.Rows[0].Cells[i].Value = array[i];
            }
        }
        public int Sum()
        {
            int sum = 0;
            foreach(int elem in array)
            {
                sum += elem;
            }
            return sum;
        }
        public int Sum(int index1, int index2)
        {
            if(index1 < 0 || index2 >= array.Length || index1 >= index2)
            {
                throw new IndexOutOfRangeException();
            }
            int sum = 0;
            for(int i = index1; i < index2; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < array.Length)
                {
                    return array[index];
                }
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < array.Length)
                {
                    array[index] = value;
                }
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public static IntArray operator ++(IntArray obj)
        {  
            for(int i=0; i < obj.Length; i++)
            {
                obj[i]++;
            }
            return obj;
        }
        public static IntArray operator --(IntArray obj)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i]--;
            }
            return obj;
        }
        public static IntArray operator +(IntArray obj1, IntArray obj2)
        {           
            IntArray SmallerLenghtArr = obj1.Length <= obj2.Length ? new IntArray(obj1) : new IntArray(obj2);
            IntArray BiggerLenghtArr = obj1.Length > obj2.Length ? new IntArray(obj1) : new IntArray(obj2);
            for (int i = 0; i < SmallerLenghtArr.Length; i++)
            {
                BiggerLenghtArr[i] += SmallerLenghtArr[i];
            }
            return BiggerLenghtArr;
        }
        public static IntArray operator -(IntArray obj1, IntArray obj2)
        {
            IntArray SmallerLenghtArr = obj1.Length <= obj2.Length ? new IntArray(obj1) : new IntArray(obj2);
            IntArray BiggerLenghtArr = obj1.Length > obj2.Length ? new IntArray(obj1) : new IntArray(obj2);
            for (int i = 0; i < SmallerLenghtArr.Length; i++)
            {
                BiggerLenghtArr[i] -= SmallerLenghtArr[i];
            }
            return BiggerLenghtArr;
        }
        public static IntArray operator +(IntArray baseObj, int a)
        {
            IntArray obj = new IntArray(baseObj);
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i] = obj[i] + a;
            }
            return obj;
        }
        public static IntArray operator -(IntArray baseObj, int a)
        {
            IntArray obj = new IntArray(baseObj);
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i] = obj[i] - a;
            }
            return obj;
        }
        public List<int> FindIndexesNearAvg()
        {
            List<int> indexes = new List<int>();
            double avg = Sum() / (double)Length;
            double minDelta = double.MaxValue;
            foreach (double elem in array)
            {
                double delta = Math.Abs(elem - avg);
                if (delta < minDelta)
                    minDelta = delta;
            }
            for(int i = 0; i < array.Length; i++)
            {
                double delta = Math.Abs(array[i] - avg);
                if(delta == minDelta)
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }               
    }
}
