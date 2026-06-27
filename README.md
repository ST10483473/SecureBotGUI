# SecureBotGUI
# SecureBotGUI – Cybersecurity Chatbot

## 📌 About

SecureBotGUI is a WPF application that was created to teach users about cybersecurity and online safety in a simple and interactive way.

The purpose of this app is to help users understand different cybersecurity topics like phishing, passwords, firewalls, and safe internet habits. The application includes a chatbot, quiz game, task assistant, activity log, user profile system, and NLP demo.

The app is designed so that only one main feature window is open at a time. This helps make the program easier to use and prevents the user from getting confused with many windows open.

The Activity Log is the only exception because it can open as a small side window while the MainWindow stays open.

---

# 🚀 How to Run

To run the SecureBotGUI application:

1. Open the project folder in Visual Studio.
2. Make sure the project is using .NET 8 or later.
3. Build the solution to check that there are no errors.
4. Press the **Start** button to launch the application.

If any errors happen during building, check that all files are included correctly and that the correct .NET version is installed.

---

# 🎮 How to Use

## MainWindow

The MainWindow is the main home screen of the application. This is where the user starts and interacts with the chatbot.

The user can type a message into the chat box and press the **Send** button to receive a response from the bot.

The chatbot can:

* Answer questions using keywords such as **"vpn"**, **"firewall"**, **"password"**, and **"phishing"**.
* Detect user feelings like **worried**, **curious**, and **frustrated**.
* Give cybersecurity tips when the user asks for help.
* Provide different phishing tips when the user asks for another tip.
* Remember the users name if they type something like **"my name is..."**.
* Recall saved information later during the conversation.

Buttons available in MainWindow:

* **Task Assistant** → Opens the task manager where users can add and manage tasks.
* **Quiz Game** → Opens the cybersecurity quiz.
* **Activity Log** → Opens the activity history window while keeping MainWindow open.
* **NLP Demo** → Opens the text processing demonstration.

---

# UserProfile.cs

The UserProfile class is used to store important user information.

The information saved includes:

* Users name.
* Quiz high score.
* Preferred quiz difficulty.
* Password.

The class contains different methods:

### SetPassword(password)

This method checks the password rules and saves the password if it is strong enough.

The password must include things like enough characters, numbers, and special symbols.

### VerifyPassword(password)

This method checks if the password entered by the user matches the saved password.

### SaveProfile()

This saves the users profile information into a file so the information is not lost when the program closes.

### LoadProfile()

This loads the saved profile information when the application starts again.

---

# TaskAssistantWindow

The Task Assistant allows users to create and manage their own tasks.

Users can:

* Add new tasks.
* View current tasks.
* Clear completed tasks.

This feature can help users remember important cybersecurity actions, for example updating passwords or checking account security.

When the Task Assistant window is closed, the MainWindow will open again automatically.

---

# QuizWindow

The Quiz Window allows users to test their cybersecurity knowledge.

Users can choose different difficulty levels:

* Easy
* Medium
* Hard
* Endless
* Impossible

The quiz gives points depending on correct answers and shows the final score after completing the quiz.

Impossible mode contains extra difficult questions. This mode becomes unlocked when the user gets 60% or higher.

The quiz score is also saved in the UserProfile so users can keep track of their progress.

When the Quiz Window closes, the MainWindow opens again.

---

# ActivityLogWindow

The Activity Log records important actions that happen inside the application.

It can store information about:

* Chat messages.
* Quiz attempts.
* Task changes.
* Other user actions.

The Activity Log has two main buttons:

### Clear Log

Removes all saved activity from the log.

### Export Log

Saves the activity information into a text file called:

**ActivityLog.txt**

This window can open and close freely because it works as a side window and does not close the MainWindow.

---

# NLPWindow

The NLP Demo is used to show how text processing works inside the chatbot.

It allows the user to enter text and shows how the system can read the input and understand basic words or patterns.

This demonstrates how chatbots can use natural language processing to respond to users.

When the NLP Window closes, the MainWindow opens again.

---

# 🛠️ Features

SecureBotGUI includes the following features:

* Chatbot with keyword responses.
* Default responses when the bot does not understand something.
* Sentiment detection for worried, curious, and frustrated users.
* Phishing tips with follow-up conversations.
* Memory system that remembers the users name.
* Quiz game with different difficulty levels.
* Score system and unlockable Impossible mode.
* Task assistant for creating and managing tasks.
* Activity log for recording actions.
* Exporting logs into a text file.
* User profile system for storing information.
* Password checking for better security.
* Saving and loading user data from files.

---

# 📂 Submission Notes

For the project submission:

* Complete at least six GitHub commits with clear descriptions.
* Create two releases on GitHub.
* Submit the GitHub repository link on ARC.
* Upload the Task 2 presentation as an unlisted YouTube video link.

The commits should show the progress of the project and explain what changes were made.

---

# ✅ Credits

Created by Musiki, 2026.

This project was made as part of a cybersecurity chatbot application to help users learn more about online safety.
