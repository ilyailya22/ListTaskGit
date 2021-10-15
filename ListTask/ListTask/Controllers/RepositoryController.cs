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
            if (task is MainTask mainTask)
            {
                _repository.Add(mainTask);
                return;
            }

            if (task is SubTask subTask)
            {
                _repository.Add(subTask);
            }
        }

        public void Delete(int id, int task)
        {
            _repository.Delete(id, task);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }

        public void PrintByld(int number, int task)
        {
            _repository.PrintByld(number, task);
        }

        public void Edit(int id, BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                _repository.Edit(id, mainTask);
            }

            if (task is SubTask subTask)
            {
                _repository.Edit(id, subTask);
            }
        }

        public void Menu()
        {
            int menu = 0;
            do
            {
                Console.WriteLine("Enter what need to do");
                Console.WriteLine("for add maintask - 0\nFor add subtask -1\nFor print any task - 2\nFor edit task - 3\nFor delete task - 4\ndrop\nexit - 6");
                if (int.TryParse(Console.ReadLine(), out var intmenu))
                {
                    menu = intmenu;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                Console.Clear();
                switch (menu)
                {
                    case (int)Constants.Addtask:
                        {
                            AddTask();
                            break;
                        }

                    case (int)Constants.Addsubtask:
                        {
                            AddSubtask();
                            break;
                        }

                    case (int)Constants.Print:
                        {
                            PrintByld();
                            break;
                        }

                    case (int)Constants.Edit:
                        {
                            Edit();
                            break;
                        }

                    case (int)Constants.Delete:
                        {
                            Delete();
                            break;
                        }

                    case (int)Constants.Drop:
                        {
                            _repository.DeleteAll();
                            break;
                        }

                    case (int)Constants.Exit: return;

                    default: break;
                }
            }
            while (true);
        }

        private void PrintByld()
        {
            Console.WriteLine("Enter type task 7 - mainTask, 8 - subTask and number to print");
            int number;
            int task = 0;
            if (int.TryParse(Console.ReadLine(), out var inttask))
            {
                task = inttask;
            }
            else
            {
                Console.WriteLine("Enter correct value");
            }

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
            Console.WriteLine("Enter type task 7 - mainTask, 8 - subTask and number to delete");
            int number;
            int task = 0;
            if (int.TryParse(Console.ReadLine(), out var inttask))
            {
                task = inttask;
            }
            else
            {
                Console.WriteLine("Enter correct value");
            }

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
                Console.WriteLine("MainTask -- ");
                Console.WriteLine("Enter Id, Name, About task, Date addition and Date end");
                MainTask mainTaskobj = new MainTask();
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    mainTaskobj.Id = id;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                mainTaskobj.Name = Console.ReadLine();
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

        private void AddSubtask()
        {
            try
                {
                Console.WriteLine("SubTask -- ");
                Console.WriteLine("Enter Id, Name, About task, Date addition and Date end");
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

                subTaskobj.Name = Console.ReadLine();
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
                Console.WriteLine("Enter Id, Name, About task, Date addition and Date end");
                if (int.TryParse(Console.ReadLine(), out var id))
                {
                    mainTaskobj.Id = id;
                }
                else
                {
                    Console.WriteLine("Enter correct value");
                }

                mainTaskobj.Name = Console.ReadLine();
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

                _repository.Edit(number, mainTaskobj);
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
            }
        }
    }
}