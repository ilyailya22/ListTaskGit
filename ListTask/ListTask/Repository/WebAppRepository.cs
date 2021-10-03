using System;
using System.Collections.Generic;
using ListTask.Models;
using System.Threading.Tasks;
using System.Text.Json;

namespace ListTask.Repository
{
    public class WebAppRepository : IRepository
    {
        public RequestService WebTaskRepository;

        public WebAppRepository() { WebTaskRepository = new RequestService(); }

        public async void Addmethod(MainTask taskRepository)
        {
            string jsonString = JsonSerializer.Serialize(taskRepository);
            await WebTaskRepository.PostAsync("https://tasklist.free.beeceptor.com/addNewTask", jsonString);
        }

        public async void Deletemethod(Guid taskRepository)
        {
            string jsonString = JsonSerializer.Serialize(WebTaskRepository);
            await WebTaskRepository.DeleteAsync("https://tasklist.free.beeceptor.com/deleteTask",jsonString);
        }

        public async void Print()
        {
            string jsonString = await WebTaskRepository.GetAsync("https://tasklist.free.beeceptor.com/getAllTasks");
            MainTaskJson webTaskRepository =
                JsonSerializer.Deserialize<MainTaskJson>(jsonString);
        }
        public void DeleteAll()
        {
        }
    }
}
