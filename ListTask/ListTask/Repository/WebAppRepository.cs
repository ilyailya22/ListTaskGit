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

        public void Addmethod(MainTask taskRepository)
        {
            string jsonString = JsonSerializer.Serialize(taskRepository);
            WebTaskRepository.PostAsync("https://tasklist.free.beeceptor.com/addNewTask", jsonString);
        }

        public void Deletemethod(Guid taskRepository)
        {
            string jsonString = JsonSerializer.Serialize(WebTaskRepository);
            WebTaskRepository.DeleteAsync("https://tasklist.free.beeceptor.com/deleteTask",jsonString);
        }

        public void Print()
        {
                WebTaskRepository.GetAsync("https://tasklist.free.beeceptor.com/getAllTasks");
        }
        public void DeleteAll()
        {
        }
    }
}
