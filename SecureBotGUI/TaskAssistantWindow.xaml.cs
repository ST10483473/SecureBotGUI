using System.Windows;

namespace SecureBotGUI
{
    public partial class TaskAssistantWindow : Window
    {
        private ActivityLogWindow? logWindow;

        public TaskAssistantWindow()
        {
            InitializeComponent();
        }

        public TaskAssistantWindow(ActivityLogWindow log) : this()
        {
            logWindow = log;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitle.Text;
            string details = TaskDetails.Text;
            string reminder = ReminderDate.SelectedDate?.ToShortDateString() ?? "No reminder";

            TaskList.Items.Add($"{title} - {details} (Reminder: {reminder})");
            logWindow?.AddLog($"Task added: {title}");
        }

        private void ClearTasks_Click(object sender, RoutedEventArgs e)
        {
            TaskList.Items.Clear();
            logWindow?.AddLog("All tasks cleared.");
        }
    }
}
