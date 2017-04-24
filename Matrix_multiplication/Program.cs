using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter w = new StreamWriter("Matrix multiplication.txt");//This file will be in ConsoleApp\bin\Debug...            
            Console.WriteLine("The number of rows in matrix A:");
            int strokaA = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The number of columns in matrix A:");
            int stolbecA = Convert.ToInt32(Console.ReadLine());
            w.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            w.WriteLine("Matrix A:");
            Console.WriteLine("Matrix A:");
            w.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            int razmMasA = strokaA * stolbecA;
            int[,] MasA = new int[strokaA, stolbecA];
            Random rA = new Random();
            for (int i = 0; i < MasA.GetLength(0); i++)
            {
                for (int j = 0; j < MasA.GetLength(1); j++)
                {
                    MasA[i, j] = rA.Next(-2 * razmMasA, 2 * razmMasA);//Array elements ranges from -2*n to 2*n
                    w.Write("{0,6:0}", MasA[i, j]);
                    Console.Write("{0,6:0}", MasA[i, j]);
                }
                w.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------------------------------");
            int stolbecB;
            int strokaB;
            do
            {
                Console.WriteLine("The number of rows in matrix В:");
                strokaB = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The number of columns in matrix В:");
                stolbecB = Convert.ToInt32(Console.ReadLine());
                if (MasA.GetLength(1) != strokaB)
                {
                    Console.WriteLine("Invalid input! The number of columns of the matrix A should be equal to the number of rows of the matrix B!");
                }
            }
            while (MasA.GetLength(1) != strokaB);
            w.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            w.WriteLine("Matrix В:");
            Console.WriteLine("Matrix В:");
            w.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            int[,] MasB = new int[strokaB, stolbecB];
            int o = 0;
            for (int i = 0; i < MasB.GetLength(0); i++)
            {
                for (int j = 0; j < MasB.GetLength(1); j++)
                {
                    MasB[i, j] = razmMasA - o;
                    o = o + 2;//Размерность массива от -2*n до 2*n
                    w.Write("{0,6:0}", MasB[i, j]);
                    Console.Write("{0,6:0}", MasB[i, j]);
                }
                w.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();
            int[,] MasC = new int[MasA.GetLength(0), MasB.GetLength(1)];
            w.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            w.WriteLine("The multiplication result is A * B = C. Matrix C:");
            Console.WriteLine("The multiplication result is A * B = C\nMatrix C:");
            w.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("-------------------------------------------------------------------------------");
            {
                int razmMasC = MasA.GetLength(0) * MasB.GetLength(1);
                for (int i = 0; i < MasA.GetLength(0); i++)
                {
                    for (int j = 0; j < MasB.GetLength(1); j++)
                    {
                        for (int k = 0; k < MasB.GetLength(0); k++)
                        {
                            MasC[i, j] += MasA[i, k] * MasB[k, j];
                        }
                    }
                }
                for (int i = 0; i < MasA.GetLength(0); i++)
                {
                    for (int j = 0; j < MasB.GetLength(1); j++)
                    {
                        w.Write("{0,6:0}", MasC[i, j]);
                        Console.Write("{0,6:0}", MasC[i, j]);
                    }
                    w.WriteLine();
                    Console.WriteLine();
                }
                w.Close();
                Console.WriteLine("Press any key for exit");
                Console.ReadLine();
            }
        }
    }
}
