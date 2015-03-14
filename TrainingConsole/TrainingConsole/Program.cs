using MyToolKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;

namespace TrainingConsole
{
    class Program
    {
        class Link
        {
            private string LinkName = "";
            private string LinkMethodName = "";
            public Link(string LinkNamePassed, string LinkMethodNamePassed)
            {
                LinkName = LinkNamePassed;
                LinkMethodName = LinkMethodNamePassed;
            }
            public string GetLinkName { get { return LinkName; } }
            public string GetLinkMethodName { get { return LinkMethodName; } }
        }
        static void Main(string[] args)
        {
            #region Set Console window size and color

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(180, 60);
            Console.Clear();

            #endregion

            List<Link> LinkOptions = new List<Link>();
            // Link object accepts a Link name and a Method Name for that link
            LinkOptions.Add(new Link("Shuffle List", "Test_Shuffle_List"));
            LinkOptions.Add(new Link("Collection vs List Speed", "Test_Collection_Vs_List_Speed"));
            LinkOptions.Add(new Link("Console.Read()", "Test_Console_Read"));
            LinkOptions.Add(new Link("Console.ReadKey()", "Test_Console_ReadKey"));
            LinkOptions.Add(new Link("String Formatting", "Test_String_formatting"));
            LinkOptions.Add(new Link("Param With Object", "Test_Param_With_Object"));
            LinkOptions.Add(new Link("DataTime Behaviours", "Test_System_DateTime"));

            int InputChoiceNum = 0;
            bool loop = true;
            string InputChoiceEntered = "";
            
            Type type = typeof(Program);
            string promptString = "Enter choice num [x - End]: ";
            while (loop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nProgram Options\n");
                Console.ForegroundColor = ConsoleColor.Black;
                
                for (int i = 0; i < LinkOptions.Count; i++)
                    Console.WriteLine("{0}. {1}", i + 1, LinkOptions[i].GetLinkName);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.Write(promptString);
                Console.ForegroundColor = ConsoleColor.Black;
                InputChoiceEntered = Console.ReadLine();

                if (InputChoiceEntered.ToLower() == "x")
                    loop = false;
                else
                {
                    if ((int.TryParse(InputChoiceEntered, out InputChoiceNum)) && InputChoiceNum > 0 && InputChoiceNum <= LinkOptions.Count)
                    {
                        string MethodName = LinkOptions[InputChoiceNum-1].GetLinkMethodName;
                        Console.WriteLine();
                        MethodInfo info = type.GetMethod(MethodName);
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Method Name: {0}\n", MethodName);
                        Console.ForegroundColor = ConsoleColor.Black;
                        info.Invoke(null, null);
                        promptString = "Enter choice num [x - End]: ";
                        Console.Write("\nPress ENTER to continue...");
                        Console.ReadLine();
                    }
                    else
                        promptString = "Wrong, enter choice num [x - End]: ";
                }
            }

        }
        public static void Test_System_DateTime()
        {
            string title = "";
            DateTime dt = new DateTime();
            Console.WriteLine("{0,-20}{1,-20}","new DateTime() ", dt.ToString());

            Console.WriteLine("{0,-20}{1,-20}", "DateTime.MinValue", DateTime.MinValue);
            Console.WriteLine("{0,-20}{1,-20}", "DateTime.Maxvalue ", DateTime.MaxValue);
            Console.WriteLine("{0,-20}{1,-20}", "DateTime.Now ", DateTime.Now);

            Console.WriteLine();
            Console.WriteLine("{0,-35}{1,-20}", "DateTime.Now.ToShortDateString() ", DateTime.Now.ToShortDateString());
            Console.WriteLine("{0,-35}{1,-20}", "DateTime.Now.ToShortTimeString() ", DateTime.Now.ToShortTimeString());
            Console.WriteLine("{0,-35}{1,-20}", "DateTime.Now.ToString(\"yyyy-MMM-dd\") ", DateTime.Now.ToString("yyyy-MMM-dd"));
            
            Console.WriteLine();
            Console.WriteLine("More info available at MSDN: Search for DateTimeFormatInfo Class. Also GetAllDateTimePatterns.");

            Console.WriteLine();
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.DayOfYear ", DateTime.Now.DayOfYear);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Year ", DateTime.Now.Year);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Month ",  DateTime.Now.Month);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Day ", DateTime.Now.Day);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.DayOfWeek ", DateTime.Now.DayOfWeek);

