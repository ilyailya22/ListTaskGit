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

        public void EditTask(int id, MainTask mainTask)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MainTasks.Update(mainTask);
                db.SaveChanges();
            }
        }

        public void EditSubtask(int id, SubTask subTask)
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
    }
}
