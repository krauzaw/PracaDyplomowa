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
using Katalog.Classes;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using System.ComponentModel;
using System.Threading;

namespace Katalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddForm af = new AddForm();
            af.ShowDialog();
        }

        private void ddd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DatabaseFile _db = new DatabaseFile();
                using (IObjectContainer db = Db4oFactory.OpenFile(_db.DB_FILE))
                {
                    var temp = ddd.SelectedItem as DatabaseClass;
                    var q = from DatabaseClass p in db
                            where p.IDProduct == temp.IDProduct
                            select p.Details;

                    detailsGrid.ItemsSource = q;


                    var k = from DatabaseClass p in db
                            where p.IDProduct == temp.IDProduct
                            select p.Subprod;

                    subprodGrid.ItemsSource = k;
                }
            }
            catch { }
        }

        public void ShowData()
        {
            DatabaseFile _db = new DatabaseFile();
            using (IObjectContainer db = Db4oFactory.OpenFile(_db.DB_FILE))
            {
                var r = from DatabaseClass p in db select p;
                ddd.ItemsSource = r;
            }
        }
    }
}
