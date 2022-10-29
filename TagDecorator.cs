using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DP_Exam_TaskPlanner
{
    class TagDecorator
    {
        public void ShowList(List<ToDoEntry> toDoEntries)  // Показ списка дел (всего или отобранного в поиске)
        {
            if (toDoEntries.Count == 0)  // Если поступил пустой список
            {
                Console.WriteLine("\nНет дел.");
                return;
            }

            int i = 0;
            foreach (ToDoEntry entry in toDoEntries)
            {
                Console.WriteLine($"\n # {++i}");
                Print(entry);
            }
        }

        public void Print(ToDoEntry toDoEntry)  // Отображение дела на консоли в цветном варианте в зависимости от тэга
        {
            switch (toDoEntry.Tag)
            {
                case "Работа":
                    Console.BackgroundColor = ConsoleColor.DarkCyan;  // Цвет фона
                    Console.ForegroundColor = ConsoleColor.Black;     // Цвет текста
                    break;
                case "Дом":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "Хобби":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

            // Неготово отображение с переносом длинного текста
            Console.WriteLine("{0,-40}", toDoEntry.Text);
            Console.WriteLine("{0,-40}", "");  // разделительная пустая цветная сторока
            Console.WriteLine("Приоритет:    {0,-26}", toDoEntry.Priority);
            Console.WriteLine("Выполнить до: {0,-26}", toDoEntry.DoBefore);
            Console.WriteLine("{0, 40}", $"Тег: {toDoEntry.Tag}");
            //Console.WriteLine("\n");
            Console.ResetColor();  // Сброс цвета консоли на значения по умолчанию
        }
    }
}
