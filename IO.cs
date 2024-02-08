using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba9
{
    public class IO
    {
        static public string InputSubject()
        {
            Console.WriteLine("Введите название дисциплины: ");
            string name = Console.ReadLine();
            return name;
        }
        static public uint InputMark()
        {
            Console.WriteLine("Введите оценку по дисциплине: ");
            bool isCorrectInput;
            string buf;
            uint mark;
            buf = Console.ReadLine();
            isCorrectInput = uint.TryParse(buf, out mark);
            if (isCorrectInput)
            {
                return mark;
            }
            else
            {
                Console.WriteLine("Неправильный ввод оценки");
                Console.WriteLine($"Текущая оценка по дисциплине: 0");
                return 0;
            }
                
        }
        static public void PrintInf(Mark m)
        {
            Console.WriteLine($"Название предмета: {m.NameLimit}");
            Console.WriteLine($"Оценка по десятибалльной шкале: {m.MarkLimit}");
        }
        
        static public void PrintMark(Mark m)
        {
            Console.WriteLine($"Оценка в пятибальной системе: {m.Transfer()}");
        }
        static public void PrintMarkk(Mark m)
        {
            Console.WriteLine($"Оценка в пятибальной системе: {Mark.Transf(m)}");
        }

    }
}
