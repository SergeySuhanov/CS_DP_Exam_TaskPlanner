using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DP_Exam_TaskPlanner
{
    class TagDecorator
    {
        public void Print(ToDoEntry toDoEntry)
        {
            switch (toDoEntry.Tag)
            {
                case "Work":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "Home":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "Hobby":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            Console.WriteLine(toDoEntry.Text);
            Console.WriteLine(toDoEntry.Priority);
            Console.WriteLine(toDoEntry.DoBefore);
            Console.WriteLine(toDoEntry.Tag);
            Console.WriteLine("\n");
            Console.ResetColor();


            /*foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.ForegroundColor = color;
                //Console.Clear();
                Console.WriteLine($"Foreground color set to {color}");
            }
            Console.WriteLine("=====================================");
            Console.ForegroundColor = ConsoleColor.White;
            // Let's go through all Console colors and set them as background  
            foreach (ConsoleColor color in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.BackgroundColor = color;
                Console.WriteLine($"Background color set to {color}");
            }
            Console.WriteLine("=====================================");
            // Restore original colors  
            Console.ResetColor();
            Console.ReadKey();*/
        }
    }
}
