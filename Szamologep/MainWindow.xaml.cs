using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Szamologep
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GombokElhelyezese();
        }


        private void GombokElhelyezese()
        {
            for (int i = 0; i < 4; i++)
            {
                ButtonGrid.RowDefinitions.Add(new RowDefinition());
                ButtonGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            string[,] feliratok =
             {
            {"7","8","9","/" },
            {"4","5","6","*" },
            {"1","2","3","-" },
            {"C","0","=","+" }
              };
            for (int i = 0; i < 4; i++) //sorok
            {
                for (int j = 0; j < 4; j++) //oszlopok
                {
                    string label = feliratok[i, j];
                    Button btn = new Button
                    {
                        Content = label,
                        FontSize = 20,
                        FontWeight = FontWeights.Bold,
                        Margin = new Thickness(3)
                    };
                    if (char.IsDigit(label[0]))
                    {
                        btn.Background = Brushes.WhiteSmoke;
                    }
                    else if (label == "C")
                    {
                        btn.Background = Brushes.IndianRed;
                        btn.Foreground = Brushes.White;
                    }
                    else
                    {
                        btn.Background = Brushes.DodgerBlue;
                        btn.Foreground = Brushes.White;
                    }

                    btn.Click += Butto_Click;
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    ButtonGrid.Children.Add(btn);
                }
            }
        }

        private double elsoSzam = 0;
        private string muvelet = "";
        private bool ujSzam = true; 

        private void Butto_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string felirat = button.Content.ToString();

            if(felirat == "C")
            {
                tb_kijelzo.Text = "0";
                elsoSzam = 0;
                muvelet = "";
                ujSzam = true;
            }

            else if (felirat == "+" || felirat == "-" || felirat == "*" || felirat == "/")
            {
                elsoSzam = Convert.ToDouble(tb_kijelzo.Text);
                muvelet = felirat;
                ujSzam = true;
            }

            else if (felirat == "=")
            {
                double masodikSzam = Convert.ToDouble(tb_kijelzo.Text);
                double eredmeny = 0;

                switch (muvelet)
                {
                    case "+":
                        eredmeny = elsoSzam + masodikSzam;
                        break;
                    case "-":
                        eredmeny = elsoSzam - masodikSzam;
                        break;
                    case "*":
                        eredmeny = elsoSzam * masodikSzam;
                        break;
                    case "/":
                        eredmeny = elsoSzam / masodikSzam;
                        break;
                }

                tb_kijelzo.Text = eredmeny.ToString();
                ujSzam = true;
            }

            else
            {
                if(tb_kijelzo.Text == "0" || ujSzam)
                {
                    tb_kijelzo.Text = felirat;
                    ujSzam = false;
                }
                else
                {
                    tb_kijelzo.Text += felirat;
                }
        }
    }
        }

       
                
            
        

    }
