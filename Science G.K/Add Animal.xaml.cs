using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Science_G.K
{
    /// <summary>
    /// Interaction logic for Add_Animal.xaml
    /// </summary>
    public partial class Add_Animal : Window
    {
        string selectedFileName;
        public Add_Animal()
        {
            InitializeComponent();
        }

        private void addAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (addAnimalName.Text == "" || addConversationSatus.Text == "" ||
                addClass.Text == "" || addKingdom.Text == "" || addOrder.Text == "" || addFamily.Text == "" )
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
                    AnimalsDBo newAnimal = new AnimalsDBo()
                    {
                        AnimalName = addAnimalName.Text,
                        ConversationStatus = addConversationSatus.Text,
                        Kingdom = addKingdom.Text,
                        Class = addClass.Text,
                        A_Order = addOrder.Text,
                        Family = addFamily.Text,
                        AniImage= bitmap.ToString(),
                    };

                    db.AnimalsDBos.InsertOnSubmit(newAnimal);
                    db.SubmitChanges();
                    System.Windows.MessageBox.Show("Added Suucessfully");
                    addAnimalName.Text = "";
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

        private void deleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                AnimalsDBo spd = (from s in db.AnimalsDBos
                                     where s.AnimalName == addAnimalName.Text
                                     select s).FirstOrDefault();
                db.AnimalsDBos.DeleteOnSubmit(spd);
                db.SubmitChanges();
                System.Windows.MessageBox.Show("Record Deleted Successfully!");
                addAnimalName.Text = "";
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

        private void updateAnimal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                AnimalsDBo upd = (from s in db.AnimalsDBos
                                     where s.AnimalName == addAnimalName.Text
                                     select s).FirstOrDefault();
                
                upd.ConversationStatus = addConversationSatus.Text;
                upd.Class = addClass.Text;
                upd.A_Order = addOrder.Text;
                upd.Family = addFamily.Text;
                upd.Kingdom = addKingdom.Text;
                upd.AniImage = bitmap.ToString();
                db.SubmitChanges();
                System.Windows.MessageBox.Show("Record Updated Successfully!");
                addAnimalName.Text = "";
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
           
            AnimalsDBo spd = (from s in db.AnimalsDBos
                                 where s.AnimalName == addAnimalName.Text
                                 select s).FirstOrDefault();           
            if (spd == null)
            {
                System.Windows.MessageBox.Show("No Record Found Successfully");
            }
            else
            {
                addAnimalName.Text = spd.AnimalName;
                addConversationSatus.Text = spd.ConversationStatus;
                addKingdom.Text = spd.Kingdom;
                addOrder.Text = spd.A_Order;
                addFamily.Text = spd.Family;
                addClass.Text = spd.Class;
                selectedFileName = spd.AniImage;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                animal_pic.Source = bitmap;
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
                animal_pic.Source = bitmap;
            }
        }
        public void resetImage()
        {
            animal_pic.Source = null;
        }
    }
}
