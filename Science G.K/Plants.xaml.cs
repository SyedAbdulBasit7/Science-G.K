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

namespace Science_G.K
{
    /// <summary>
    /// Interaction logic for Plants.xaml
    /// </summary>
    public partial class Plants : Window
    {
        public Plants()
        {
            InitializeComponent();
            ResetForm();
        }

        string selectedFileName;

        private void plantTable_Click(object sender, RoutedEventArgs e)
        {
            Planet_Table pt = new Planet_Table();
            pt.Show();
        }

      
        private void ResetForm()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var spd = db.PlantDBos.Select(c => new { c.PlantName });
            PlantList.ItemsSource = spd.ToList();
            PlantList.DisplayMemberPath = "PlantName";


        }

        private void PlantList_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            PlantDBo spd = (from s in db.PlantDBos
                            where s.PlantName == PlantList.Text
                            select s).FirstOrDefault();
            if (spd == null)
            {
                Console.WriteLine("Null Value");
            }
            else
            {

                conversationStatus.Text = spd.ConversationStatus;
                Kingdom.Text = spd.Kingdom;
                Order.Text = spd.P_Order;
                Family.Text = spd.Family;
                Classification.Text = spd.Class;
                selectedFileName = spd.Image;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                plantImage.Source = bitmap;
                System.Windows.MessageBox.Show("Record Found Successfully!");
            }
        }
    }
}
