using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
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
    /// Interaction logic for Add_Planet.xaml
    /// </summary>
    public partial class Add_Planet : Window
    {
        string selectedFileName;
        public Add_Planet()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            PlanetDBo spd = (from s in db.PlanetDBos
                              where s.PlanetName == addPlanetName.Text
                              select s).FirstOrDefault();
            if (spd == null)
            {
                System.Windows.MessageBox.Show("No Record Found Successfully");
            }
            else
            {
                addPlanetName.Text = spd.PlanetName;
                addPolarRadius.Text = spd.PolarRadius;
                addSurfaceArea.Text = spd.SurfaceArea;
                addVolume.Text = spd.Volume;
                addMass.Text = spd.Mass;
                addNumberofmoons.Text = spd.NumberOfMoon.ToString();
                addDistancefromearth.Text = spd.DistanceFromEarth.ToString();
                addDistanceformSun.Text = spd.DistanceFromSun.ToString();
                selectedFileName = spd.PlanetImage;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                planetPic.Source = bitmap;
                System.Windows.MessageBox.Show("Record Found Successfully!");
            }
        }

        private void btn_Select_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                selectedFileName = dlg.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                planetPic.Source = bitmap;
            }
        }

        private void addPlanet_Click(object sender, RoutedEventArgs e)
        {
            if (addPlanetName.Text == "" || addPolarRadius.Text == "" ||
                addSurfaceArea.Text == "" || addVolume.Text == "" || addMass.Text == ""
                || addDistanceformSun.Text == "" || addDistancefromearth.Text == ""
                || addNumberofmoons.Text == "")
            {
                System.Windows.MessageBox.Show("Please fill the form correctly");
            }
            else
            {
                try
                {
                    DataClasses1DataContext db = new DataClasses1DataContext();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(selectedFileName);
                    bitmap.EndInit();
                    PlanetDBo newPlanet = new PlanetDBo()
                    {
                        PlanetName = addPlanetName.Text,
                        PolarRadius = addPolarRadius.Text,
                        SurfaceArea = addSurfaceArea.Text,
                        Volume = addVolume.Text,
                        Mass = addMass.Text,
                        NumberOfMoon = Convert.ToInt32(addNumberofmoons.Text),
                        DistanceFromEarth = Convert.ToDouble(addDistancefromearth.Text),
                        DistanceFromSun = Convert.ToDouble(addDistanceformSun.Text),
                        PlanetImage = bitmap.ToString(),

                    };

                    db.PlanetDBos.InsertOnSubmit(newPlanet);
                    db.SubmitChanges();
                    System.Windows.MessageBox.Show("Added Suucessfully");
                    addPlanetName.Text = "";
                    addPolarRadius.Text = "";
                    addSurfaceArea.Text = "";
                    addVolume.Text = "";
                    addMass.Text = "";
                    addNumberofmoons.Text = "";
                    addDistancefromearth.Text = "";
                    addDistanceformSun.Text = "";
                    resetImage();
                  
                }
                catch (Exception ex)
                { }
            }
        }
        private void deletePlanet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                PlanetDBo spd = (from s in db.PlanetDBos
                                 where s.PlanetName == addPlanetName.Text
                                 select s).FirstOrDefault();
                db.PlanetDBos.DeleteOnSubmit(spd);
                db.SubmitChanges();
                System.Windows.MessageBox.Show("Record Deleted Successfully!");
                addPlanetName.Text = "";
                addPolarRadius.Text = "";
                addSurfaceArea.Text = "";
                addVolume.Text = "";
                addMass.Text = "";
                addNumberofmoons.Text = "";
                addDistancefromearth.Text = "";
                addDistanceformSun.Text = "";
                resetImage();
            }
            catch (Exception ex)
            { }
        }

        private void updatePlanet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                PlanetDBo upd = (from s in db.PlanetDBos
                                  where s.PlanetName == addPlanetName.Text
                                  select s).FirstOrDefault();

                upd.PolarRadius = addPolarRadius.Text;
                upd.SurfaceArea = addSurfaceArea.Text;
                upd.Volume = addVolume.Text;
                upd.Mass = addMass.Text;
                upd.NumberOfMoon = Convert.ToInt32(addNumberofmoons.Text);
                upd.DistanceFromEarth = Convert.ToDouble(addDistancefromearth.Text);
                upd.DistanceFromSun = Convert.ToDouble(addDistanceformSun.Text);
                upd.PlanetImage = bitmap.ToString();
                db.SubmitChanges();
                System.Windows.MessageBox.Show("Record Updated Successfully!");
                addPlanetName.Text = "";
                addPolarRadius.Text = "";
                addSurfaceArea.Text = "";
                addVolume.Text = "";
                addMass.Text = "";
                addNumberofmoons.Text = "";
                addDistancefromearth.Text = "";
                addDistanceformSun.Text = "";
                resetImage();
            }
            catch (Exception ex)
            { }

        }
        public void resetImage()
        {
            planetPic.Source = null;
        }
    }
}
