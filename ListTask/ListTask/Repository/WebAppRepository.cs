using System;
using System.Collections.Generic;
using ListTask.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ListTask.Repository
{
    public class WebAppRepository : IRepository
    {
        public RequestService WebTaskRepository;

        public WebAppRepository() { WebTaskRepository = new RequestService(); }

        public async void Addmethod(MainTask taskRepository)
        {
            string jsonString = JsonConvert.SerializeObject(taskRepository);
            await WebTaskRepository.PostAsync("https://tasklist.free.beeceptor.com/addNewTask", jsonString);
        }

        public async void Deletemethod(Guid taskRepository)
        {
            string jsonString = JsonConvert.SerializeObject(WebTaskRepository);
            await WebTaskRepository.DeleteAsync("https://tasklist.free.beeceptor.com/deleteTask",jsonString);
        }

        public async void Print()
        {
            string jsonString = await WebTaskRepository.GetAsync("https://tasklist.free.beeceptor.com/getAllTasks");
            MainTaskJson webTaskRepository =
                JsonConvert.DeserializeObject<MainTaskJson>(jsonString);
            MainTask task = new MainTask();
            foreach (var i in webTaskRepository.Task)
            {
                task = i;
                task.Show();
            }
        }
        public void DeleteAll()
        {
        }
    }
}
