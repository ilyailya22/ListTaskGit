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

        public void Delete(int id, TaskType taskType)
        {
            _repository.Delete(id, taskType);
        }

        public void DeleteAll()
        {
            _repository.DeleteAll();
        }

        public void PrintByld(int number, TaskType taskType)
        {
            _repository.PrintByld(number, taskType);
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
            do
            {
                Console.WriteLine("Enter what need to do");
                Console.WriteLine("for add maintask - add-task\nFor add subtask - add-subtask\nFor print any task - print\nFor edit task - edit\nFor delete task - delete\ndrop\nexit - exit");
                string menu = Console.ReadLine();
                Console.Clear();
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
            Console.WriteLine("Enter type task maintask or subtask and number to print");
            int number;
            string task = Console.ReadLine();
            TaskType taskType = TaskType.NoTask;
            if (task == "maintask")
            {
                taskType = TaskType.MainTask;
            }

            if (task == "subtask")
            {
                taskType = TaskType.SubTask;
            }

            if (int.TryParse(Console.ReadLine(), out var parsenumber))
            {
                number = parsenumber;
                _repository.PrintByld(number, taskType);
            }
            else
            {
                Console.WriteLine("Enter correct value");
            }
        }

        private void Delete()
        {
            Console.WriteLine("Enter type task maintask or subtask and number to delete");
            int number;
            string task = Console.ReadLine();
            TaskType taskType = TaskType.NoTask;
            if (task == "maintask")
            {
                taskType = TaskType.MainTask;
            }

            if (task == "subtask")
            {
                taskType = TaskType.SubTask;
            }

            if (int.TryParse(Console.ReadLine(), out var parsenumber))
            {
                number = parsenumber;
                _repository.Delete(number, taskType);
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