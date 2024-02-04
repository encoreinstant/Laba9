using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Laba9
{
    internal class Program
    {
        static double AboveAverageMark(MarkArray m)
        {
            int count = 0;
            double summary = 0;
            for (int i = 0; i < m.Length; i++)
            {
                summary = summary + m[i].MarkLimit;              
            }
            summary = summary / m.Length;
            for (int i = 0; i < m.Length; i++)
            {
                if (summary < m[i].MarkLimit)
                {
                    count++; 
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            Mark m1 = new Mark();
            IO.PrintInf(m1);
            IO.PrintMark(m1);
            Mark m2 = new Mark("Программирование", 10);
            IO.PrintInf(m2);
            IO.PrintMark(m2);
            Mark m3 = new Mark(IO.InputSubject(), IO.InputMark());               
            //IO.PrintInf(m3);
            IO.PrintMark(m3);
            IO.PrintMarkk(m3);
            bool mark = m3;
            Console.WriteLine($"Оценка по дисциплине не меньше 4? Ответ: {mark}");
            Console.WriteLine($"Название дисциплины заглавными буквами {!m3}"); // заглавными буквани название дисциплины
            //Mark zeromark = new Mark(Mark m3);
            Console.WriteLine($"После обнуления оценка по дисциплине: {-m3}"); // обнуление оценки
            int number = (int)m3;
            Console.WriteLine($"Количество буквенных символов в названии дисциплины: {number}");            
            
            Console.WriteLine("Введите новое название дисциплины: ");
            string newName = Console.ReadLine();
            Console.WriteLine($"Новое название дисциплины: {m3 / newName}");
            Mark m4 = new Mark("Проектный семинар", 5);
            IO.PrintInf(m4);
            Console.WriteLine("Создайте новый объект");
            Mark m5 = new Mark(IO.InputSubject(), IO.InputMark());
            IO.PrintInf(m5);
            Console.WriteLine($"Первая оценка не меньше второй? Ответ: {m4 >= m5}");
            Console.WriteLine($"Первая оценка не больше второй? Ответ: {m4 <= m5}");

            Console.WriteLine("----------------------------------");

            
            Console.WriteLine("Конструктор с параметрами, случайные значения");
            MarkArray m6 = new MarkArray(10);            
            m6.PrintArray();
            Console.WriteLine("Конструктор без параметров");
            MarkArray m7 = new MarkArray();
            m7.PrintArray();


            
            Console.WriteLine("Введите длину массива: ");
            bool isCorrectInput;
            string buf;
            uint length;
            do
            {
                buf = Console.ReadLine();
                isCorrectInput = uint.TryParse(buf, out length);
                if (!isCorrectInput || !(length >= 1 && length <= 100))
                {
                    Console.WriteLine("Ошибка! Введите целое число от 1 до 100");
                    Console.Write("Введите длину массива: ");
                }
            } while (!isCorrectInput || !(length >= 1 && length <= 100));
            string[] arrName = new string[length];
            uint[] arrMark = new uint[length];

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Введите название дисциплины: ");
                string name = Console.ReadLine();
                arrName[i] = name;
                Console.WriteLine("Введите оценку по дисциплине: ");
                uint markk = uint.Parse(Console.ReadLine());
                arrMark[i] = markk;
            }
            Console.WriteLine("Конструктор с параметрами, значения с клавиатуры");
            MarkArray m8 = new MarkArray(length, arrName, arrMark);
            Console.WriteLine("1 объект");
            m8.PrintArray();
            Console.WriteLine("Конструктор копирования");
            MarkArray m9 = new MarkArray(m8);
            Console.WriteLine("2 объект");
            m9.PrintArray();
            m8[0] = new Mark("Программирование", 10);
            Console.WriteLine("1 объект");
            m8.PrintArray();
            Console.WriteLine("2 объект");
            m9.PrintArray();

            try
            {
                m8[50] = new Mark("Проектный семинар", 6);
                m8.PrintArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("Количество дисциплин с оценкой выше средней: ");
            Console.WriteLine(AboveAverageMark(m8));


            Console.WriteLine($"Количество созданных объектов: {Mark.count}");
            Console.WriteLine($"Количество созданных коллекций: {MarkArray.count}");
        }
    }
}
