using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    class Program
    {
        static int[] low = new int[10];
        static int[] medium = new int[10];
        static int[] high = new int[10];
        static int[] counter = new int[10]; //decided that for testing purposes 10 is the ideal amount of users

        static void Main(string[] args)
        {
            try
            {
                int testy= 0;
                int iron ;
                string test = "";
                bool isOK = false, isInRange;
                double mark;
                do
                {


                    Console.Write("Please input the Iron level : ");
                    iron = int.Parse(Console.ReadLine());
                    isOK = double.TryParse(test, out mark);      //checks if can be made an int      
                    isInRange = (mark > 0 && mark <= 1501);      //checks if it is within range
                    if (iron == -999 || testy == 10)
                    {
                        break; //makes it break so the programme does not loop infitely
                    }
                    else if (iron < 65)
                    {
                        counter[testy] = iron;
                        low[testy] = counter[testy];
                    }
                    else if (iron >= 65 && iron <= 165)
                    {
                        counter[testy] = iron;
                        medium[testy] = counter[testy];
                    }
                    else if (iron > 165)
                    {
                        counter[testy] = iron;
                        high[testy] = counter[testy];
                    }

                    testy++;
                }
                while (iron != -999);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine(" Error - no marks entered ");
            }

            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Quota of marks exceeded");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
            }
            Output();
        }
        static void Output()
        {
            int totallow = 0;
            int totalmed = 0;
            int totalhigh = 0;
            for (int i = 0; i < counter.Length; i++)
            {
                totallow = totallow + low[i];
                totalmed = totalmed + medium[i];
                totalhigh = totalhigh + high[i];
            }
            int lowTest =0 ;
            int medTest = 0;
            int highTest = 0;
            for (int i = 0; i < counter.Length; i++)
            {
                if (low[i] != 0)
                    lowTest++;
                if (medium[i] != 0)
                    medTest++;
                if (high[i] != 0)
                    highTest++;
            }
            int totLowTest = lowTest;
            int totmedTest = medTest;
            int tothighTest = highTest;
            double averageLow = totallow / totLowTest;
            double averageMed = totalmed / totmedTest;
            double averagehigh = totalhigh / tothighTest;
            int lowCosts = totLowTest * 50;
            int medCosts = totmedTest * 0;
            int highCosts = tothighTest * 100;
            int totalTests = totLowTest+totmedTest+tothighTest;
            int totalIron = totalhigh + totallow + totalmed;
            double overallAverage = totalIron / totalTests;
            int totalCosts = lowCosts + medCosts + highCosts;

            Console.WriteLine(" Iron Level Range \t No of tests \t Total Iron level \t Average Iron Level \t Treatment cost");
            Console.WriteLine(" <65 \t\t \t {0} \t\t {1} \t\t\t {2} \t\t\t {3}", totLowTest, totallow, averageLow,lowCosts);
            Console.WriteLine(" 65-165\t\t\t {0} \t\t {1} \t\t\t {2} \t\t\t {3}",totmedTest,totalmed, averageMed, medCosts);
            Console.WriteLine(" <165\t\t \t {0} \t\t {1} \t\t\t {2} \t\t\t {3}",tothighTest,totalhigh,averagehigh,highCosts);
            Console.WriteLine(" Total number of tests    \t {0}", totalTests);
            Console.WriteLine(" Total of all Iron levels \t {0}", totalIron);
            Console.WriteLine(" Overall Average \t \t {0}", overallAverage);
            Console.WriteLine(" Total Treatment costs \t \t{0}", totalCosts);
        }
    }
}
