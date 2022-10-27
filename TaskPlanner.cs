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

        public TaskPlanner()
        {
            toDoList = new List<ToDoEntry>();
            loader = new XMLParser();
            tagDecorator = new TagDecorator();
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

        public void ShowPlans()  // Показ всего списка дел
        {
            toDoList = loader.LoadList();
            int i = 0;
            foreach (ToDoEntry todo in toDoList)
            {
                Console.WriteLine($"# {++i}");
                tagDecorator.Print(todo);
            }
        }

        public void AddEntry()  // Добавление новой задачи в список дел
        {
            toDoList = loader.LoadList();
            ToDoEntry newEntry = new ToDoEntry();
            newEntry.EditEntry();
            toDoList.Add(newEntry);
            this.SortEntries();
            loader.SaveList(toDoList);
        }

        public void DeleteEntry()
        {
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
            loader.SaveList(toDoList);
        }
    }
}
