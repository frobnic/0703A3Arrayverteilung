using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0703A3Arrayverteilung
{
    class Program
    {
        static void FillArrayWithRandomNumbers(int[] TheArray, int NumOfElements, int Min, int Max)
        {
            Random zuf = new Random();

            for (int i = 0; i < NumOfElements; i++)
                TheArray[i] = zuf.Next(Min, Max+1);  //+1, weil random.Next die obergrenze nicht umfasst!
        }

        static int[,] GetFrequencyArray(int[] TheArray)
        {
            int max = 0;
            int cnt = 0;

            for (int i = 0; i < TheArray.Length; i++)
                if (TheArray[i] > max)
                    max = TheArray[i];

            int[] freq = new int[max+1];

            foreach (int a in TheArray)
            {
                freq[a]++;
            }

            foreach (int a in freq)
                if (a > 0)
                    cnt++;

            int[,] f = new int[cnt, 2];

            int j = 0;
            for (int i=0; i < freq.Length; i++)
                if (freq[i] != 0) {
                    f[j, 0] = i;
                    f[j, 1] = freq[i];
                    j++;
                }

            return f;
        }

        static void PrintArray(int[] TheArray)
        {
            foreach (int a in TheArray)
                Console.Write("{0} ", a);
            Console.WriteLine();
        }

        static void PrintFrequencyArray(int[] TheArray)
        {
            int[,] f = GetFrequencyArray(TheArray);

            for (int i=0; i < f.Length/2; i++)
                Console.WriteLine("{0} {1}", f[i, 0], f[i, 1]);

        }

        static void Main(string[] args)
        {
            int[] zahlen;
            int anzahl;
            int unten, oben;

            Console.Write("Wieviele Zahlen möchten Sie generieren? (1-100)");
            anzahl = int.Parse(Console.ReadLine());

            Console.Write("Bitte geben Sie die Untergrenze an: ");
            unten = int.Parse(Console.ReadLine());

            Console.Write("Bitte geben Sie die Obergrenze an: ");
            oben = int.Parse(Console.ReadLine());

            zahlen = new int[anzahl];

            Console.WriteLine("Zufallszahlen werden erzeugt");
            FillArrayWithRandomNumbers(zahlen, anzahl, unten, oben);

            Console.WriteLine("Folgendes Zahlen wurden gespeichert:");
            PrintArray(zahlen);

            Console.WriteLine("");
            Console.WriteLine("Die Verteilung auf Zeichenklassen:");
            PrintFrequencyArray(zahlen);


        }
    }
}
