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
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;
using Katalog.Classes;

namespace Katalog
{
    /// <summary>
    /// Interaction logic for Choose_Subproduct.xaml
    /// </summary>
    public partial class Choose_Subproduct : Window
    {
        DatabaseFile _db = new DatabaseFile();
        public Choose_Subproduct()
        {
            InitializeComponent();
            using (IObjectContainer db = Db4oEmbedded.OpenFile(_db.DB_FILE))
            {
                var q = from DatabaseClass p in db select p;
                gridChoose.ItemsSource = q;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                AddForm af = (AddForm)Application.Current.Windows[1];

                using (IObjectContainer db = Db4oEmbedded.OpenFile(_db.DB_FILE))
                {
                    var temp = gridChoose.SelectedItem as DatabaseClass;
                    var q = from DatabaseClass p in db
                            where p.IDProduct == temp.IDProduct
                            select p;

                    for (int i = 0; i < af.subprod.Length; i++)
                    {
                        if (af.subprod[i] == null)
                            af.subprod[i] = new Subproduct { ValueOnProduct = 5, Product = q.Cast<DatabaseClass> };
                        break;
                    }
                }
                Close();
            }
            catch { }
        }
    }
}
