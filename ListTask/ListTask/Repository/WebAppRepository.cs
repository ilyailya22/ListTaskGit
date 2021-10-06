using System;
using ListTask.Models;
using Newtonsoft.Json;

namespace ListTask.Repository
{
    public class WebAppRepository : IRepository
    {
        private RequestService _webTaskRepository;

        public WebAppRepository()
        {
            _webTaskRepository = new RequestService();
        }

        public async void Addmethod(MainTask taskRepository)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(taskRepository);
                try
                {
                    await _webTaskRepository.PostAsync("https://tasklist.free.beeceptor.com/addNewTask", jsonString);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Deletemethod(Guid taskRepository)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(_webTaskRepository);
                try
                {
                    await _webTaskRepository.DeleteAsync("https://tasklist.free.beeceptor.com/deleteTask", jsonString);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async void Print()
        {
            try
            {
                string jsonString = await _webTaskRepository.GetAsync("https://tasklist.free.beeceptor.com/getAllTasks");
                try
                {
                    MainTaskJson webTaskRepository =
                    JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
                    MainTask task = new MainTask();
                    foreach (var i in webTaskRepository.Task)
                    {
                        task = i;
                        task.Show();
                    }
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
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
