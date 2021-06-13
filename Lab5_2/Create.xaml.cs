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
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        WorkerRepository workerRepo;
        public Create(WorkerRepository workerRepo)
        {
            InitializeComponent();
            this.workerRepo = workerRepo;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource workerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("workerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // workerViewSource.Source = [generic data source]
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker worker = new Worker()
                {
                    Job = jobTextBox.Text,
                    Salary = Convert.ToInt32(salaryTextBox.Text),
                    Section = sectionTextBox.Text,
                    Name = nameTextBox.Text
                };
                workerRepo.AddWorker(worker);
            } catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
    }
}
