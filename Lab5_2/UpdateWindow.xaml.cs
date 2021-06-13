using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab5_2
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        WorkerRepository workerRepo;
        Worker workerOld;
        public UpdateWindow(WorkerRepository workerRepo, Worker worker)
        {
            InitializeComponent();
            this.workerRepo = workerRepo;
            jobTextBox.Text = worker.Job;
            salaryTextBox.Text = "" + worker.Salary;
            sectionTextBox.Text = worker.Section;
            nameTextBox.Text = worker.Name;
            workerOld = worker;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource workerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("workerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // workerViewSource.Source = [generic data source]
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try { 
                workerOld.Job = jobTextBox.Text;
                workerOld.Salary = Convert.ToInt32(salaryTextBox.Text);
                workerOld.Section = sectionTextBox.Text;
                workerOld.Name = nameTextBox.Text;
                workerRepo.UpdateWorker(workerOld);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
