using System.Collections.Generic;
using System.Linq;
using ListTask.Models;

namespace ListTask.Services
{
    public class DataBaseService : IDataBaseService
    {
        public void AddTask(MainTask mainTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MainTasks.Add(mainTask);
                db.SaveChanges();
            }
        }

        public void AddSubtask(SubTask subTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SubTasks.Add(subTask);
                db.SaveChanges();
            }
        }

        public MainTask ReadTask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var mainTask = db.MainTasks.FirstOrDefault(x => x.Id == id);
                var subTasks = db.SubTasks.Where(x => x.Parent == id).ToList();
                mainTask.Children = subTasks;
                return mainTask;
            }
        }

        public SubTask ReadSubtask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var subTask = db.SubTasks.FirstOrDefault(x => x.Id == id);
                return subTask;
            }
        }

        public void EditTask(MainTask mainTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MainTasks.Update(mainTask);
                db.SaveChanges();
            }
        }

        public void EditSubtask(SubTask subTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SubTasks.Update(subTask);
                db.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var mainTask = db.MainTasks.FirstOrDefault(x => x.Id == id);
                var subTasks = db.SubTasks.Where(x => x.Parent == id).ToList();
                mainTask.Children = subTasks;
                db.MainTasks.Remove(mainTask);
                db.RemoveRange(subTasks);
                db.SaveChanges();
            }
        }

        public void DeleteSubtask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var subTask = db.SubTasks.FirstOrDefault(x => x.Id == id);
                db.SubTasks.Remove(subTask);
                db.SaveChanges();
            }
        }

        public List<MainTask> ReadAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<MainTask> tasks = new List<MainTask>();
                var maintasks = db.MainTasks.ToList();
                foreach (var mainTask in maintasks)
                {
                    var subTasks = db.SubTasks.Where(x => x.Parent == mainTask.Id).ToList();
                    mainTask.Children = subTasks;
                    tasks.Add(mainTask);
                }

                return tasks;
            }
        }
    }
}
