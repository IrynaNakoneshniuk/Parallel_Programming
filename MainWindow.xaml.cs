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
using System.Windows.Threading;

namespace Parallel_Programming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Analyzer analyzer = new Analyzer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btStart_Click(object sender, RoutedEventArgs e)
        {
            Task<int>[] tasks = new Task<int>[5];
            try
            {
                if (chbAmountWord.IsChecked == true)
                {
                    tasks[0] = analyzer.GetAmountWordsAsync(tbContent.Text);
                    int words = await tasks[0];
                    tbReport.Text += $"\nAmount of words:{words.ToString()} ";
                }
                if (chbAmountSentences.IsChecked == true)
                {
                    tasks[1] = analyzer.GetAmountSentenceAsync(tbContent.Text);
                    int sentence = await tasks[1];
                    tbReport.Text += $"\nAmount of sentences:{sentence.ToString()} ";
                }
                if (chbAmountSym.IsChecked == true)
                {
                    tasks[2] = analyzer.GetAmountSymbolsAsync(tbContent.Text);
                    int sym = await tasks[2];
                    tbReport.Text += $"\nAmount of symbols:{sym.ToString()} ";
                }
                if (chbAmountInterrogative.IsChecked == true)
                {
                    tasks[3] = analyzer.GetAmountInterrogativeAsync(tbContent.Text);
                    int Interrogative = await tasks[3];
                    tbReport.Text += $"\nAmount of interrogative sentences:{Interrogative.ToString()} ";
                }
                if (chbAmountExclamation.IsChecked == true)
                {
                    tasks[4] = analyzer.GetAmountExclamationAsync(tbContent.Text);
                    int Exclamation = await tasks[4];
                    tbReport.Text += $"\nAmount of exclamation sentences:{Exclamation.ToString()} ";
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }
        }
    }
}
