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

namespace Science_G.K
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ValidateUser vs = new ValidateUser();
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtUserName.Text == "" || txtPassword.Password == "")
            {
                MessageBox.Show("Please fill the form");
            }

            else if (vs.IsvalidUser(txtUserName.Text, txtPassword.Password))
            {
                Dashboard dash = new Dashboard(txtUserName.Text);
                dash.Show();
                this.Close();
            }
            else if (vs.IsvalidAdmin(txtUserName.Text, txtPassword.Password))
            {
                Dashboard dash = new Dashboard(txtUserName.Text);
                dash.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid User_Name or Password");
            }
           
        }
        

    }
}
