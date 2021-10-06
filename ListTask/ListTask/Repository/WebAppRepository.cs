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

        public async void Addmethod(MainTask taskRepository)
        {
            string jsonString = JsonConvert.SerializeObject(taskRepository);
            try
            {
                await _requestService.PostAsync("https://tasklist.free.beeceptor.com/addNewTask", jsonString);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Deletemethod(Guid taskRepository)
        {
            string jsonString = JsonConvert.SerializeObject(_requestService);
            try
            {
                await _requestService.DeleteAsync("https://tasklist.free.beeceptor.com/deleteTask", jsonString);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Print()
        {
            try
            {
                string jsonString = await _requestService.GetAsync("https://tasklist.free.beeceptor.com/getAllTasks");
                MainTaskJson mainTaskRepository =
                JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                MainTask mainTask = new MainTask();
                foreach (var i in mainTaskRepository.Task)
                {
                    mainTask = i;
                    mainTask.ShowNameDate();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteAll()
        {
        }
    }
}
