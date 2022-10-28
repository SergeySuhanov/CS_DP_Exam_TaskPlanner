using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DP_Exam_TaskPlanner
{
    class TagDecorator
    {
        public void Print(ToDoEntry toDoEntry)  // Отображение дела на консоли в цветном варианте в зависимости от тэга
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

            // Неготово отображение с переносом длинного текста и цветным прямоугольником
            Console.WriteLine(toDoEntry.Text);
            Console.WriteLine(toDoEntry.Priority);
            Console.WriteLine(toDoEntry.DoBefore);
            Console.WriteLine(toDoEntry.Tag);
            Console.WriteLine("\n");
            Console.ResetColor();
        }
    }
}
