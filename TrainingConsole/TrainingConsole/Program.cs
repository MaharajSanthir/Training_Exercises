using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MyToolKit;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace TrainingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Set Console window size and color

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(180, 60);
            Console.Clear();

            #endregion

            // Shuffle List
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("List of int with digits 1-5. Shuffle or Randamize number and print. Looped 5 times.\n");
            Console.ForegroundColor = ConsoleColor.Black;

            List<int> numList = new List<int>() { 1, 2, 3, 4, 5 };
            ShuffleTool<int> myShuffleTool = new ShuffleTool<int>();
            for (int i = 0;i < 5; i++)
            {
                numList = myShuffleTool.list(numList);
                foreach (int a in numList)
                    Console.Write(a + " ");
                Console.WriteLine();
            }

            // Speedtest - Collection vs List
            Console.WriteLine();

            Test_Collection_Vs_List_Speed();
            Console.WriteLine();

            //recursive();

            Test_Console_Read();
            Test_Console_ReadKey();
            Test_String_formatting();
        }

        static void Test_String_formatting()
        {
            // String Test: Formatting
            // Formatt for currency
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("String Formatting.\n\n");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\nThe number 82.53 is displayed here with string format as {0:C}.\n", 82.53);
            // Display values formarting for decimal points and date formating for year month etc.
            string value1 = "The int 10 and datetime 2001/12/25 is displayed here with string.format as:";
            int value2 = 10;
            DateTime value3 = new DateTime(2001, 12, 25);
            string result = string.Format("{0} {1:0.0} - {2:yyyy}", value1, value2, value3);
            Console.WriteLine(result);
            Console.WriteLine("(Note decimal point for int and only year displayed from datetime)");
            // Console.WriteLine uses string.format
            double percentageTest = 0.73;
            Console.WriteLine("\nThe number 0.73 is display here as: {0:0.0%}", percentageTest);
            Console.WriteLine("(Percentage symbol with 0.0 added to string.format would multiplies the number by 100)");
        }
        static void Test_Beep()
        {
            // Sound Test: Beep sound for Console
            // Different frequencies
            for (int i = 37; i <= 32767; i += 200)
            {
                Console.Beep(i, 100);
            }

        }
        static void Test_Recursive()
        {
            Console.Write("Hello World");
            for (int i = 0; i < 5; i++)
                Test_Recursive();
        }
        static void Test_Console_ReadKey()
        {
            // Input Test: Console.Key()
            // Returns result immidiatly without waiting for end of line input.
            // Returns a ConsoleKeyInfo data type, therefore it needs to be handled.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Console.Key Behaviour.\n\n");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("Test1 - Console.ReadKey():");
            ConsoleKeyInfo Test1 = Console.ReadKey();
            Console.WriteLine("\nReturns: " + Test1);
            Console.WriteLine();

            // Parameter set to true: Hides the input in the screen 
            Console.Write("Test2 - Console.ReadKey(true):");
            ConsoleKeyInfo Test2 = Console.ReadKey(true);
            Console.WriteLine("\nReturns: " + Test2);
            Console.WriteLine();

            // Parameter set to false (default): show the input in the screen 
            Console.Write("Test3 - Console.ReadKey(false):");
            ConsoleKeyInfo Test3 = Console.ReadKey(false);
            Console.WriteLine("\nReturns: " + Test3);
            Console.WriteLine();

            // Display Detailed contents of the keypresses
            Console.WriteLine("Keypress Detail from ConsoleKeyInfo");
            Console.WriteLine("Test 1");
            Console.WriteLine("Test1.Key: " + Test1.Key);
            Console.WriteLine("Test1.KeyChar: " + Test1.KeyChar);
            Console.WriteLine("Test1.Modifiers: " + Test1.Modifiers);
            Console.WriteLine();
            Console.WriteLine("Test 2");
            Console.WriteLine("Test2.Key: " + Test2.Key);
            Console.WriteLine("Test2.KeyChar: " + Test2.KeyChar);
            Console.WriteLine("Test2.Modifiers: " + Test2.Modifiers);
            Console.WriteLine();
            Console.WriteLine("Test 3");
            Console.WriteLine("Test3.Key: " + Test3.Key);
            Console.WriteLine("Test3.KeyChar: " + Test3.KeyChar);
            Console.WriteLine("Test3.Modifiers: " + Test3.Modifiers);
            Console.WriteLine();
        }
        static void Test_Console_Read()
        {
            // Input Test: Console.Read()
            // Code follows this is test the console.read behaviour.
            // Looped 5 times for 5 charactors. If you enter less than 5 charactor,
            // the final two characters displayed (13 and 10) are equal to the Windows newline.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nConsole.Read() Behaviour \n\n");
            Console.ForegroundColor = ConsoleColor.Black;

            int result = 0;
            Console.Write("Enter Input:");
            for (int i = 0; i < 5; i++)
            {
                result = Console.Read();
                Console.WriteLine("{0} = {1}", result, (char)result);
            }
            
        }
        static void Test_Collection_Vs_List_Speed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Collection vs List - Speed Test\n");
            Console.ForegroundColor = ConsoleColor.Black;

            List<long> l = new List<long>();
            Stopwatch s2 = new Stopwatch();
            s2.Start();
            for (long i = 0; i <= 10000000; i++)
            {
                l.Add(i);
            }
            s2.Stop();
            Console.WriteLine("List - Elapsed Milliseconds:" + s2.ElapsedMilliseconds.ToString());

            Collection<long> c = new Collection<long>();
            Stopwatch s = new Stopwatch();
            s.Start();
            for (long i = 0; i <= 10000000; i++)
            {
                c.Add(i);
            }
            s.Stop();
            Console.WriteLine("Collection - Elapsed Milliseconds:" + s.ElapsedMilliseconds.ToString());

        }
    }
}

namespace MyToolKit{

    class ShuffleTool<T>
    {
        public List<T> list(List<T> ListPassed) // Shuffle a List of T type 
        {
            System.Random r = new System.Random();
            for (int currentIndex = 0; currentIndex < ListPassed.Count; currentIndex++)
            {
                int randomIndex = r.Next(ListPassed.Count);
                T SavedValue = ListPassed[randomIndex];
                ListPassed[randomIndex] = ListPassed[currentIndex];
                ListPassed[currentIndex] = SavedValue;
            }
            return ListPassed;
        } 
    }
}
