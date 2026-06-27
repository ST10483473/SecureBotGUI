using System.Windows;

namespace SecureBotGUI
{
    public partial class MainWindow : Window
    {
        private ActivityLogWindow logWindow; // shared log

        public MainWindow()
        {
            InitializeComponent();
            logWindow = new ActivityLogWindow();
            logWindow.Show(); // open once at startup
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = UserInput.Text;
            if (!string.IsNullOrWhiteSpace(userMessage))
            {
                ChatHistory.AppendText($"You: {userMessage}\n");
                UserInput.Clear();
                logWindow.AddLog($"User sent message: {userMessage}");
            }
        }

        private void TaskAssistant_Click(object sender, RoutedEventArgs e)
        {
            TaskAssistantWindow taskWindow = new TaskAssistantWindow(logWindow);
            taskWindow.Show();
        }

        private void QuizGame_Click(object sender, RoutedEventArgs e)
        {
            QuizWindow quizWindow = new QuizWindow(logWindow);
            quizWindow.Show();
        }

        private void ActivityLog_Click(object sender, RoutedEventArgs e)
        {
            logWindow.Activate();
        }

        private void NLP_Click(object sender, RoutedEventArgs e)
        {
            NLPWindow nlpWindow = new NLPWindow(logWindow);
            nlpWindow.Show();
        }
    }
}
