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
        Editor editor;
        TagDecorator tagDecorator;

        public void AddEntry()
        {
            editor.LoadList();
            ToDoEntry newEntry = new ToDoEntry();
            tagDecorator.Print(newEntry.Tag);
        }

        public void Search()
        {
            editor.LoadList();
        }
    }

    class ToDoEntry
    {
        public string Text { get; set; }
        public int Priority { get; set; }
        public DateTime DoBefore { get; set; }
        public string Tag { get; set; }

        public ToDoEntry()
        {

        }
    }

    class Editor
    {
        public void LoadList() { }
    }

    class TagDecorator
    {
        public void Print(string type) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
