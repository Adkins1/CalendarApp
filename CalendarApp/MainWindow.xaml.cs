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
using System.IO; 

namespace CalendarApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveEvents()
        {
            try
            {
                StreamWriter sw = new StreamWriter(CalendarDate.SelectedDate.ToString().Replace('.', ' ').Remove(10) + ".txt");
                for(int i=0; i<lbxEvents.Items.Count; i++)
                {
                    sw.WriteLine(lbxEvents.Items[i]);
                }
                sw.Close();
            }
            catch(Exception ex)
            {

            }
        }

        private void CalendarDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //z jakiegos powodu czyści nawet to co odczyta TRY
            //lbxEvents.Items.Clear();
            try
            {
                StreamReader sr = new StreamReader(CalendarDate.SelectedDate.ToString().Replace('.', ' ').Remove(10));
                while (!sr.EndOfStream)
                {
                    lbxEvents.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch(Exception ex)
            {

            }
            
        }

        private void lbxEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDelete.IsEnabled = true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string item = txtTime.Text + " : " + txtName.Text;
            lbxEvents.Items.Add(item);
            SaveEvents();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            lbxEvents.Items.Remove(lbxEvents.SelectedItem);
            SaveEvents();
        }
    }
}
