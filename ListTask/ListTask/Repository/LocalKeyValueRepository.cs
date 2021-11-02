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
            if (task is MainTask mainTask)
            {
                _keyTaskRepository.Add(mainTask.Id, mainTask);
            }

            if (task is SubTask subTask)
            {
                var parent = _keyTaskRepository.FirstOrDefault(e => e.Key == subTask.Parent);
                if (parent.Value != null)
                {
                    parent.Value.Children.Add(subTask);
                }
            }
        }

        public void Delete(int id, TaskType taskType)
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

        public void PrintByld(int id, TaskType taskType)
        {
            KeyValuePair<int, MainTask> entry = _keyTaskRepository.ElementAt(id);
            Console.WriteLine(entry.Key + " : " + entry.Value);
        }

        public void DeleteAll()
        {
            _keyTaskRepository.Clear();
        }

        public void Edit(BaseTask task)
        {
            if (task is MainTask mainTask)
            {
                if (!_keyTaskRepository.ContainsKey(mainTask.Id))
                    _keyTaskRepository.Add(mainTask.Id, mainTask);
                else
                    _keyTaskRepository[mainTask.Id] = mainTask;
            }

            if (task is SubTask subTask)
            {
                var parent = _keyTaskRepository.FirstOrDefault(e => e.Key == subTask.Parent);
                if (parent.Value != null)
                {
                    parent.Value.Children.Add(subTask);
                }
            }
            }

        public IEnumerable<MainTask> ReadAll()
        {
            return _keyTaskRepository as IEnumerable<MainTask>;
        }

        public MainTask ReadByld(int id)
        {
            throw new NotImplementedException();
        }
    }
}