            Console.WriteLine();
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.TimeOfDay", DateTime.Now.TimeOfDay);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Hour ", DateTime.Now.Hour);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Minute ", DateTime.Now.Minute);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Second ", DateTime.Now.Second);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Millisecond ", DateTime.Now.Millisecond);
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.Ticks ", DateTime.Now.Ticks);

            Console.WriteLine();
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.AddDays(2) ", DateTime.Now.AddDays(2));
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.AddDays(-2) ", DateTime.Now.AddDays(-2));
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.AddSeconds(100) ", DateTime.Now.AddSeconds(100));
            Console.WriteLine("{0,-30}{1,-20}", "DateTime.Now.AddSeconds(-100) ", DateTime.Now.AddSeconds(-100));

            Console.WriteLine();
            Console.WriteLine("{0,-35}{1,-20}", "DateTime.IsLeapYear(2015) ", DateTime.IsLeapYear(2015));
            Console.WriteLine("{0,-35}{1,-20}", "DateTime.Now.ToUniversalTime() ", DateTime.Now.ToUniversalTime());

        }
        public static void Test_Param_With_Object()
        {
            ParamTest ParamTestObj = new ParamTest();
            ParamTestObj.MethodWithParam("Hello", 2, 2.0, 4f);
        }
        public static void Test_Shuffle_List()
        {
            // Shuffle List
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("List of int with digits 1-5. Shuffle or Randamize number and print. Looped 5 times.\n");
            Console.ForegroundColor = ConsoleColor.Black;

            List<int> numList = new List<int>() { 1, 2, 3, 4, 5 };
            ShuffleTool<int> myShuffleTool = new ShuffleTool<int>();
            for (int i = 0; i < 5; i++)
            {
                numList = myShuffleTool.list(numList);
                foreach (int a in numList)
                    Console.Write(a + " ");
                Console.WriteLine();
            }

        }
        public static void Test_String_formatting()
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

            // Padding
            Console.WriteLine();
            // Number specifies padding. 
            // A positive number means to right-align.
            // A negative number means to left-align.
            Console.WriteLine("{0,-10}{1,-10}","Name", "Age");
            Console.WriteLine("{0,-10} {1,-10}", "Raj", "30");
            Console.WriteLine("{0,-10} {1,-10}", "Ben", "35");
            Console.WriteLine("{0,-10} {1,-10}", "Cate", "34");

        }
        public static void Test_Beep()
        {
            // Sound Test: Beep sound for Console
            // Different frequencies
            for (int i = 37; i <= 32767; i += 200)
            {
                Console.Beep(i, 100);
            }

        }
        public static void Test_Recursive()
        {
            Console.Write("Hello World");
            for (int i = 0; i < 5; i++)
                Test_Recursive();
        }
        public static void Test_Console_ReadKey()
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
            Console.WriteLine("Keypress Detail from ConsoleKeyInfo:\n");
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
        public static void Test_Console_Read()
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
        public static void Test_Collection_Vs_List_Speed()
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

    class ParamTest
    {
        public void MethodWithParam(params object[] UserInput)
        {
            foreach (var i in UserInput)
            {
                if(i.GetType().ToString() == "System.Double")
                    Console.Write("{0:0.0} ",i);
                else
                Console.Write("{0} ",i );

                Console.WriteLine("is a Typeof {0}", i.GetType());
            }
        }
    }
}
