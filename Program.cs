using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Laba9
{
    internal class Program
    {
        static MarkArray AboveAverageMark(MarkArray m)
        {
            uint count = 0;
            double summary = 0;
            double average = 0;
             
            for (int i = 0; i < m.Length; i++)
            {
                summary = summary + m[i].MarkLimit;              
            }
            average = summary / m.Length;
            Console.WriteLine($"Средняя оценка по всем дисциплинам: {average}");            
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i].MarkLimit > average)
                {
                    count++; 
                }
            }
            Console.WriteLine($"Количество дисциплин с оценкой выше средней: {count}");
            string[] arrName = new string[count];
            uint[] arrMark = new uint[count];
            int j = 0;
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i].MarkLimit > average)
                {
                    arrName[j] = m[i].NameLimit;
                    arrMark[j] = m[i].MarkLimit;
                    j++;
                }
            }
            
            MarkArray aboveAverageSubjects = new MarkArray(count, arrName, arrMark);
            return aboveAverageSubjects;
        }
        static void Main(string[] args)
        {
            /*
            Mark m1 = new Mark();
            IO.PrintInf(m1);
            IO.PrintMark(m1);
            Mark m2 = new Mark("Программирование", 10);
            IO.PrintInf(m2);
            IO.PrintMark(m2);
            Console.WriteLine("Объект #3");
            Mark m3 = new Mark(IO.InputSubject(), IO.InputMark());               
            //IO.PrintInf(m3);
            IO.PrintMark(m3);
            IO.PrintMarkk(m3);
            bool mark = m3;
            Console.WriteLine($"Оценка по дисциплине не меньше 4? Ответ: {mark}");
            Console.WriteLine($"Название дисциплины заглавными буквами: {(!m3).NameLimit}"); // заглавными буквани название дисциплины
            //Mark zeromark = new Mark(Mark m3);
            Console.WriteLine($"После обнуления оценка по дисциплине: {(-m3).MarkLimit}"); // обнуление оценки
            int number = (int)m3;
            Console.WriteLine($"Количество буквенных символов в названии дисциплины: {number}");            
           
            Console.WriteLine("Введите новое название дисциплины, которое заменит предыдущее название: ");
            string newName = Console.ReadLine();
            Console.WriteLine($"Новое название дисциплины: {(m3 / newName).NameLimit}");

            Console.WriteLine("Объект #4");
            Mark m4 = new Mark("Проектный семинар", 5);
            IO.PrintInf(m4);
            Console.WriteLine("Создайте новый объект");
            Mark m5 = new Mark(IO.InputSubject(), IO.InputMark());
            IO.PrintInf(m5);
            Console.WriteLine($"Оценка по первому предмету не меньше второй? Ответ: {m4 >= m5}");
            Console.WriteLine($"Оценка по первому предмету не больше второй? Ответ: {m4 <= m5}");
            */
            Console.WriteLine("Объект #6");
            Console.WriteLine("Конструктор без параметров");
            MarkArray m6 = new MarkArray();
            m6.PrintArray();
            Console.WriteLine("Конструктор с параметрами, случайные значения");
            MarkArray m7 = new MarkArray(10);            
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
                arrName[i] = IO.InputSubject();
                arrMark[i] = IO.InputMark();
            }
            Console.WriteLine("Конструктор с параметрами, значения с клавиатуры");
            MarkArray m8 = new MarkArray(length, arrName, arrMark);
            Console.WriteLine("Объект #8");
            m8.PrintArray();
            Console.WriteLine("Конструктор копирования");
            MarkArray m9 = new MarkArray(m8);
            Console.WriteLine("Объект #9");
            m9.PrintArray();
            m8[0] = new Mark("Программирование", 10);
            Console.WriteLine($"Новый элемент коллекции под номером 1: {m8[0].NameLimit} {m8[0].MarkLimit}");
            Console.WriteLine("Объект #8");
            m8.PrintArray();
            Console.WriteLine("Объект #9");
            m9.PrintArray();
            Console.WriteLine("Выполнено глубокое копирование");
            try
            {
                m8[50] = new Mark("Проектный семинар", 6);
                Console.WriteLine($"Элемент коллекции под номером 50: {m8[50].NameLimit} {m8[50].MarkLimit}");
                m8.PrintArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //Дисциплины с оценкой выше средней
            MarkArray aboveAverageMark = AboveAverageMark(m9);
            if (aboveAverageMark.Length != 0)
            {
                Console.WriteLine("Дисциплины с оценкой выше средней: ");
                Console.WriteLine("Название дисциплины | Оценка за дисциплину");
                for (int i = 0; i < aboveAverageMark.Length; i++)
                {
                    Console.Write(aboveAverageMark[i].NameLimit + " | ");
                    Console.WriteLine(aboveAverageMark[i].MarkLimit);
                }
            }
                   
            //Console.WriteLine($"Количество созданных объектов: {Mark.count}");
            //Console.WriteLine($"Количество созданных коллекций: {MarkArray.count}");
        }
    }
}
