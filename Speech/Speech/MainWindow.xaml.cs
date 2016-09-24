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
using System.Speech.Recognition;

namespace Speech
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Choices commands = new Choices();
            commands.Add(new string[] { "say hi", "print my name", "Hello, I am da da", "I'm fine", "pozdrav", "kako si danas" });
            
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(commands);

            Grammar g = new Grammar(gb);
            recEngine.LoadGrammarAsync(g);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            recEngine.SpeechDetected += recEngine_SpeechDetected;
        }

        void recEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            

        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "say hello":
                    lblSpeech.Content = "Hello there";
                    break;
                case "print my name":
                    lblSpeech.Content += "Hello there Sharp";
                    break;
                case "Hello, I am da da":
                    lblSpeech.Content = "Bok Dada, kako si ?";
                    break;
                case "I'm fine":
                    lblSpeech.Content = "Drago mi je da si dobro";
                    break;
                default:
                    lblSpeech.Content = e.Result.Text;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
