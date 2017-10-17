using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_02
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////////////////
            /*Определение переменных примитивов*/
            /////////////////////////////////////
            byte byteValue = 128; //Целые числа от 0 до 255
            sbyte sbyteValue = -120; //Целые числа от -128 до 127
            short shortValue = -1024; //Целые числа от -32 768 до 32 767
            ushort ushortValue = 1024; //Целые числа от 0 до 65535
            int intValue = -241; //Целые числа от -2147483648 до 2147483647
            uint intValue2 = 241; //Целые числа от 0 до 4294967295

            /*Целые числа от -9223372036854&amp;amp;amp;775808 до 9223372036854775807*/
            long longValue = -45135;

            /*Целые числа от 0 до 18446744073709551615*/
            ulong longValue2 = 45135;

            /*Числа с плавающей точкой от -3,402823e38 до -3,402823e38*/
            float floatValue = 245.4F;

            /*Числа с плавающей точкой от -1,79769313486232e308 .. 1,79769313486232e308*/
            double doubleValue = -245.45;

            char charValue = 'c'; //Символ

            /*
            Тип позволяющий хранить 
            значения формата «Да/Нет» или «Истина/Ложь».
            */

            bool boolValue = true; //Переменная в значении «Да(Истина)»
            bool otherBoolValue = false; //Переменная в значении «Нет(Ложь)»

            //////////////////////
            /*Неявное приведение*/
            //////////////////////

            uint a = 1;
            long b = a;
            float c = a;
            double d = a;
            decimal e = a;

            ////////////////////
            /*Явное приведение*/
            ////////////////////

            double x = 1234.7;
            int ag;
            uint bg;
            long cg;
            float dg;
            decimal eg;

            ag = (int)x;
            bg = (uint)x;
            cg = (long)x;
            dg = (float)x;
            eg = (decimal)x;

            //////////////////////////////////////
            /*Упаковка/распаковка значимых типов*/
            //////////////////////////////////////

            int xab = 10;
            Object orange = xab; //Упаковка xab'а
            byte m = (byte)(int)orange; //Распаковка, затем приведение типа

            /////////////////////
            /*Работа с Nullable*/
            /////////////////////

            int? x1 = null;
            int? x2 = null;
            System.Console.Write(x1 == x2);//True
            
            //////////////////////
            /*Работа со строками*/
            //////////////////////

            string t = "qqq sasasasas sa";//Строковый литерал t
            string f = "qqa sasasasas sa";//Строковый литерал f
            System.Console.WriteLine(t == f);//False

            string stroka;
            stroka = t + f;//Сцепление
            System.Console.WriteLine(stroka);
            stroka = t;//Копирование

            /////////////
            /*Сабстрока*/
            /////////////

            string s = "aaaaabbbcccccccdd";
            char charRange = 'b';
            int startIndex = s.IndexOf(charRange);
            int endIndex = s.LastIndexOf(charRange);
            int length = endIndex - startIndex + 1;
            Console.WriteLine("{0}.Substring({1}, {2}) = {3}",
                              s, startIndex, length,
                              s.Substring(startIndex, length));

            //////////////////////////////
            /*Разделение строки на слова*/
            //////////////////////////////

            string value = "This is a short string.";
            char delimiter = 's';
            string[] substrings = value.Split(delimiter);
            foreach (var substring in substrings)
                Console.WriteLine(substring);          

            ////////////////////////////////////////
            /*Вставка подстроки в заданную позицию*/
            ////////////////////////////////////////

            string original = "aaabbb";
            Console.WriteLine("The original string: '{0}'", original);
            string modified = original.Insert(3, " ");
            Console.WriteLine("The modified string: '{0}'", modified);

            ///////////////////////////////
            /*Удаление заданной подстроки*/
            ///////////////////////////////

            string sa = "abc---def";
            Console.WriteLine("1)     {0}", s);
            Console.WriteLine("2)     {0}", s.Remove(3));
            Console.WriteLine("3)     {0}", s.Remove(3, 3));
            /*1)     abc---def
              2)     abc
              3)     abcdef
            */

            ///////////////
            /*NULL строки*/
            ///////////////

            string saa = "";
            string baa = saa + sa;
            System.Console.WriteLine(saa == sa);//False
            
            ////////////////
            /*SringBuilder*/
            ////////////////

            StringBuilder sb = new StringBuilder("ABCD", 25);
            sb.Insert(0, "Letters: ");
            sb.Append(", it is all");
            sb.Remove(2, 2);
            Console.WriteLine($"______");

            ////////////////////
            /*Двумерный массив*/
            ////////////////////

            /*var names = new[] { new { Name = "John", Age = 50 },
            new { Name = "Diana", Age = 50 },
            new { Name = "James", Age = 23 },
            new { Name = "Francesca", Age = 21 } };
            foreach (var familyMember in names)
            {
                Console.WriteLine($"Name: {familyMember.Name}, Age: {familyMember.Age}");
            }*/
            int[,] items = new int[2, 2];
            items[0, 0] = 1;
            items[0, 1] = 2;
            items[1, 0] = 3;
            items[1, 1] = 4;
            Console.WriteLine($"{items[0, 0]} {items[0, 1]}");
            Console.WriteLine($"{items[1, 0]} {items[1, 1]}");
            Console.WriteLine($"______");
            
            ///////////////////////////
            /*Одномерный массив строк*/
            ///////////////////////////

            string[] smass = { "one", "two", "three", "four", "five" };
            foreach (string el in smass)
                Console.Write(el + " ");
            Console.WriteLine();
            Console.WriteLine(smass.Length);
            Console.Write("Enter a word (from the list above) you want to replace:");
            string massString1 = Console.ReadLine();
            Console.Write("Enter a word you want to replace with:");
            string massString2 = Console.ReadLine();
            foreach (string el in smass)
                Console.Write(el.Replace(massString1, massString2) + " ");
            Console.WriteLine();

            //////////////////////
            /*Ступенчатый массив*/
            //////////////////////

            double[][] stmass = {
                new double[2],
                new double[3],
                new double[4]
            };

            

            foreach (double[] sx in stmass)
            {
                foreach (double sy in sx)
                {
                    Console.Write("\t" + sy);
                }
                Console.WriteLine();

                
            }

            ////////////////////////////////////
            /*Неявно типизированные переменные*/
            ////////////////////////////////////

            var mass = new[] { 1, 2, 3 };                     // implicit for massive
            foreach (var i1 in mass)
            {
                Console.Write(i1);
            }
            Console.WriteLine();

            var massstr = new[] { "1a", "2b", "3c" };                     // implicit for string
            foreach (var i1 in massstr)
            {
                Console.Write(i1);
            }
            Console.WriteLine();

            //////////////////////////////////
            /*Кортеж с именованием элементов*/
            //////////////////////////////////

            (string a1, string a2, string a3, ulong a4, int a5, char a6) name = ("oh", "my", "god", 15, 1, 'p');  // tuple with naming

            ////////////////////////////////////////
            /*Вывод кортежа на консоль и выборочно*/
            ////////////////////////////////////////

            Console.WriteLine(name.GetType().Name);
            Console.WriteLine($" {name}");                   // tuple output                   
            Console.WriteLine(name.a1 + " " + name.a3 + " " + name.a4);         // selective output

            ///////////////////////////////////
            /*Распаковка кортежа в переменные*/
            ///////////////////////////////////

            var (first, second, thrird, four, five, six) = name;
            Console.WriteLine(second);

            //////////////////////
            /*Сравнение кортежей*/
            //////////////////////

            var t1 = ValueTuple.Create(500, "avg");
            var t2 = ValueTuple.Create(500, 'a');
            Console.WriteLine(t1.Equals(t2));

            ////////////////////////////
            /*Локальная функция в main*/
            ////////////////////////////

            Tuple<double, double, double, char> local_function(double[] massiv, string temp)
            {
                double min, max;
                min = max = massiv[0];

                for (int step = 1; step < massiv.Length; step++)
                {
                    if (massiv[step] < min)
                    {
                        min = massiv[step];

                    }
                    else if (massiv[step] > max)
                    {
                        max = massiv[step];
                    }
                }
                double sum = min + max;
                char ch = ((char)temp[0]);
                return Tuple.Create<double, double, double, char>(max, min, sum, ch);
            }
            double[] elements = { 0, 1, 2, 4, 0, 7, 8 };
            var new_tuple = local_function(elements, "string");
            Console.WriteLine(new_tuple.Item3.ToString());

        }

    }

}
