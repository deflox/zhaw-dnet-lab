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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataAdapter.FlughafenDBDataSet flughafenDBDataSet;
        private DataAdapter.FlughafenDBDataSetTableAdapters.FlugTableAdapter flughafenDBDataSetFlugTableAdapter;
        private System.Windows.Data.CollectionViewSource flugViewSource;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            flughafenDBDataSet = ((DataAdapter.FlughafenDBDataSet)(this.FindResource("flughafenDBDataSet")));
            // Load data into the table Flug. You can modify this code as needed.
            flughafenDBDataSetFlugTableAdapter = new DataAdapter.FlughafenDBDataSetTableAdapters.FlugTableAdapter();
            flughafenDBDataSetFlugTableAdapter.Fill(flughafenDBDataSet.Flug);
            flugViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("flugViewSource")));
            flugViewSource.View.MoveCurrentToFirst();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            flugViewSource.View.MoveCurrentToPrevious();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            flugViewSource.View.MoveCurrentToNext();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            flughafenDBDataSetFlugTableAdapter.Update(flughafenDBDataSet.Flug);
        }
    }
}
