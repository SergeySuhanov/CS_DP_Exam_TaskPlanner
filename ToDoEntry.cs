using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DP_Exam_TaskPlanner
{
    public class ToDoEntry
    {
        public string Text { get; set; }
        public int Priority { get; set; }
        public DateTime DoBefore { get; set; }
        public string Tag { get; set; }

        public void EditEntry()
        {
            Console.WriteLine("\tВведите текст запланированной задачи:");
            Text = Console.ReadLine();

            Console.WriteLine("\n\tЗадайте приоритет задачи в числовом формате\n\t(меньше число, выше приоритет):");
            Priority = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\n\tУкажите крайнюю дату выполнения\n\t(в формате день.месяц.год):");
            DoBefore = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\n\tВыберите тэг категории:");
            Console.WriteLine("1 - На работе");
            Console.WriteLine("2 - Домашние дела");
            Console.WriteLine("3 - Хобби");
            Console.WriteLine("4 - Без тега");
            Console.Write(" => ");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Tag = "Работа";
                    break;
                case 2:
                    Tag = "Дом";
                    break;
                case 3:
                    Tag = "Хобби";
                    break;
                default:
                    Tag = "Без тега";
                    break;
            }
        }
    }
}
