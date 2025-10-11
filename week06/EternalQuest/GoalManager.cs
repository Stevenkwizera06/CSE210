using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private List<Achievement> _achievements;
        private int _level;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
            _level = 1;
            _achievements = new List<Achievement>();
            InitializeAchievements();
        }

        public void Start()
        {
            bool quit = false;
            while (!quit)
            {
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. View Achievements");
                Console.WriteLine("  7. Quit");
                Console.Write("Select a choice from the menu: ");
                
                string choice = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoalDetails();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        ViewAchievements();
                        break;
                    case "7":
                        quit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            UpdateLevel();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine($"Your current level: {_level}");
            Console.WriteLine($"Points to next level: {GetPointsToNextLevel()}");
        }

        public void ListGoalNames()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("The types of goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            
            string goalType = Console.ReadLine() ?? "";
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine() ?? "";
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine() ?? "";
            Console.Write("What is the amount of points associated with this goal? ");
            int points = int.Parse(Console.ReadLine() ?? "0");

            Goal goal = null;

            switch (goalType)
            {
                case "1":
                    goal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    goal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    int target = int.Parse(Console.ReadLine() ?? "1");
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine() ?? "0");
                    goal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    return;
            }

            if (goal != null)
            {
                _goals.Add(goal);
                Console.WriteLine("Goal created successfully!");
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                return;
            }

            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            int goalIndex = int.Parse(Console.ReadLine() ?? "0") - 1;

            if (goalIndex >= 0 && goalIndex < _goals.Count)
            {
                Goal goal = _goals[goalIndex];
                goal.RecordEvent();
                
                int pointsEarned = goal.GetPoints();
                _score += pointsEarned;

                // Check if it's a checklist goal that was just completed
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    int bonusPoints = checklistGoal.GetBonus();
                    _score += bonusPoints;
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                    Console.WriteLine($"Bonus! You earned an additional {bonusPoints} points for completing the goal!");
                }
                else
                {
                    Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                }
                
                CheckAchievements();
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void SaveGoals()
        {
            string filename = "goals.txt";
            
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            
            Console.WriteLine("Goals saved successfully!");
        }

        public void LoadGoals()
        {
            string filename = "goals.txt";
            
            if (!File.Exists(filename))
            {
                Console.WriteLine("No saved goals found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            
            if (lines.Length > 0)
            {
                _score = int.Parse(lines[0] ?? "0");
            }

            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                Goal goal = null;

                switch (goalType)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(goalData[3]);
                        goal = new SimpleGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                        if (isComplete)
                        {
                            goal.RecordEvent();
                        }
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(goalData[0], goalData[1], int.Parse(goalData[2]));
                        break;
                    case "ChecklistGoal":
                        int points = int.Parse(goalData[2]);
                        int bonus = int.Parse(goalData[3]);
                        int target = int.Parse(goalData[4]);
                        int amountCompleted = int.Parse(goalData[5]);
                        
                        goal = new ChecklistGoal(goalData[0], goalData[1], points, target, bonus);
                        for (int j = 0; j < amountCompleted; j++)
                        {
                            goal.RecordEvent();
                        }
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }

        // Creative features to exceed requirements
        private void InitializeAchievements()
        {
            _achievements.Add(new Achievement("First Steps", "Earn your first 100 points", 100));
            _achievements.Add(new Achievement("Goal Setter", "Create your first goal", 0));
            _achievements.Add(new Achievement("Dedicated", "Earn 500 points", 500));
            _achievements.Add(new Achievement("Spiritual Warrior", "Earn 1000 points", 1000));
            _achievements.Add(new Achievement("Eternal Seeker", "Earn 2500 points", 2500));
            _achievements.Add(new Achievement("Master of Goals", "Complete 5 different goals", 0));
        }

        private void UpdateLevel()
        {
            int newLevel = (_score / 1000) + 1;
            if (newLevel > _level)
            {
                Console.WriteLine($"🎉 LEVEL UP! You are now level {newLevel}! 🎉");
                _level = newLevel;
            }
        }

        private int GetPointsToNextLevel()
        {
            int pointsForCurrentLevel = (_level - 1) * 1000;
            int pointsForNextLevel = _level * 1000;
            return pointsForNextLevel - _score;
        }

        private void ViewAchievements()
        {
            Console.WriteLine("🏆 ACHIEVEMENTS 🏆");
            Console.WriteLine("==================");
            
            foreach (Achievement achievement in _achievements)
            {
                string status = achievement.IsUnlocked() ? "✅ UNLOCKED" : "🔒 LOCKED";
                Console.WriteLine($"{status} - {achievement.GetName()}: {achievement.GetDescription()}");
            }
            
            Console.WriteLine();
        }

        private void CheckAchievements()
        {
            foreach (Achievement achievement in _achievements)
            {
                if (achievement.CheckUnlock(_score))
                {
                    Console.WriteLine($"🏆 ACHIEVEMENT UNLOCKED: {achievement.GetName()}! 🏆");
                    Console.WriteLine($"   {achievement.GetDescription()}");
                    Console.WriteLine();
                }
            }
        }
    }
}
