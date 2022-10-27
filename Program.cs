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
            TaskPlanner planner = new TaskPlanner();
            //planner.AddEntry();
            planner.ShowPlans();


            Console.ReadLine();
        }
    }
}
