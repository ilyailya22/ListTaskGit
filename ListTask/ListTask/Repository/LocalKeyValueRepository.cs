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

        public void Add(MainTask taskRepository)
        {
            int id = 0;
            _keyTaskRepository.Add(id, taskRepository);
        }

        public void Delete(int id)
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

        public void PrintByld(int id)
        {
            KeyValuePair<int, MainTask> entry = _keyTaskRepository.ElementAt(id);
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        public void DeleteAll()
        {
            _keyTaskRepository.Clear();
        }

        public void Edit(int number, MainTask task)
        {
            if (!_keyTaskRepository.ContainsKey(number))
                _keyTaskRepository.Add(number, task);
            else
                _keyTaskRepository[number] = task;
        }
    }
}
