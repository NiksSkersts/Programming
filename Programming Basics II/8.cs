using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _8_uzd_it19055
{
    public struct Reg_worker
    {
        public int ID;
        public string name;
        public string surname;
        public int amount_of_children;
        public string rank;
        public bool work_load;

        public void Input()
        {
            Console.Write("Input ID: ");
            ID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input name: ");
            name = Console.ReadLine();

            Console.Write("Input surname: ");
            surname = Console.ReadLine();

            Console.Write("Input amount of Children: ");
            amount_of_children = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input rank: ");
            rank = Console.ReadLine();

            Console.Write("Input work load, where true == full: ");
            work_load = Convert.ToBoolean(Console.ReadLine());
        }

        public void output()
        {
            Console.WriteLine(string.Format("{0,10}{1,10}{2,10}{3,20}{4,10}{5,10}", "", "", "", "", "", ""));
            Console.WriteLine(string.Format("{0,10}{1,10}{2,10}{3,20}{4,10}{5,10}", ID, name, surname,
                amount_of_children, rank, work_load));
        }

        public static void output_w(int ID, Reg_worker[] worker)
        {
            for (var i = 0; i < worker.Length; i++)
                if (worker[i].ID == ID)
                {
                    Console.WriteLine("Results: ");
                    Console.WriteLine(string.Format("{0,10}{1,10}{2,10}{3,20}{4,10}{5,10}", "ID", "Name", "Surname  ",
                        "Amount of Children", "Rank", "Workload"));
                    worker[i].output();
                }
        }

        public static void Main()
        {
            var worker_index = 0;
            Reg_worker[] workers;
            workers = new Reg_worker[10];

            var break_switch = false;
            do
            {
                Console.WriteLine("Choose and Option:  ");


                Console.WriteLine("1 - Add a worker");
                Console.WriteLine("2 - Output Workers on display");
                Console.WriteLine("3 - find and output a worker");
                Console.WriteLine("4 - Exit ");

                Console.Write("your choice: ");
                var choice = Convert.ToInt32(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        workers[worker_index] = new Reg_worker();
                        Console.WriteLine("Please input information about the Worker {0}", worker_index + 1);
                        Console.WriteLine();
                        workers[worker_index].Input();
                        worker_index++;
                        break;
                    case 2:
                        Console.WriteLine(string.Format("{0,10}{1,10}{2,10}{3,20}{4,10}{5,10}", "ID", "Name", "Surname",
                            "Amount of Children", "Rank", "Workload"));
                        for (var i = 0; i < worker_index; i++) workers[i].output();
                        break;
                    case 3:
                        Console.Write("Input ID : ");
                        var Used_ID = Convert.ToInt32(Console.ReadLine());
                        output_w(Used_ID, workers);
                        break;
                    case 4:
                        break_switch = true;
                        break;
                }
            } while (break_switch == false);
        }
    }
}