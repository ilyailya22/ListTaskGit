using System;
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
            }
        }

        public void AddSubtask(SubTask subTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SubTasks.Add(subTask);
            }
        }

        public MainTask ReadTask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var mainTasks = db.MainTasks.FirstOrDefault(x => x.Id == id);
                return mainTasks;
            }
        }

        public SubTask ReadSubtask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var subTasks = db.SubTasks.FirstOrDefault(x => x.Id == id);
                return subTasks;
            }
        }

        public void EditTask(int id, MainTask mainTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MainTask dbMainTask = db.MainTasks.FirstOrDefault(x => x.Id == id);
                dbMainTask = mainTask;
                db.MainTasks.Update(dbMainTask);
                db.SaveChanges();
            }
        }

        public void EditSubtask(int id, SubTask subTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SubTask dbSubTask = db.SubTasks.FirstOrDefault(x => x.Id == id);
                dbSubTask = subTask;
                db.SubTasks.Update(dbSubTask);
                db.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MainTask mainTask = db.MainTasks.FirstOrDefault(x => x.Id == id);
                db.MainTasks.Remove(mainTask);
                db.SaveChanges();
            }
        }

        public void DeleteSubtask(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SubTask subTask = db.SubTasks.FirstOrDefault(x => x.Id == id);
                db.SubTasks.Remove(subTask);
                db.SaveChanges();
            }
        }
    }
}
