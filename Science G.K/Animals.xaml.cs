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
    /// Interaction logic for Animals.xaml
    /// </summary>
    public partial class Animals : Window
    {
        public Animals()
        {
            InitializeComponent();
            ResetForm();
        }

        string selectedFileName;

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Animal_Table at = new Animal_Table();
            at.Show();
        }
        private void ResetForm()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var spd = db.AnimalsDBos.Select(c => new { c.AnimalName });
            AnimalList.ItemsSource = spd.ToList();
            AnimalList.DisplayMemberPath = "AnimalName";



        }
      
        private void AnimalList_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            AnimalsDBo spd = (from s in db.AnimalsDBos
                              where s.AnimalName == AnimalList.Text
                              select s).FirstOrDefault();
            if (spd == null)
            {
                Console.WriteLine("Null Value");
            }
            else
            {

                conversationStatus.Text = spd.ConversationStatus;
                Kingdom.Text = spd.Kingdom;
                Order.Text = spd.A_Order;
                Family.Text = spd.Family;
                Classification.Text = spd.Class;
                selectedFileName = spd.AniImage;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                animalImage.Source = bitmap;
            }
        }
    }
}
