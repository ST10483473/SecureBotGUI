using System.Windows;

namespace SecureBotGUI
{
    public partial class NLPWindow : Window
    {
        private ActivityLogWindow? logWindow;

        public NLPWindow()
        {
            InitializeComponent();
        }

        public NLPWindow(ActivityLogWindow log) : this()
        {
            logWindow = log;
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            string input = NLPInput.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter some text to process.");
                return;
            }

            NLPResult.Text = $"Processed text: {input}";
            logWindow?.AddLog($"NLP processed input: {input}");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            NLPInput.Clear();
            NLPResult.Text = "";
            logWindow?.AddLog("NLP input and result cleared.");
        }
    }
}

