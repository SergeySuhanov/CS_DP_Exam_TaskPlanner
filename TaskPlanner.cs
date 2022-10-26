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

        void SortEntries()
        {
            ToDoEntry swapableEntry = new ToDoEntry();
            for (int i = 0; i < toDoList.Count; i++)
            { // i - номер прохода
                for (int j = toDoList.Count - 1; j > i; j--)
                { // внутренний цикл
                  // прохода
                    if (toDoList[j - 1].DoBefore > toDoList[j].DoBefore)
                    {
                        swapableEntry = toDoList[j - 1];
                        toDoList[j - 1] = toDoList[j];
                        toDoList[j] = swapableEntry;
                    }
                }
            }
        }

        public void ShowPlans()
        {
            toDoList = loader.LoadList();
            foreach (ToDoEntry todo in toDoList)
            {
                tagDecorator.Print(todo);
            }
        }

        public void AddEntry()
        {
            toDoList = loader.LoadList();
            ToDoEntry newEntry = new ToDoEntry();
            newEntry.EditEntry();
            toDoList.Add(newEntry);
            this.SortEntries();
            loader.SaveList(toDoList);
            //tagDecorator.Print(newEntry.Tag);
        }

        public void Search()
        {
            loader.LoadList();
        }
    }
}
