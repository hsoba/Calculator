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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        double value = 0;
        string operation = "";
        bool opSelected = false;
        bool equalsPressed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if ((displayResult.Text == "0") || opSelected || equalsPressed)
            {
                displayResult.Clear();
            }
            opSelected = equalsPressed = false;
            Button b = (Button)sender;
            displayResult.Text += b.Content;
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (displayResult.Text.Contains(".") || equalsPressed)
            {
                ;
            }
            else if (equalsPressed || displayResult.Text == "0")
            {
                displayResult.Text = "0.";
            }
            else
            {
                displayResult.Text += b.Content;
            }
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            displayResult.Text = "0";
        }

        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            operation = (string)b.Content;
            value = double.Parse(displayResult.Text);
            equation.Content = value + " " + operation;
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
            value = double.Parse(displayResult.Text);
            opSelected = true;
            equation.Content = value + " " + operation;
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
            value = double.Parse(displayResult.Text);
            opSelected = true;
            equation.Content = value + " " + operation;
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
            value = double.Parse(displayResult.Text);
            opSelected = true;
            equation.Content = value + " " + operation;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
            value = double.Parse(displayResult.Text);
            opSelected = true;
            equation.Content = value + " " + operation;
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            equalsPressed = true;
            
            equation.Content = "";
            switch (operation)
            {
                case "+":
                    displayResult.Text = (value + double.Parse(displayResult.Text)).ToString();
                    break;
                case "-":
                    displayResult.Text = (value - double.Parse(displayResult.Text)).ToString();
                    break;
                case "*":
                    displayResult.Text = (value * double.Parse(displayResult.Text)).ToString();
                    break;
                case "/":
                    displayResult.Text = (value / double.Parse(displayResult.Text)).ToString();
                    break;
            }
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            displayResult.Text = (-(double.Parse(displayResult.Text))).ToString();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            displayResult.Clear();
            value = 0;
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (displayResult.Text.Length > 0)
            {
                displayResult.Text = displayResult.Text.Remove(displayResult.Text.Length - 1);
            }
        }
    }
}
