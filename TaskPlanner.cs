using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_DP_Exam_TaskPlanner
{
    class TaskPlanner
    {
        List<ToDoEntry> toDoList;
        XMLParser loader;
        TagDecorator tagDecorator;

        public TaskPlanner(List<ToDoEntry> list, XMLParser parser, TagDecorator renderer)
        {
            toDoList = list;
            loader = parser;
            tagDecorator = renderer;
        }

        void SortEntries()  // Пузырьковая сортировка по сроку выполнения
        {
            ToDoEntry swapableEntry = new ToDoEntry();
            for (int i = 0; i < toDoList.Count; i++)
            {
                for (int j = toDoList.Count - 1; j > i; j--)
                {
                    if (toDoList[j - 1].DoBefore > toDoList[j].DoBefore)
                    {
                        swapableEntry = toDoList[j - 1];
                        toDoList[j - 1] = toDoList[j];
                        toDoList[j] = swapableEntry;
                    }
                }
            }
        }

        void ShowFooter()
        {
            Console.Write("\n нажмите Enter для продолжения");
            Console.ReadLine();
        }

        public void ShowPlans()  // Показ всего списка дел
        {
            Console.Clear();
            toDoList = loader.LoadList();
            tagDecorator.ShowList(toDoList);
            ShowFooter();
        }

        public void AddEntry()  // Добавление новой задачи в список дел
        {
            Console.Clear();
            toDoList = loader.LoadList();
            ToDoEntry newEntry = new ToDoEntry();
            newEntry.EditEntry();
            toDoList.Add(newEntry);
            this.SortEntries();
            loader.SaveList(toDoList);
            Console.WriteLine("Запись добавлена!");
            ShowFooter();
        }

        public void DeleteEntry()
        {
            Console.Clear();
            toDoList = loader.LoadList();
            this.ShowPlans();

            int index;
            do  // лучше переделать с try-catch
            {
                Console.WriteLine("Введите номер записи, которую нужно удалить:");
                index = Int32.Parse(Console.ReadLine());
                --index;
                if (index > toDoList.Count || index < 0)
                    Console.WriteLine("Указано недействительное значение");
            } while (index > toDoList.Count || index < 0);

            toDoList.RemoveAt(index);
            Console.WriteLine("Запись удалена!");
            loader.SaveList(toDoList);
            ShowFooter();
        }

        public void SearchEntry()
        {
            Console.Clear();
            toDoList = loader.LoadList();
            List<ToDoEntry> foundList = new List<ToDoEntry>();

            Console.WriteLine("\tВыберите категорию поиска:");
            Console.WriteLine("1 - по дате");
            Console.WriteLine("2 - по тэгу");
            Console.WriteLine("3 - по приоритету");
            Console.Write(" => ");
            int catChoice = Int32.Parse(Console.ReadLine());

            
            switch (catChoice)
            {
                case 1:  // По Дате
                    Console.WriteLine("\tПоказ дел для завершения до конкретной даты");
                    Console.WriteLine("Введите контрольную дату (в формате день.месяц.год (время опционально)):");
                    DateTime deadLine = DateTime.Parse(Console.ReadLine());
                    foreach (ToDoEntry entry in toDoList)
                    {
                        if (entry.DoBefore <= deadLine)
                        {
                            foundList.Add(entry);
                        }
                    }
                    break;
                case 2:  // По Тэгу
                    Console.WriteLine("Выберите тэг:");
                    Console.WriteLine("1 - Работа");
                    Console.WriteLine("2 - Дом");
                    Console.WriteLine("3 - Хобби");
                    Console.WriteLine("4 - Без тэга");
                    Console.Write(" => ");
                    int tagChoice = Int32.Parse(Console.ReadLine());
                    string askedTag = "";
                    switch (tagChoice)
                    {
                        case 1:
                            askedTag = "Работа";
                            break;
                        case 2:
                            askedTag = "Дом";
                            break;
                        case 3:
                            askedTag = "Хобби";
                            break;
                        default:
                            askedTag = "Без тега";
                            break;
                    }
                    foreach (ToDoEntry entry in toDoList)
                    {
                        if (entry.Tag == askedTag)
                            foundList.Add(entry);
                    }
                    break;
                case 3:  // По приоритету
                    Console.Write("Введите приоритет: ");
                    int priorChoice = Int32.Parse(Console.ReadLine());
                    foreach (ToDoEntry entry in toDoList)
                    {
                        if (entry.Priority == priorChoice)
                            foundList.Add(entry);
                    }
                    break;
                default:
                    break;
            }

            tagDecorator.ShowList(foundList);
            ShowFooter();
        }
    }
}
