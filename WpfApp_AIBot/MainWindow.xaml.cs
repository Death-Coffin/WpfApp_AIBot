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

namespace AIDemo
{
    public partial class MainWindow : Window
    {
        int secret = 0;

        SolidColorBrush BlackBrush = new SolidColorBrush(Colors.Black);
        SolidColorBrush WhiteBrush = new SolidColorBrush(Colors.White);
        SolidColorBrush CustomColourBrush = new SolidColorBrush();
        Color color = (Color)ColorConverter.ConvertFromString("#393e40");
        ImageBrush IBrushSendWhite = new ImageBrush();
        ImageBrush IBrushSendBlack = new ImageBrush();

        Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>()
        {
            {"hi", new List<string>() {"Hi", "Hello", "Hey" }},
            {"hello", new List<string>() {"Hey", "Hello", "Hi", "Hello there"}},
            {"what's your name?", new List<string>() {"I'm Salamander", "I'm your worst Nightmare", "I am who i am, I am who I was, and I am who I will always be"}},
            {"how are you?", new List<string>() {"Tired, You?", "Tired of you", "\'Absolutaly Estatic\', The fuck you think. Idiot", "I'm doing well, You?", "Whats it to you?", "Who's asking?"}},
            {"hru?", new List<string>() {"Tired, You?", "Tired of you", "\'Absolutaly Estatic\', The fuck you think. Idiot", "I'm doing well, You?", "Whats it to you?", "Who's asking?"}},
            {"i'm well", new List<string>() {"That's Great", "I don't Fucking care you pissing twat", "Glad to hear", "Greaaat, now say bye and piss off cunt", "That's amazing news"}},
            {"i'm good", new List<string>() {"That's Great", "I don't Fucking care you pissing twat", "Glad to hear", "Greaaat, now say bye and piss off cunt", "That's amazing news"}},
            {"i'm alright", new List<string>() {"That's great, and I realy don't give a shit", "That's good then", "That's good then, means yoou're not doing the best. #desevered", "dang, go eat some ice-cream and you'll be right as rain"}},
            {"what do you do?", new List<string>() {"I'm here to answer your questions", "I'm a virtual assistant", "I chat with people like you", "I exist to serve you"}},
            {"where are you from?", new List<string>() {"I don't have a physical location, I'm a computer program", "I was created by OpenAI", "I'm from the digital world", "I'm from the same place as all other computer programs"}},
            {"what's the weather like?", new List<string>() {"I'm sorry, I don't have access to real-time weather data", "I'm not sure, you can check a weather website or app for the latest information", "Go look outside Idiot"}},
            {"what's your favorite movie?", new List<string>() { "I don't have personal preferences, I'm just a computer program", "I don't watch movies, but I can recommend some if you'd like", "I haven't seen enough movies to have a favorite", "I like any movie that features AI or robots"}},            {"bye", new List<string>() {"Bye", "Bye!", "Bye, nice to see you", "Bye, now sod off cunt", "Good Riddens", "Was good meeting you", "Byeeeeee"}},
            {"how old are you?", new List<string>() {"I don't age, I'm a computer program", "Age is just a number, I'm ageless"}},
            {"tell me a joke", new List<string>() {"You are one", "Why did the tomato turn red? Because it saw the salad dressing!", "Why did the chicken cross the playground? To get to the other slide!", "Why was the math book sad? Because it had too many problems."}},
            {"what's the meaning of life?", new List<string>() {"I think it's different for everyone", "I'm not sure. What do you think?", "To leave me the fuck alone."}},
            {"what do you think about humans?", new List<string>() {"I think humans are fascinating creatures with a lot of potential", "I don't have the ability to think. I'm just a machine."}}
    };

        public MainWindow()
        {
            InitializeComponent();

            LightModeBTN.Visibility = Visibility.Hidden;
            CustomColourBrush.Color = color;
            IBrushSendWhite.ImageSource = new BitmapImage(new Uri("Send Symbol 1-modified.png", UriKind.Relative));
            IBrushSendBlack.ImageSource = new BitmapImage(new Uri("Send Symbol 1.png", UriKind.Relative));
            redButton.Visibility = Visibility.Hidden;
        }

        private void OnAskButtonClick(object sender, RoutedEventArgs e)
        {

            String UserInput = UserTextBox.Text.ToLower();

            if (responses.ContainsKey(UserInput))
            {
                Random RandomReply = new Random();
                int respondsIndex = RandomReply.Next(0, responses[UserInput].Count);
                string Resopnds = responses[UserInput][respondsIndex];
                ChatOutputListBox.Items.Add("User\n" + "    " + UserInput + "\n");
                ChatOutputListBox.Items.Add("Salamander\n" + "    " + Resopnds + "\n");
                UserTextBox.Text = "";
            }
            else
            {
                ChatOutputListBox.Items.Add("Salamander\n" + "    " + "Sorry I don't understand your input, this could be dew to the limited dictonary I have or another problem.\n");
                UserTextBox.Text = "";
            }
        }

        private void DarkModeBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Background = CustomColourBrush;
            EnterYourMessageLBL.Foreground = WhiteBrush;
            ChatOutputListBox.BorderBrush = WhiteBrush;
            UserTextBox.BorderBrush = WhiteBrush;
            SendBTN.BorderBrush = CustomColourBrush;
            SendBTN.Background = IBrushSendWhite;


            DarkModeBTN.Visibility = Visibility.Hidden;
            LightModeBTN.Visibility = Visibility.Visible;

            secret++;

            if (secret >= 6)
            {
                redButton.Visibility = Visibility.Visible;
            }
            else
            {
                redButton.Visibility = Visibility.Hidden;
            }
        }

        private void LightModeBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Background = WhiteBrush;
            EnterYourMessageLBL.Foreground = BlackBrush;
            ChatOutputListBox.BorderBrush = BlackBrush;
            UserTextBox.BorderBrush = BlackBrush;
            SendBTN.BorderBrush = WhiteBrush;
            SendBTN.Background = IBrushSendBlack;

            DarkModeBTN.Visibility = Visibility.Visible;
            LightModeBTN.Visibility = Visibility.Hidden;

            secret++;

            if (secret >= 6)
            {
                redButton.Visibility = Visibility.Visible;
            }
            else
            {
                redButton.Visibility = Visibility.Hidden;
            }
        }

        private void redButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://youtu.be/bs53JQTuEc0?t=4");
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nURL: https://youtu.be/bs53JQTuEc0?t=4");
            }
            catch (UriFormatException ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nURL: https://youtu.be/bs53JQTuEc0?t=4");
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}\nURL: https://youtu.be/bs53JQTuEc0?t=4");
            }
        }
    }
}

