﻿using System;
using System.Collections.Generic;
using System.Linq;
using ListTask.Models;

namespace ListTask.Repository
{
    public class LocalKeyValueRepository : IRepository
    {
        private Dictionary<Guid, MainTask> _keyTaskRepository;

        public LocalKeyValueRepository()
        {
            _keyTaskRepository = new Dictionary<Guid, MainTask>();
        }

        public LocalKeyValueRepository(int size)
        {
            _keyTaskRepository = new Dictionary<Guid, MainTask>(size);
        }

        public void Add(MainTask taskRepository)
        {
            Guid id = Guid.NewGuid();
            _keyTaskRepository.Add(id, taskRepository);
        }

        public void Delete(int number)
        {
            Guid id = Guid.NewGuid();
            _keyTaskRepository.Remove(id);
        }

        public void Print()
        {
            for (int i = 0; i < _keyTaskRepository.Count; i++)
            {
                KeyValuePair<Guid, MainTask> entry = _keyTaskRepository.ElementAt(i);
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }

        public void PrintByld(int number)
        {
            KeyValuePair<Guid, MainTask> entry = _keyTaskRepository.ElementAt(number);
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        public void DeleteAll()
        {
            _keyTaskRepository.Clear();
        }

        public void Edit(int number, MainTask task)
        {
            Guid id = Guid.NewGuid();
            _keyTaskRepository[id] = task;
        }
    }
}
