using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Laba9
{
    //Определение класса Mark
    public class Mark
    {
        string name;
        uint mark;
        static public int count = 0;
        public uint MarkLimit
        {
            get => mark;
            set
            {
                if (value >= 0 && value <= 10)
                {
                    mark = value;                
                }
                else
                {
                    //throw new Exception("Оценка может быть от 0 до 10");
                    Console.WriteLine("Оценка может быть от 0 до 10");
                    mark = 0;
                }
            }
        }
        public string NameLimit
        {
            get => name;
            set
            {
                if (value.Length > 0)
                {
                    name = value;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("Недопустимое название дисциплины!");
                        Console.WriteLine("Введите название предмета: ");
                        value = Console.ReadLine();
                    } while (value.Length == 0);
                    name = value;
                }
            }
        }
        

        public Mark()
        {
            name = "noName";
            MarkLimit = 0;
            count++;
        }
        public Mark(string name, uint mark )
        {
            NameLimit = name;
            MarkLimit = mark;
            count++;
        }
        public Mark(Mark m)
        {
            NameLimit = m.name;
            MarkLimit = m.mark;
            count++;
        }
        
        public string Transfer()
        {
            string mark5;
            if (MarkLimit < 4)
            {
                mark5 = "Неудовлетворительно";
            }
            else if (MarkLimit < 6)
            {
                mark5 = "Удовлетворительно";
            }
            else if (MarkLimit < 8)
            {
                mark5 = "Хорошо";
            }
            else
            {
                 mark5 = "Отлично";
            }
            return mark5;
        }

        static public string Transf(Mark m)
        {
            string mark5;
            if (m.MarkLimit < 4)
            {
                mark5 = "Неудовлетворительно";
            }
            else if (m.MarkLimit < 6)
            {   
                mark5 = "Удовлетворительно";
            }
            else if (m.MarkLimit < 8)
            {
                mark5 = "Хорошо";
            }
            else
            {
                mark5 = "Отлично";
            }
            return mark5;
        }

        public static string operator !(Mark m)
        {
            return m.name.ToUpper();
        }
        public static uint operator -(Mark m)
        {
            Mark copy_m = new Mark(m);
            copy_m.mark = 0;
            return copy_m.mark;
        }

        public static explicit operator int(Mark m)
        {
            int count = 0;
            for (int i = 0; i < m.name.Length; i++) 
            {
                if (Char.IsLetter(m.name[i]))
                {
                    count++;
                }
            }
            return count;
        }

        public static implicit operator bool(Mark m)
        {
            return m.mark >= 4;
        }
        public static string operator /(Mark m, string newName)
        {
            Mark copy_m = new Mark(m);
            copy_m.name = newName;
            return copy_m.name;
        }
        public static bool operator >=(Mark m1, Mark m2)
        {
            return m1.mark >= m2.mark;
        }
        public static bool operator <=(Mark m1, Mark m2)
        {
            return m1.mark <= m2.mark;
        }
        public static double operator +(double m1, Mark m2)
        {
            return m1 + m2.mark;
        }
    }
}
