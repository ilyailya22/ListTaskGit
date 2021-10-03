using System;
using System.Linq;
using System.Collections.Generic;
using ListTask.Models;
using System.Threading.Tasks;

namespace ListTask.Repository
{
    public class LocalKeyValueRepository : IRepository
    {
        public Dictionary<Guid, MainTask> KeyTaskRepository;

        public LocalKeyValueRepository() { KeyTaskRepository = new Dictionary<Guid, MainTask>(); }

        public LocalKeyValueRepository(int size) { KeyTaskRepository = new Dictionary<Guid, MainTask>(size); }

        public void Addmethod(MainTask taskRepository)
        {
            Guid id = Guid.NewGuid();
            KeyTaskRepository.Add(id, taskRepository);
        }

        public void Deletemethod(Guid id)
        {
            KeyTaskRepository.Remove(id);
        }

        public void Print()
        {
            for (int i = 0; i < KeyTaskRepository.Count; i++)
            {
                KeyValuePair<Guid, MainTask> entry = KeyTaskRepository.ElementAt(i);
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void DeleteAll()
        {
            KeyTaskRepository.Clear();
        }

    }
}
