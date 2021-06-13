using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WorkerRepository workerRepo;
        public MainWindow()
        {
            InitializeComponent();
            workerRepo = new WorkerRepository();

            //
            workerRepo.RemoveAll();
            Worker worker1 = new Worker { Name = "Vasylchuk Andrij Myhajlovych", Job = "Boss", Salary = 80000, Section = "Main" };
            Worker worker2 = new Worker { Name = "Ruslan Oleksandrovych Dmytrenko", Job = "Coder", Salary = 10000, Section = "Lab" };
            //^ remove this if you want to save db
            
            workerRepo.AddWorker(worker1);
            workerRepo.AddWorker(worker2);

            Console.WriteLine("Workers saved successfully.");

            //var workers = db.Workers;
            //Console.WriteLine("Worker list:");
            //foreach (Worker u in workers)
            //{
            //    Console.WriteLine("{0}.{1} - {2} - {3} - {4}", u.Id, u.Name, u.Job, u.Salary, u.Section);
            //}
            workersGrid.ItemsSource = workerRepo.GetAll();
            //workersGrid.ItemsSource = db.Workers.Local.ToBindingList();
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //db.Dispose();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            Create createWindow = new Create(workerRepo);
            createWindow.Owner = this;
            createWindow.Show();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker worker = (Worker)workersGrid.SelectedItem;
                UpdateWindow updateWindow = new UpdateWindow(workerRepo, worker);
                updateWindow.Owner = this;
                updateWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            workersGrid.ItemsSource = workerRepo.GetAll();
            //workerRepo.UpdateTable();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try {
                Worker worker = (Worker)workersGrid.SelectedItem;

                workerRepo.RemoveWorker(worker.Id);
                workersGrid.ItemsSource = workerRepo.GetAll();
            }
            catch (Exception ex) { 
                MessageBox.Show(""+ex); 
            }
        }
    }
}
