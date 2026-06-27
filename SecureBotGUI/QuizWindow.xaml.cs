using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SecureBotGUI
{
    public partial class QuizWindow : Window
    {
        private ActivityLogWindow? logWindow;
        private List<(string Question, string[] Options, int CorrectIndex)> questions = new();
        private int currentIndex = 0;
        private int score = 0;
        private int maxQuestions = 0;
        private bool endlessMode = false;

        public QuizWindow()
        {
            InitializeComponent();
        }

        public QuizWindow(ActivityLogWindow log) : this()
        {
            logWindow = log;
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            currentIndex = 0;
            endlessMode = false;

            string? difficulty = (DifficultySelector.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (string.IsNullOrEmpty(difficulty))
            {
                MessageBox.Show("Please select a difficulty.");
                return;
            }

            if (difficulty.Contains("Easy"))
            {
                maxQuestions = 5;
                questions = LoadEasyQuestions();
            }
            else if (difficulty.Contains("Medium"))
            {
                maxQuestions = 10;
                questions = LoadMediumQuestions();
            }
            else if (difficulty.Contains("Hard"))
            {
                maxQuestions = 15;
                questions = LoadHardQuestions();
            }
            else if (difficulty.Contains("Endless"))
            {
                endlessMode = true;
                questions = LoadEasyQuestions();
            }
            else if (difficulty.Contains("Impossible"))
            {
                maxQuestions = 20;
                questions = LoadHardQuestions();
            }

            logWindow?.AddLog($"Quiz started ({difficulty})");
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (!endlessMode && currentIndex >= maxQuestions)
            {
                int wrongAnswers = maxQuestions - score;
                double percent = ((double)score / maxQuestions) * 100;

                ResultText.Text =
                    $"Quiz finished!\n" +
                    $"Total Questions: {maxQuestions}\n" +
                    $"Correct: {score}\n" +
                    $"Wrong: {wrongAnswers}\n" +
                    $"Score: {percent:F1}%";

                logWindow?.AddLog($"Quiz finished with score {score}/{maxQuestions} ({percent:F1}%)");

                // Unlock bonus questions if in Impossible mode and score >= 60%
                if (DifficultySelector.SelectedItem is ComboBoxItem item &&
                    item.Content.ToString().Contains("Impossible") &&
                    score >= 60)
                {
                    MessageBox.Show("🔥 Congratulations! You unlocked Impossible Bonus Questions!");
                    LoadImpossibleQuestions();
                    currentIndex = 0;
                    ShowQuestion();
                }
                return;
            }

            var q = questions[currentIndex % questions.Count];
            QuestionText.Text = q.Question;
            Option1.Content = q.Options[0];
            Option2.Content = q.Options[1];
            Option3.Content = q.Options[2];
            Option4.Content = q.Options[3];

            Option1.IsChecked = Option2.IsChecked = Option3.IsChecked = Option4.IsChecked = false;
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            var q = questions[currentIndex % questions.Count];
            int selectedIndex = -1;

            if (Option1.IsChecked == true) selectedIndex = 0;
            else if (Option2.IsChecked == true) selectedIndex = 1;
            else if (Option3.IsChecked == true) selectedIndex = 2;
            else if (Option4.IsChecked == true) selectedIndex = 3;

            if (selectedIndex == -1)
            {
                MessageBox.Show("Please select an answer.");
                return;
            }

            if (selectedIndex == q.CorrectIndex)
            {
                score++;
                ResultText.Text = "✅ Correct!";
                logWindow?.AddLog($"Correct answer: {q.Question}");
            }
            else
            {
                ResultText.Text = "❌ Incorrect.";
                logWindow?.AddLog($"Incorrect answer: {q.Question}");
            }

            currentIndex++;
            ShowQuestion();
        }

        // -------------------------
        // Question Sets
        // -------------------------
        private List<(string, string[], int)> LoadEasyQuestions() => new()
        {
            ("Which of these is a common cyber attack?", new[] { "Phishing", "Jogging", "Cooking", "Driving" }, 0),
            ("What does HTTPS stand for?", new[] { "HyperText Transfer Secure", "HyperText Transmission Protocol Secure", "HyperText Transfer Protocol Secure", "HyperText Transfer Protocol Standard" }, 2),
            ("Which of these is a strong password?", new[] { "123456", "password", "Qw!9z$T7", "abc123" }, 2),
            ("What does VPN stand for?", new[] { "Virtual Private Network", "Very Personal Notebook", "Verified Protocol Node", "Virtual Public Net" }, 0),
            ("Which of these is NOT malware?", new[] { "Trojan", "Worm", "Spyware", "Spreadsheet" }, 3)
        };

        private List<(string, string[], int)> LoadMediumQuestions() => new()
        {
            ("What is the main purpose of a firewall?", new[] { "Block unauthorized access", "Cook data faster", "Encrypt passwords", "Speed up internet" }, 0),
            ("What is phishing usually trying to steal?", new[] { "User credentials", "Shoes", "Car keys", "Music files" }, 0),
            ("Which protocol secures email communication?", new[] { "SMTP", "IMAP", "TLS", "POP3" }, 2),
            ("What is social engineering in cybersecurity?", new[] { "Manipulating people to reveal info", "Building social networks", "Programming social apps", "Encrypting social data" }, 0),
            ("Which of these is a two‑factor authentication method?", new[] { "Password only", "Password + SMS code", "Username only", "PIN only" }, 1),
            ("What does ransomware do?", new[] { "Deletes files permanently", "Encrypts files and demands payment", "Steals music", "Improves performance" }, 1),
            ("Which of these is a secure way to connect to Wi‑Fi?", new[] { "WEP", "Open Wi‑Fi", "WPA2", "No password" }, 2),
            ("What is the safest way to handle suspicious email attachments?", new[] { "Open them immediately", "Delete without opening", "Forward to friends", "Save to desktop" }, 1),
            ("Which organization defines internet security standards?", new[] { "ISO", "IEEE", "IETF", "All of the above" }, 3),
            ("What is the purpose of encryption?", new[] { "Make data unreadable without a key", "Speed up downloads", "Compress files", "Delete old files" }, 0)
        };

        private List<(string, string[], int)> LoadHardQuestions() => new()
        {
            ("Which encryption algorithm is considered quantum-resistant?", new[] { "RSA", "AES", "Lattice-based", "DES" }, 2),
            ("What is the maximum key size for AES?", new[] { "128-bit", "192-bit", "256-bit", "512-bit" }, 2),
            ("Which attack exploits timing differences in cryptographic operations?", new[] { "Phishing", "Side-channel", "Brute force", "SQL injection" }, 1),
            ("What does OWASP stand for?", new[] { "Open Web Application Security Project", "Official Web App Security Protocol", "Online Web Attack Safety Program", "Open Worldwide App Security Plan" }, 0),
            ("Which hashing algorithm is considered broken?", new[] { "SHA-256", "MD5", "SHA-3", "Blake2" }, 1)
        };

        private void LoadImpossibleQuestions()
        {
            questions = new List<(string, string[], int)>
            {
                ("Which port does HTTPS typically use?", new[] { "80", "21", "443", "22" }, 2),
                ("Which protocol is used for secure remote login?", new[] { "FTP", "SSH", "Telnet", "SMTP" }, 1),
                ("Which attack involves injecting malicious SQL?", new[] { "Phishing", "SQL Injection", "Cross-site scripting", "Brute force" }, 1),
                ("Which cybersecurity framework is widely used in the US?", new[] { "NIST", "ISO 27001", "GDPR", "PCI DSS" }, 0),
                ("Which type of malware disguises itself as legitimate software?", new[] { "Trojan", "Worm", "Spyware", "Rootkit" }, 0)
            };

            maxQuestions = questions.Count;
            logWindow?.AddLog("Impossible bonus questions unlocked!");
        }
    }
}

