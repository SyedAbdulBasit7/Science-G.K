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
    /// Interaction logic for Add_Plant.xaml
    /// </summary>
    public partial class Add_Plant : Window
    {
        string selectedFileName;
        public Add_Plant()
        {
            InitializeComponent();
        }

        private void updatePlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                PlantDBo upd = (from s in db.PlantDBos
                                where s.PlantName == addPlantName.Text
                                select s).FirstOrDefault();

                upd.ConversationStatus = addConversationSatus.Text;
                upd.Class = addClass.Text;
                upd.P_Order = addOrder.Text;
                upd.Family = addFamily.Text;
                upd.Kingdom = addKingdom.Text;
                upd.Image = bitmap.ToString();
                db.SubmitChanges();
                System.Windows.MessageBox.Show("Record Updated Successfully!");
                addPlantName.Text = "";
                addConversationSatus.Text = "";
                addClass.Text = "";
                addOrder.Text = "";
                addFamily.Text = "";
                addKingdom.Text = "";
                resetImage();
            }
            catch (Exception ex)
            { }
        }

        private void deletePlant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                PlantDBo spd = (from s in db.PlantDBos
                                where s.PlantName == addPlantName.Text
                                select s).FirstOrDefault();
                db.PlantDBos.DeleteOnSubmit(spd);
                db.SubmitChanges();
                System.Windows.MessageBox.Show("Record Deleted Successfully!");
                addPlantName.Text = "";
                addConversationSatus.Text = "";
                addKingdom.Text = "";
                addClass.Text = "";
                addOrder.Text = "";
                addFamily.Text = "";
                resetImage();
            }
            catch (Exception ex)
            { }
        }

        private void addPlant_Click(object sender, RoutedEventArgs e)
        {
            if (addPlantName.Text == "" || addConversationSatus.Text == "" ||
               addClass.Text == "" || addKingdom.Text == "" || addOrder.Text == "" || addFamily.Text == "")
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
                    PlantDBo newPlant = new PlantDBo()
                    {
                        PlantName = addPlantName.Text,
                        ConversationStatus = addConversationSatus.Text,
                        Kingdom = addKingdom.Text,
                        Class = addClass.Text,
                        P_Order = addOrder.Text,
                        Family = addFamily.Text,
                        Image = bitmap.ToString(),
                    };

                    db.PlantDBos.InsertOnSubmit(newPlant);
                    db.SubmitChanges();
                    System.Windows.MessageBox.Show("Added Suucessfully");
                    addPlantName.Text = "";
                    addConversationSatus.Text = "";
                    addKingdom.Text = "";
                    addClass.Text = "";
                    addOrder.Text = "";
                    addFamily.Text = "";
                    resetImage();


                }
                catch (Exception ex)
                { }
            }
        }

            private void btnSearch_Click(object sender, RoutedEventArgs e)
            {
                DataClasses1DataContext db = new DataClasses1DataContext();

                PlantDBo spd = (from s in db.PlantDBos
                                where s.PlantName == addPlantName.Text
                                select s).FirstOrDefault();
                if (spd == null)
                {
                    System.Windows.MessageBox.Show("No Record Found Successfully");
                }
                else
                {
                    addPlantName.Text = spd.PlantName;
                    addConversationSatus.Text = spd.ConversationStatus;
                    addKingdom.Text = spd.Kingdom;
                    addOrder.Text = spd.P_Order;
                    addFamily.Text = spd.Family;
                    addClass.Text = spd.Class;
                    selectedFileName = spd.Image;
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(selectedFileName);
                    bitmap.EndInit();
                    plantPic.Source = bitmap;
                    System.Windows.MessageBox.Show("Record Found Successfully!");
                }
            }

            private void addPicture_Click(object sender, RoutedEventArgs e)
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
                plantPic.Source = bitmap;
            }
        }
            public void resetImage()
            {
                plantPic.Source = null;
            }

       
    }
}
