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
    /// Interaction logic for AddDetail.xaml
    /// </summary>
    public partial class AddDetail : Window
    {
        public AddDetail()
        {
            InitializeComponent();
        }

        private void AddDetBut_Click(object sender, RoutedEventArgs e)
        {
            AddForm af = (AddForm)Application.Current.Windows[1];
            
            try
            {
                af.DetailsDict.Add(KeyTB.Text, ValueTB.Text);
                af.refreshGrid();
                Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                KeyTB.Text = "";
                ValueTB.Text = "";                
            }

           
        }
    }
}
