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

namespace ExpenseReportCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExpenseViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            vm = new ExpenseViewModel();
            this.DataContext = vm;
        }

        
        private void txtBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBox txt = (TextBox)((Grid)((TextBlock)sender).Parent).Children[1];
            txt.Visibility = Visibility.Visible;
            ((TextBlock)sender).Visibility = Visibility.Collapsed;
        }

        private void txtBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)((Grid)((TextBox)sender).Parent).Children[0];
            tb.Text=((TextBox)sender).Text;
            tb.Visibility = Visibility.Visible;
            ((TextBox)sender).Visibility = Visibility.Collapsed;
        }

       

        //private void NumberComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    TextBox txtbox1 = new TextBox();
        //    txtbox1.Text = "Roommate1";
        //    txtbox1.Width=100;
        //    txtbox1.Height = 20;
            
        //    TextBox txtbox2 = new TextBox();
        //    txtbox2.Text = "Roommate2";
        //    txtbox2.Width=100;
        //    txtbox2.Height = 20;
        //    TextBox txtbox3 = new TextBox();
        //    txtbox3.Text = "Roommate3";
        //    txtbox3.Width=100;
        //    txtbox3.Height = 20;
        //    TextBox txtbox4 = new TextBox();
        //    txtbox4.Text = "Roommate4";
        //    txtbox4.Width=100;
        //    txtbox4.Height = 20;
        //    //string str = NumberComboBox.SelectedValue.ToString();

        //    if (int.Parse(NumberComboBox.SelectedValue.ToString()) == 1)
        //    {
        //        this.stackpanel.Children.Clear();
        //        this.stackpanel.Children.Add(txtbox1);
        //    }
        //    if (int.Parse(NumberComboBox.SelectedValue.ToString()) == 2)
        //    {
        //        this.stackpanel.Children.Clear();
                
        //        this.stackpanel.Children.Add(txtbox1);
        //        this.stackpanel.Children.Add(txtbox2);
        //    }
        //    if (int.Parse(NumberComboBox.SelectedValue.ToString()) == 3)
        //    {
        //        this.stackpanel.Children.Clear();
        //        this.stackpanel.Children.Add(txtbox1);
        //        this.stackpanel.Children.Add(txtbox2);
        //        this.stackpanel.Children.Add(txtbox3);
        //    }
        //    if (int.Parse(NumberComboBox.SelectedValue.ToString()) == 4)
        //    {
        //        this.stackpanel.Children.Clear();
        //        this.stackpanel.Children.Add(txtbox1);
        //        this.stackpanel.Children.Add(txtbox2);
        //        this.stackpanel.Children.Add(txtbox3);
        //        this.stackpanel.Children.Add(txtbox4);
        //    }
        //}
    }
}
