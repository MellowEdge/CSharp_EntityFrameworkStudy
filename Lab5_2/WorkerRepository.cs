using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    public class WorkerRepository
    {
        WorkerContext db;

        public WorkerRepository() {
            db = new WorkerContext();
        }

        public Worker Get(int id)
        {
            return db.Workers.Find(id);
        }

        public List<Worker> GetAll()
        {
            //return db.Workers.Local.ToBindingList();
            return db.Workers.ToList();
        }

        public void AddWorker(Worker worker)
        {
            if (worker != null)
            {
                db.Workers.Add(worker);
                db.SaveChanges();
            }
        }

        public void UpdateTable()
        {
            db.SaveChanges();
        }

        public void UpdateWorker(Worker worker)
        {
            var workerFind = this.Get(worker.Id);
            if (workerFind != null)
            {
                workerFind.Name = worker.Name;
                workerFind.Job = worker.Job;
                workerFind.Salary = worker.Salary;
                workerFind.Section = worker.Section;
                db.SaveChanges();
            }
        }

        public void RemoveWorker(int id)
        {
            var workObj = db.Workers.Find(id);
            if (workObj != null)
            {
                db.Workers.Remove(workObj);
                db.SaveChanges();
            }
        }

        public void RemoveAll()
        {
            db.Database.ExecuteSqlCommand("delete from Workers");
            db.SaveChanges();
        }
    }

}
