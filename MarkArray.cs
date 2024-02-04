using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public class MarkArray
    {
        static Random rnd = new Random();
        Mark[] arr;
        static public int count = 0;
        public int Length
        {
            get => arr.Length;
        }

        public MarkArray()
        {
            arr = new Mark[1];
            arr[0] = new Mark();
            count++;
        }
        public MarkArray(int length) // конструктор с параметром (рандомные значения)
        {
            arr = new Mark[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = new Mark("noName", (uint)rnd.Next(10));
            }
            count++;
        }
        public MarkArray(uint length, string[] arrName, uint[] arrMark)
        {
            arr = new Mark[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = new Mark(arrName[i], arrMark[i]);
            }
            count++;
        }
        public MarkArray(MarkArray other)
        {
            arr  = new Mark[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                arr[i] = new Mark(other.arr[i]);
            }
            count++;
        }
        public Mark this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];
                else
                    throw new Exception("Индекс выходит за пределы коллекции");
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else
                    Console.WriteLine("Индекс выходит за пределы коллекции");
            }
        }

        public void PrintArray()
        {
            Console.WriteLine("Название дисциплины / Оценка за дисциплину");
            for (int i = 0;i < arr.Length;i++) 
            {
                Console.Write(arr[i].NameLimit + " ");
                Console.WriteLine(arr[i].MarkLimit);
            }
        }
    }
}
