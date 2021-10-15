using System;
using System.Collections.Generic;
using System.Linq;
using ListTask.Models;

namespace ListTask.Repository
{
    public class LocalKeyValueRepository : IRepository
    {
        private Dictionary<int, MainTask> _keyTaskRepository;

        public LocalKeyValueRepository()
        {
            _keyTaskRepository = new Dictionary<int, MainTask>();
        }

        public LocalKeyValueRepository(int size)
        {
            _keyTaskRepository = new Dictionary<int, MainTask>(size);
        }

        public void Add(BaseTask task)
        {
            int id = 0;
            if (task is MainTask mainTask)
            {
                _keyTaskRepository.Add(id, mainTask);
            }
        }

        public void Delete(int id, int task)
        {
                _keyTaskRepository.Remove(id);
        }

        public void Print()
        {
            for (int i = 0; i < _keyTaskRepository.Count; i++)
            {
                KeyValuePair<int, MainTask> entry = _keyTaskRepository.ElementAt(i);
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void PrintByld(int id, int task)
        {
            KeyValuePair<int, MainTask> entry = _keyTaskRepository.ElementAt(id);
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        public void DeleteAll()
        {
            _keyTaskRepository.Clear();
        }

        public void Edit(int id, BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                if (!_keyTaskRepository.ContainsKey(id))
                    _keyTaskRepository.Add(id, mainTask);
                else
                    _keyTaskRepository[id] = mainTask;
            }
        }
    }
}
