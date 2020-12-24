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
    /// Interaction logic for Planets.xaml
    /// </summary>
    public partial class Planets : Window
    {
        public Planets()
        {
            InitializeComponent();
            ResetForm();
        }

        private void planetsTable_Click(object sender, RoutedEventArgs e)
        {
            Planet_Table pt = new Planet_Table();
            pt.Show();
        }
        string selectedFileName;

        private void ResetForm()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var spd = db.PlanetDBos.Select(c => new { c.PlanetName });
            AnimalList.ItemsSource = spd.ToList();
            AnimalList.DisplayMemberPath = "PlanetName";



        }
        private void AnimalList_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            PlanetDBo spd = (from s in db.PlanetDBos
                            where s.PlanetName == AnimalList.Text
                            select s).FirstOrDefault();
            if (spd == null)
            {
                Console.WriteLine("Null Value");
            }
            else
            {

                polarRadius.Text = spd.PolarRadius;
                surfaceArea.Text = spd.SurfaceArea;
                Volume.Text = spd.Volume;
                Mass.Text = spd.Mass;
                numberOfMoons.Text = spd.NumberOfMoon.ToString();
                distanceFromEarth.Text = spd.DistanceFromEarth.ToString();
                distanceFromSun.Text= spd.DistanceFromSun.ToString();
                selectedFileName = spd.PlanetImage;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                planetImage.Source = bitmap;
            }
        }
    }
}
