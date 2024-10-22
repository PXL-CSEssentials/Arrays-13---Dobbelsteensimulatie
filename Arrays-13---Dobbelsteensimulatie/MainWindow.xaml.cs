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

namespace Arrays_13___Dobbelsteensimulatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaxNumberOfComputerThrows = 1000;
        private Random _random = new Random();

        private int _throw1 = 0;
        private int _throw2 = 0;
        private int _sum = 0;

        private int[] _totals;

        public MainWindow()
        {
            InitializeComponent();

            int numberOfTextBoxes = totalCanvas.Children.OfType<TextBox>().Count() - 1; // laatste textbox is het totaal
            _totals = new int[numberOfTextBoxes];
        }

        public void ComputerSimulation()
        {
            _throw1 = _random.Next(1, 7);
            _throw2 = _random.Next(1, 7);
            _sum = _throw1 + _throw2;
            int index = _sum - 2; // -2 omdat totaal van 2 de index 0 krijgt in array
            _totals[index]++;
        }

        private void Simulation()
        {
            _throw1 = _random.Next(1, 7);
            _throw2 = _random.Next(1, 7);
            _sum = _throw1 + _throw2;
        }

        private void throwButton_Click(object sender, RoutedEventArgs e)
        {
            Simulation();
            throw1TextBox.Text = _throw1.ToString();
            throw2TextBox.Text = _throw2.ToString();
            throwTotalTextBox.Text = _sum.ToString();
        }

        private void computerButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset alle waardes
            _sum = 0;
            Array.Clear(_totals, 0, _totals.Length);

            // Maak TextBoxes leeg
            throw1TextBox.Clear();
            throw2TextBox.Clear();
            throwTotalTextBox.Clear();

            // Simulaties
            for (int i = 0; i < MaxNumberOfComputerThrows; i++)
                ComputerSimulation();

            // Toon resultaten
            for (int i = 0; i < _totals.Length; i++)
            {
                TextBox textBox = totalCanvas.Children.OfType<TextBox>().ElementAt(i);
                textBox.Text = _totals[i].ToString();
            }
            totalComputerTextBox.Text = MaxNumberOfComputerThrows.ToString();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
