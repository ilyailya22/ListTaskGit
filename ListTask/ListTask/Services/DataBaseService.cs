using System;
using System.Linq;
using ListTask.Models;

namespace ListTask.Services
{
    public class DataBaseService : IDataBaseService
    {
        public void AddTask(MainTask mainTaskobj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.MainTasks.Add(mainTaskobj);
            }
        }

        public void AddSubtask(SubTask subTaskobj)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.SubTasks.Add(subTaskobj);
            }
        }

        public void ReadTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var mainTasks = db.MainTasks.ToList();
                Console.WriteLine("Список объектов:");
                foreach (MainTask mainTask in mainTasks)
                {
                    Console.WriteLine($"{mainTask.Id}.{mainTask.Name} - {mainTask.About}");
                }
            }
        }

        public void ReadSubtask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var subTasks = db.SubTasks.ToList();
                Console.WriteLine("Список объектов:");
                foreach (SubTask subTask in subTasks)
                {
                    Console.WriteLine($"{subTask.Id}.{subTask.Name} - {subTask.About}");
                }
            }
        }

        public void EditTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MainTask mainTask = db.MainTasks.FirstOrDefault();
                if (mainTask != null)
                {
                    mainTask.Name = "Bob";
                    mainTask.About = "some about";
                    db.MainTasks.Update(mainTask);
                    db.SaveChanges();
                }
            }
        }

        public void EditSubtask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SubTask subTask = db.SubTasks.FirstOrDefault();
                if (subTask != null)
                {
                    subTask.Name = "Bob";
                    subTask.About = "some about";
                    db.SubTasks.Update(subTask);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteTask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                MainTask mainTask = db.MainTasks.FirstOrDefault();
                if (mainTask != null)
                {
                    db.MainTasks.Remove(mainTask);
                    db.SaveChanges();
                }
            }
        }

        public void DeleteSubtask()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                SubTask subTask = db.SubTasks.FirstOrDefault();
                if (subTask != null)
                {
                    db.SubTasks.Remove(subTask);
                    db.SaveChanges();
                }
            }
        }
    }
}
