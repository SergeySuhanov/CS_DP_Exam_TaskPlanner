using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CS_DP_Exam_TaskPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskPlanner planner = new TaskPlanner(new List<ToDoEntry>(), new XMLParser(), new TagDecorator());

            bool inMenuLvl1 = true;
            while (inMenuLvl1)
            {
                Console.Clear();
                Console.WriteLine("\tПЛАНИРОВЩИК ЗАДАНИЙ\n");

                Console.WriteLine("\tВыберите действие:\n");

                Console.WriteLine("1 - Показать весь список дел");
                Console.WriteLine("2 - Добавить новую запись");
                Console.WriteLine("3 - Удалить запись");
                Console.WriteLine("4 - Найти определённый тип дел");
                Console.WriteLine("0 - Выйти из программы");
                int menuLvl1Choice = Int32.Parse(Console.ReadLine());

                switch (menuLvl1Choice)
                {
                    case 1:
                        planner.ShowPlans();
                        break;
                    case 2:
                        planner.AddEntry();
                        break;
                    case 3:
                        planner.DeleteEntry();
                        break;
                    case 4:
                        planner.SearchEntry();
                        break;
                    case 0:
                        inMenuLvl1 = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
