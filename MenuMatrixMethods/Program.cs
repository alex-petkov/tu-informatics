using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise9A
{
    class Program
    {
        // Да се състави програма с меню със следните възможности:
        // 1. Въвеждане на матрица nxn, 0<n<1000 с елементи от
        //    тип десетична дроб (decimal)
        // 2. Извеждане на сумата на елементите по главния ѝ
        //      диагонал (a[1,1], a[2,2],...,a[n,n])
        // 3. Намиране на стойността на най-малкия елемент по
        //      вторичния ѝ диагонал (a[1,n], a[2,n-1],...,a[n,1])
        // 4. Проверка дали матрицата е диагонална (всички елементи
        //    освен тези от главния диагонал, са нули)
        // 0. Изход
        // Командите от менюто да бъдат реализирани в самостоятелни
        // функции. Ако не е въведена матрица, опциите от менюто
        // (освен първата) да изписват съобщение
        // "Моля първо въведете матрица".
        static void Main(string[] args)
        {
            decimal[,] matrix = null;
            int choice;
            do
            {
                Console.WriteLine("\n1. Въвеждане на матрица");
                Console.WriteLine("2. Сума на главния диагонал");
                Console.WriteLine("3. Най-малък елемент от вторичния диагонал");
                Console.WriteLine("4. Проверка за диагонална матрица");
                Console.WriteLine("0. Изход");

                choice = ReadInt("Изберете команда: ");

                switch(choice)
                {
                    case 1:
                        matrix = ReadMatrix();
                        break;
                    case 2:
                        PrintMainDiagSum(matrix);
                        break;
                    case 3:
                        PrintAntidiagMin(matrix);
                        break;
                    case 4:
                        PrintIfDiagonal(matrix);
                        break;
                }
            }
            while (choice != 0);
        }

        static decimal[,] ReadMatrix()
        {
            int n = ReadInt("n=");
            var m = new decimal[n, n];
            for (int i = 0; i < n; ++i)
            {
                var row = ReadString("Ред " + (i + 1) + ": ");
                var colStrings = row.Split();
                for (int k = 0; k < n; ++k)
                    m[i, k] = decimal.Parse(colStrings[k]);
            }
            return m;
        }

        static void PrintMainDiagSum(decimal[,] m)
        {
            if(m == null)
            {
                Console.WriteLine("Моля първо въведете матрица");
                return;
            }
            decimal sum = 0;
            for (int i = 0; i < m.GetLength(0); ++i)
                sum += m[i, i];
            Console.WriteLine("Сума по главния диагонал: {0}", sum);
        }

        static void PrintAntidiagMin(decimal[,] m)
        {
            if (m == null)
            {
                Console.WriteLine("Моля първо въведете матрица");
                return;
            }
            var n = m.GetLength(0);
            decimal min = m[0,n-1];
            for (int i = 1; i < n; ++i)
                if (m[i, n - 1 - i] < min)
                    min = m[i, n - 1 - i];
            Console.WriteLine("Мин. елемент по вторичния диагонал: {0}",
                min);
        }

        static void PrintIfDiagonal(decimal[,] m)
        {
            if (m == null)
            {
                Console.WriteLine("Моля първо въведете матрица");
                return;
            }
            var n = m.GetLength(0);
            bool diagonal = true;
            for (int i = 0; i < n; ++i)
            {
                for (int k = 0; k < n; ++k)
                    if (i != k && m[i, k] != 0)
                    {
                        diagonal = false;
                        break;
                    }
                if (!diagonal)
                    break;
            }

            if (diagonal)
                Console.WriteLine("Матрицата е диагонална.");
            else
                Console.WriteLine("Матрицата не е диагонална");
        }

        static int ReadInt(string prompt)
        {
            bool isValid;
            int input;

            do
            {
                Console.Write(prompt);
                isValid = int.TryParse(Console.ReadLine(),
                    out input);
                if (!isValid)
                    Console.WriteLine("Моля въведете цяло число.");
            }
            while (!isValid);

            return input;
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
