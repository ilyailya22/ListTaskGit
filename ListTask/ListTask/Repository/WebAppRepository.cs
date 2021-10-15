using System;
using ListTask.Models;
using ListTask.Services;
using Newtonsoft.Json;

namespace ListTask.Repository
{
    public class WebAppRepository : IRepository
    {
        private IRequestService _requestService;

        public WebAppRepository(IRequestService service)
        {
            _requestService = service;
        }

        public async void Add(BaseTask task)
        {
            try
            {
                if (task is MainTask mainTask)
                {
                    string jsonString = JsonConvert.SerializeObject(mainTask);
                    await _requestService.PostAsync("https://tasklist.free.beeceptor.com/addNewTask", jsonString);
                }
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
            }
        }

        public async void Delete(int id, int task)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(id);
                await _requestService.DeleteAsync("https://tasklist.free.beeceptor.com/deleteTask", jsonString);
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
            }
        }

        public async void Print()
        {
            try
            {
                string jsonString = await _requestService.GetAsync("https://tasklist.free.beeceptor.com/getAllTasks");
                MainTaskJson mainTaskRepository =
                JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                MainTask mainTaskobj = new MainTask();
                SubTask subTaskobj = new SubTask();
                int numberTask = 1;
                foreach (var i in mainTaskRepository.Task)
                {
                    mainTaskobj = i;
                    Console.Write(numberTask + ". ");
                    mainTaskobj.ShowNameDate();
                    numberTask++;
                    foreach (var j in mainTaskobj.Children)
                    {
                        subTaskobj = j;
                        Console.Write("\t");
                        subTaskobj.ShowNameDate();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(typeof(Exception));
            }
        }

        public void PrintByld(int id, int task)
        {
        }

        public void DeleteAll()
        {
        }

        public void Edit(int id, BaseTask task)
        {
        }
    }
}
