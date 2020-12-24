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
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        ValidateUser vs = new ValidateUser();
        String userValue;

        public Dashboard(String uname)
        {
            InitializeComponent();
            if (vs.checkUser(uname))
            {
                todoAnimal.IsEnabled=false;
                todoPlanet.IsEnabled = false;
                todoPlant.IsEnabled = false;
            }
        }

        private void Animal_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Animals animals = new Animals();
            animals.Show();
        }

        private void Plant_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Plants plants = new Plants();
            plants.Show();
        }

     

        private void Planet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Planets planets = new Planets();
            planets.Show();
        }

        private void todoAnimal_Click(object sender, RoutedEventArgs e)
        {
            Add_Animal an = new Add_Animal();
            an.Show();
        }

        private void todoPlant_Click(object sender, RoutedEventArgs e)
        {
            Add_Plant ap = new Add_Plant();
            ap.Show();
        }

        private void todoPlanet_Click(object sender, RoutedEventArgs e)
        {
            Add_Planet ap = new Add_Planet();
            ap.Show();
        }
      
    }
}
