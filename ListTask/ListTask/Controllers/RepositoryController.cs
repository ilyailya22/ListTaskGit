using System;
using System.Collections.Generic;
using ListTask.Models;
using ListTask.Repository;

namespace ListTask.Controllers
{
    public class RepositoryController
    {
        private readonly IRepository _repository;

        public RepositoryController(IRepository repository)
        {
            _repository = repository;
        }

        public void Add(BaseTask task)
        {
            MainTask mainTask = new MainTask();
            if (task is MainTask)
            {
                mainTask = (MainTask)task;
                _repository.Add(mainTask);
            }

            SubTask subTask = new SubTask();
            if (task is SubTask)
            {
                subTask = (SubTask)task;
                _repository.Add(subTask);
            }
        }

        public void Delete(int id, string task)
        {
            _repository.Delete(id, task);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }

        public void Print()
        {
            _repository.Print();
        }

        public void PrintByld(int number, string task)
        {
            _repository.PrintByld(number, task);
        }

        public void Edit(int id, BaseTask task)
        {
            MainTask mainTask = new MainTask();
            if (task is MainTask)
            {
                mainTask = (MainTask)task;
                _repository.Edit(id, mainTask);
            }

            SubTask subTask = new SubTask();
            if (task is SubTask)
            {
                subTask = (SubTask)task;
                _repository.Edit(id, subTask);
            }
        }

        public void Menu()
        {
            string menu;
            do
            {
                Console.WriteLine("add\nadd-task\nadd-subtask\nprint-all\nprint\nedit\ndrop\nexit");
                menu = Console.ReadLine();
                switch (menu)
                {
                    case Constants.Addtask:
                        {
                            AddTask();
                            break;
                        }

                    case Constants.Addsubtask:
                        {
                            AddSubtask();
                            break;
                        }

                    case Constants.Printall:
                        {
                            _repository.Print();
                            break;
                        }

                    case Constants.Print:
                        {
                            PrintByld();
                            break;
                        }

                    case Constants.Edit:
                        {
                            Edit();
                            break;
                        }

                    case Constants.Delete:
                        {
                            Delete();
                            break;
                        }

                    case Constants.Drop:
                        {
                            _repository.DeleteAll();
                            break;
                        }

                    case Constants.Exit: return;

                    default: break;
                }
            }
            while (true);
        }

        private void PrintByld()
        {
            Console.WriteLine("Enter type task and number to print");
            int number;
            string task = Console.ReadLine();
            if (int.TryParse(Console.ReadLine(), out var parsenumber))
            {
                number = parsenumber;
                _repository.PrintByld(number, task);
            }
            else
            {
                Console.WriteLine("Enter correct value");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter type task and number to delete");
            int number;
            string task = Console.ReadLine();
            if (int.TryParse(Console.ReadLine(), out var parsenumber))
            {
                number = parsenumber;
                _repository.Delete(number, task);
            }
            else
            {
                Console.WriteLine("Enter correct value");
            }
        }

        private void AddTask()
        {
            try
            {
                Console.WriteLine("MainTask -- ");
                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                MainTask mainTaskobj = new MainTask();
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    mainTaskobj.Id = id;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                mainTaskobj.About = Console.ReadLine();
                if (DateTime.TryParse(Console.ReadLine(), out var datetime))
                {
                    mainTaskobj.DateAdd = datetime;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                if (DateTime.TryParse(Console.ReadLine(), out var datedead))
                {
                    mainTaskobj.DateDead = datedead;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                _repository.Add(mainTaskobj);
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
                Console.WriteLine("Enter correct value");
            }
        }

        private void AddSubtask()
        {
            try
                {
                Console.WriteLine("SubTask -- ");
                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                SubTask subTaskobj = new SubTask();
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    subTaskobj.Id = id;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                if (int.TryParse(Console.ReadLine(), out var parent))
                {
                    subTaskobj.Parent = parent;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                subTaskobj.About = Console.ReadLine();
                if (DateTime.TryParse(Console.ReadLine(), out var datetime))
                {
                    subTaskobj.DateAdd = datetime;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                if (DateTime.TryParse(Console.ReadLine(), out var datedead))
                {
                    subTaskobj.DateDead = datedead;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                _repository.Add(subTaskobj);
                }
                catch (Exception)
                {
                    Console.WriteLine(typeof(Exception));
                    Console.WriteLine("Enter correct value");
                }
        }

        private void Edit()
        {
            try
            {
                Console.WriteLine("Enter number to edit");
                int number = 0;
                if (int.TryParse(Console.ReadLine(), out var parsenumber))
                {
                    number = parsenumber;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                MainTask mainTaskobj = new MainTask();
                Console.WriteLine("MainTask -- ");
                if (int.TryParse(Console.ReadLine(), out var number1))
                {
                    mainTaskobj.Id = number1;
                }

                mainTaskobj.About = Console.ReadLine();
                if (DateTime.TryParse(Console.ReadLine(), out var datetime1))
                {
                    mainTaskobj.DateAdd = datetime1;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                if (DateTime.TryParse(Console.ReadLine(), out var datedead1))
                {
                    mainTaskobj.DateDead = datedead1;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                List<SubTask> subTasks = new List<SubTask>();
                int subid = 0;
                int subparent = 0;
                DateTime subdateadd = new DateTime(00, 00, 0000);
                DateTime subdatedead = new DateTime(00, 00, 0000);
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    subid = id;
                }

                if (int.TryParse(Console.ReadLine(), out var parent))
                {
                    subparent = parent;
                }

                if (DateTime.TryParse(Console.ReadLine(), out var datetime2))
                {
                    subdateadd = datetime2;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                if (DateTime.TryParse(Console.ReadLine(), out var datedead2))
                {
                    subdatedead = datedead2;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                subTasks.Add(new SubTask
                {
                    Id = subid,
                    Parent = subparent,
                    About = Console.ReadLine(),
                    DateAdd = subdateadd,
                    DateDead = subdatedead
                });
                mainTaskobj.Children = subTasks;
                _repository.Edit(number, mainTaskobj);
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
            }
        }
    }
}