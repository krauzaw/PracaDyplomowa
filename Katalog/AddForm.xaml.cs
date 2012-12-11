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
using Katalog.Classes;
using Db4objects.Db4o.Linq;
using Db4objects.Db4o;

namespace Katalog
{
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        #region Zmienne
            AddToDatabase addToBase;
            public Dictionary<string, string> DetailsDict = new Dictionary<string, string>();
            public Subproduct[] subprod = new Subproduct[5];
        #endregion

        public AddForm()
        {
            InitializeComponent();
            addToBase = new AddToDatabase();
            //IDTB.Text = Guid.NewGuid().ToString();
            //DetailsDict = new Dictionary<string,string>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           #region Add_New_Subproduct
            if (this.Title == "Add Subproduct")
            {
                for (int i = 0; i < subprod.Length; i++)
                {
                    if (subprod[i] == null)
                    {
                        subprod[i] = new Subproduct
                        {
                            ValueOnProduct = 5,
                            Product = new DatabaseClass
                            {
                                IDProduct = Guid.NewGuid().ToString(),
                                Name = NameTB.Text,
                                ValueInDatabase = int.Parse(ValueTB.Text),
                                Unit = UnitTB.Text
                            }
                        };
                    }
                    break;
                }
                Close();
            }
           #endregion
           #region Add_Existing_Subproduct
            else
            {
                try
                {
                    if (DetailsDict.Count == 0 && subprod[0] == null)
                    {
                        addToBase.AddToDatabaseFunct(NameTB.Text, int.Parse(ValueTB.Text), UnitTB.Text);
                    }
                    else if (DetailsDict.Count != 0 && subprod[0] == null)
                    {
                        addToBase.AddToDatabaseFunct(NameTB.Text, int.Parse(ValueTB.Text), UnitTB.Text, DetailsDict);
                    }
                    else if (DetailsDict.Count != 0 && subprod[0] != null)
                    {
                        addToBase.AddToDatabaseFunct(NameTB.Text, int.Parse(ValueTB.Text), UnitTB.Text, DetailsDict, subprod);
                    }
                    MessageBox.Show("Dodano do bazy", "Dodano", MessageBoxButton.OK);
                    MainWindow mw = (MainWindow)Application.Current.Windows[0];
                    mw.ShowData();
                    Close();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                }
            }
           #endregion
        }

        void clear()
        {
            IDTB.Text = null;
            NameTB.Text = null;
            ValueTB.Text = null;
            UnitTB.Text = null;
            grid.ItemsSource = null;
            DetailsDict.Clear();
        }   

        private void NewDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDetail addDet = new AddDetail();
                addDet.ShowDialog();
            }
            catch (Exception a)
            { MessageBox.Show(a.Message); }
        }
        
        public void refreshGrid()
        {
            grid.ItemsSource = null;
            grid.ItemsSource = DetailsDict;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AddForm a = new AddForm();
            a.Title = "Add Subproduct";
            a.ShowDialog();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Choose_Subproduct cs = new Choose_Subproduct();
            cs.ShowDialog();
        }
        
    }
}
