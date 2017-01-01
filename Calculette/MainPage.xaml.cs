using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculette
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Property
        public char opChar { get; set; }
        public double resultNb { get; set; }
        public bool isOpExecuted { get; set; }
        public bool isOpButtonWasPressed { get; set; }
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        // Method
        public void printInScreenLabel(int nb)
        {
            if (this.lblNumberPrinter.Text == "0" || this.isOpButtonWasPressed)
            {
                this.lblNumberPrinter.Text = nb.ToString();
                this.isOpButtonWasPressed = false;
            }
            else
            {
                this.lblNumberPrinter.Text = this.lblNumberPrinter.Text + nb.ToString();
            }
        }

        public void printInScreenLabel(double nb)
        {
            if (this.lblNumberPrinter.Text == "0" || this.isOpButtonWasPressed || this.isOpExecuted || this.isOpButtonWasPressed)
            {
                this.lblNumberPrinter.Text = nb.ToString();
                this.isOpButtonWasPressed = false;
                this.isOpExecuted = false;
            }
            else
            {
                this.lblNumberPrinter.Text = this.lblNumberPrinter.Text + nb.ToString();
            }
        }

        public void printInScreenLabel(char car)
        {
            if (car == ',' && this.isCharactereIsPresentIn(this.lblNumberPrinter.Text, car) != true)
            {
                this.lblNumberPrinter.Text = this.lblNumberPrinter.Text + car.ToString();
            }
            else
            {
                if ((this.lblNumberPrinter.Text != "0" && car != ','))
                {
                    this.lblNumberPrinter.Text = this.lblNumberPrinter.Text + car.ToString();
                    this.isOpButtonWasPressed = false;
                    this.isOpExecuted = false;
                }
            }
        }

        public void eraseACharacterInLblPrinter()
        {
            if(this.lblNumberPrinter.Text.Length > 1)
            {
                this.lblNumberPrinter.Text = this.lblNumberPrinter.Text.Substring(0, this.lblNumberPrinter.Text.Length - 1);
            }
            else
            {
                this.lblNumberPrinter.Text = "0";
            }
        }

        public bool isCharactereIsPresentIn(string str, char car)
        {
            return str.Contains(car);
        }
        private void printCurrentNumberInHistoryLabel(char op)
        {
            this.lblOperationHistory.Text = this.lblOperationHistory.Text + this.lblNumberPrinter.Text + op;
        }

        public void preExecuteOperation(char op)
        {
            this.printCurrentNumberInHistoryLabel(op);
            if(this.opChar != ' ' && this.lblNumberPrinter.Text != "0")
            {
                this.executeOperation();
            }
            else
            {
                this.resultNb = Convert.ToDouble(this.lblNumberPrinter.Text);
            }
            if(this.lblNumberPrinter.Text != "0")
            {
                this.opChar = op;
            }
            this.isOpButtonWasPressed = true;
        }


        public void executeOperation()
        {
            switch (this.opChar)
            {
                case '+':
                    this.resultNb = this.resultNb + Convert.ToDouble(this.lblNumberPrinter.Text);
                    break;
                case '-':
                    this.resultNb = this.resultNb - Convert.ToDouble(this.lblNumberPrinter.Text);
                    break;
                case (char)247: // Symbole division
                    this.resultNb = this.resultNb / Convert.ToDouble(this.lblNumberPrinter.Text);
                    break;
                case (char)215: // Symbole multiplier
                    this.resultNb = this.resultNb * Convert.ToDouble(this.lblNumberPrinter.Text);
                    break;
                default:

                    break;

            }
            if (this.opChar != ' ' || this.isOpExecuted)
            {
                this.printInScreenLabel(this.resultNb);
            }
            this.opChar = ' ';
            this.isOpExecuted = true;
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(0));
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(1));
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(2));
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(3));
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(4));
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(5));
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(6));
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(7));
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(8));
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(Convert.ToInt32(9));
        }

        private void btnComma_Click(object sender, RoutedEventArgs e)
        {
            this.printInScreenLabel(',');
        }

        private void btnNegate_Click(object sender, RoutedEventArgs e)
        {
            if(this.lblNumberPrinter.Text != "0")
            {
                if(this.isCharactereIsPresentIn(this.lblNumberPrinter.Text, '-'))
                {
                    this.lblNumberPrinter.Text = this.lblNumberPrinter.Text.Substring(1);
                }
                else
                {
                    this.lblNumberPrinter.Text = "-" + this.lblNumberPrinter.Text;
                }
            }
        }

        private void btnCE_Click(object sender, RoutedEventArgs e)
        {
            this.lblNumberPrinter.Text = "0";
        }

        private void btnC_Click(object sender, RoutedEventArgs e)
        {
            this.lblOperationHistory.Text = "";
            this.lblNumberPrinter.Text = "0";
            this.resultNb = 0;
            this.opChar = ' ';
            this.isOpExecuted = true;
        }

        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            this.eraseACharacterInLblPrinter();
        }

        private void btnDivision_Click(object sender, RoutedEventArgs e)
        {
            this.preExecuteOperation((char)247);
        }

        private void btnMultiplication_Click(object sender, RoutedEventArgs e)
        {
            this.preExecuteOperation((char)215);
        }

        private void btnAddition_Click(object sender, RoutedEventArgs e)
        {
            this.preExecuteOperation('+');
        }

        private void btnSoustration_Click(object sender, RoutedEventArgs e)
        {
            this.preExecuteOperation('-');
        }

        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            this.executeOperation();
            this.lblOperationHistory.Text = "";
            this.opChar = ' ';
        }


        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "NumberPad0":
                    this.printInScreenLabel(0);
                    break;
                case "NumberPad1":
                    this.printInScreenLabel(1);
                    break;
                case "NumberPad2":
                    this.printInScreenLabel(2);
                    break;
                case "NumberPad3":
                    this.printInScreenLabel(3);
                    break;
                case "NumberPad4":
                    this.printInScreenLabel(4);
                    break;
                case "NumberPad5":
                    this.printInScreenLabel(5);
                    break;
                case "NumberPad6":
                    this.printInScreenLabel(6);
                    break;
                case "NumberPad7":
                    this.printInScreenLabel(7);
                    break;
                case "NumberPad8":
                    this.printInScreenLabel(8);
                    break;
                case "NumberPad9":
                    this.printInScreenLabel(9);
                    break;
                case "Back":
                    this.eraseACharacterInLblPrinter();
                    break;
                case "Enter":
                    this.executeOperation();
                    break;
                case "Add":
                    this.preExecuteOperation('+');
                    break;
                case "Subtract":
                    this.preExecuteOperation('-');
                    break;
                case "Multiply":
                    this.preExecuteOperation((char)215);
                    break;
                case "Divide":
                    this.preExecuteOperation((char)247);
                    break;
                default:

                    break;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.opChar = ' ';
            this.lblNumberPrinter.Text = "0";
            this.isOpExecuted = true;
        }
    }
}
