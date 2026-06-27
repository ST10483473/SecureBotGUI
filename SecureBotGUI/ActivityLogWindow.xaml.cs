using System.IO;
using System.Windows;

namespace SecureBotGUI
{
    public partial class ActivityLogWindow : Window
    {
        public ActivityLogWindow()
        {
            InitializeComponent();
        }

        public void AddLog(string message)
        {
            LogList.Items.Add($"{System.DateTime.Now}: {message}");
        }

        private void ClearLog_Click(object sender, RoutedEventArgs e)
        {
            LogList.Items.Clear();
        }

        private void ExportLog_Click(object sender, RoutedEventArgs e)
        {
            string path = "ActivityLog.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in LogList.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
            MessageBox.Show($"Log exported to {path}");
        }
    }
}
