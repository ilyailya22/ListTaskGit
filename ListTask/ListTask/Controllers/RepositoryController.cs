using System;
using System.Collections.Generic;
using ListTask;
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

        public void Add(MainTask taskRepository)
        {
            _repository.Add(taskRepository);
        }

        public void Delete(int number)
        {
            _repository.Delete(number);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }

        public void Print()
        {
            _repository.Print();
        }

        public void PrintByld(int number)
        {
            _repository.PrintByld(number);
        }

        public void Edit(int number, MainTask task)
        {
            _repository.Edit(number, task);
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
                    case Constants.Add:
                        {
                            Add();
                            break;
                        }

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
                            PrintAll();
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

        private void Add()
        {
            try
            {
                Console.WriteLine("MainTask -- ");
                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                MainTask mainTaskobj = new MainTask();
                if (int.TryParse(Console.ReadLine(), out var number1))
                {
                    mainTaskobj.Number = number1;
                }

                mainTaskobj.Id = Guid.NewGuid();
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
                Console.WriteLine("SubTask -- ");
                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                int subnumber = 0;
                DateTime subdateadd = new DateTime(00, 00, 0000);
                DateTime subdatedead = new DateTime(00, 00, 0000);
                if (int.TryParse(Console.ReadLine(), out var number2))
                {
                    subnumber = number2;
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
                    Number = subnumber,
                    Id = Guid.NewGuid(),
                    Parent = Guid.NewGuid(),
                    About = Console.ReadLine(),
                    DateAdd = subdateadd,
                    DateDead = subdatedead
                });
                mainTaskobj.Children = subTasks;
                _repository.Add(mainTaskobj);
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
                Console.WriteLine("Enter correct value");
            }
        }

        private void PrintAll()
        {
            Console.WriteLine("Enter number to print");
            int number;
            if (int.TryParse(Console.ReadLine(), out var parsenumber))
            {
                number = parsenumber;
                _repository.PrintByld(number);
            }
            else
            {
                Console.WriteLine("Enter correct value");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter number to delete");
            int number;
            if (int.TryParse(Console.ReadLine(), out var parsenumber))
            {
                number = parsenumber;
                _repository.Delete(number);
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
                if (int.TryParse(Console.ReadLine(), out var number))
                {
                    mainTaskobj.Number = number;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                mainTaskobj.Id = Guid.NewGuid();
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
                MainTask mainTaskobj = new MainTask();
                List<SubTask> subTasks = new List<SubTask>();
                int subnumber = 0;
                DateTime subdateadd = new DateTime(00, 00, 0000);
                DateTime subdatedead = new DateTime(00, 00, 0000);
                if (int.TryParse(Console.ReadLine(), out var number2))
                {
                    subnumber = number2;
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
                    Number = subnumber,
                    Id = Guid.NewGuid(),
                    Parent = Guid.NewGuid(),
                    About = Console.ReadLine(),
                    DateAdd = subdateadd,
                    DateDead = subdatedead
                });
                mainTaskobj.Children = subTasks;
                _repository.Add(mainTaskobj);
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
                mainTaskobj.Number = int.Parse(Console.ReadLine());
                mainTaskobj.Id = Guid.NewGuid();
                mainTaskobj.About = Console.ReadLine();
                mainTaskobj.DateAdd = DateTime.Parse(Console.ReadLine());
                mainTaskobj.DateDead = DateTime.Parse(Console.ReadLine());
                List<SubTask> subTasks = new List<SubTask>();
                int subnumber = 0;
                DateTime subdateadd = new DateTime(00, 00, 0000);
                DateTime subdatedead = new DateTime(00, 00, 0000);
                if (int.TryParse(Console.ReadLine(), out var number2))
                {
                    subnumber = number2;
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
                    Number = subnumber,
                    Id = Guid.NewGuid(),
                    Parent = Guid.NewGuid(),
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