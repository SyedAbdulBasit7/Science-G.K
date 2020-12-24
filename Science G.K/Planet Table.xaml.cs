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
    /// Interaction logic for Planet_Table.xaml
    /// </summary>
    public partial class Planet_Table : Window
    {
        public Planet_Table()
        {
            InitializeComponent();
            DataClasses1DataContext db = new DataClasses1DataContext();
            var query = from pd in db.PlanetDBos
                        select pd;
            planetTable.ItemsSource = query.ToList();
        }
    }
}
