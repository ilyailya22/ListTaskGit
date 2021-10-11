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
                            /*                         string jsonString =
                                                        @"{""tasks"" : [
                                                         ""id"" : ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
                               ""name"" : ""Create mock api"",
                               ""about"" : ""Generate mock api call"",
                               ""dateAdd"" : ""2021-09-28T21:30:00"",
                               ""dateDeadline"" : ""2021-10-10T21:10:00"",
                               ""children"" : [
                                                         ""id"": ""dc787b7f-f0d5-4b73-9b75-2099f62c60d0"",
                                   ""parent"": ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
                                   ""name"": ""Create mock api for get"",
                                   ""about"": ""Generate mock api for get call"",
                                   ""dateAdd"": ""2021-09-28T21:30:00"",
                                   ""dateDeadline"": ""2021-10-10T21:10:00""
                                              ]
                                                                       ]
                         }
                         ";
                                                     MainTaskJson mainTaskRepository =
                                                     JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                                                     MainTask mainTaskobj = new MainTask();
                                                     foreach (var i in mainTaskRepository.Task)
                                                     {
                                                         mainTaskobj = i;
                                                     }*/

                            // _repository.Add(mainTaskobj);
                            try
                            {
                                Console.WriteLine("MainTask -- ");
                                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                                MainTask mainTaskobj = new MainTask();
                                mainTaskobj.Number = int.Parse(Console.ReadLine());
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

                                List<SubTask> subTasks = new List<SubTask>();
                                Console.WriteLine("SubTask -- ");
                                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                                subTasks.Add(new SubTask
                                {
                                    Number = int.Parse(Console.ReadLine()),
                                    Id = Guid.NewGuid(),
                                    Parent = Guid.NewGuid(),
                                    About = Console.ReadLine(),
                                    DateAdd = DateTime.Parse(Console.ReadLine()),
                                    DateDead = DateTime.Parse(Console.ReadLine())
                                });
                                mainTaskobj.Children = subTasks;
                                _repository.Add(mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                                Console.WriteLine("Enter correct value");
                            }

                            break;
                        }

                    case Constants.Addtask:
                        {
                            /*string jsonString =
                             @"{""tasks"" : [
                             ""id"" : ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
   ""name"" : ""Create mock api"",
   ""about"" : ""Generate mock api call"",
   ""dateAdd"" : ""2021-09-28T21:30:00"",
   ""dateDeadline"" : ""2021-10-10T21:10:00""
]
}
";
                         MainTaskJson mainTaskRepository =
                         JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                         MainTask mainTaskobj = new MainTask();
                         foreach (var i in mainTaskRepository.Task)
                         {
                             mainTaskobj = i;
                         }*/
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

                            break;
                        }

                    case Constants.Addsubtask:
                        {
                            /*string jsonString =
                                @"{""task"":[
""children"":[
""id"": ""dc787b7f-f0d5-4b73-9b75-2099f62c60d0"",
          ""parent"": ""8a92b9c7-c04d-4d81-9bd8-e2c0e798ce1d"",
          ""name"": ""Create mock api for get"",
          ""about"": ""Generate mock api for get call"",
          ""dateAdd"": ""2021-09-28T21: 30:00"",
          ""dateDeadline"": ""2021 - 10 - 10T21: 10:00""
             ]
                                            ]
                            }
";
                            MainTaskJson mainTaskRepository =
                            JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                            MainTask mainTaskobj = new MainTask();
                            foreach (var i in mainTaskRepository.Task)
                            {
                                mainTaskobj = i;
                            }*/
                            try
                            {
                                Console.WriteLine("SubTask -- ");
                                Console.WriteLine("Enter Number, About task, Date addition and Date end");
                                MainTask mainTaskobj = new MainTask();
                                List<SubTask> subTasks = new List<SubTask>();
                                subTasks.Add(new SubTask
                                {
                                    Number = int.Parse(Console.ReadLine()),
                                    Id = Guid.NewGuid(),
                                    Parent = Guid.NewGuid(),
                                    About = Console.ReadLine(),
                                    DateAdd = DateTime.Parse(Console.ReadLine()),
                                    DateDead = DateTime.Parse(Console.ReadLine())
                                });
                                mainTaskobj.Children = subTasks;
                                _repository.Add(mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                                Console.WriteLine("Enter correct value");
                            }

                            break;
                        }

                    case Constants.Printall:
                        {
                            _repository.Print();
                            break;
                        }

                    case Constants.Print:
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

                            break;
                        }

                    case Constants.Edit:
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
                                subTasks.Add(new SubTask
                                {
                                    Number = int.Parse(Console.ReadLine()),
                                    Id = Guid.NewGuid(),
                                    Parent = Guid.NewGuid(),
                                    About = Console.ReadLine(),
                                    DateAdd = DateTime.Parse(Console.ReadLine()),
                                    DateDead = DateTime.Parse(Console.ReadLine())
                                });
                                mainTaskobj.Children = subTasks;
                                _repository.Edit(number, mainTaskobj);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(typeof(Exception));
                            }

                            break;
                        }

                    case Constants.Delete:
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
    }
}