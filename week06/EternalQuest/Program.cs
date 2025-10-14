using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest Program!");
            Console.WriteLine("This program helps you track your goals and earn points for your spiritual journey.");
            Console.WriteLine();

            GoalManager goalManager = new GoalManager();
            goalManager.Start();
        }
    }
}

/*
CREATIVE FEATURES TO EXCEED REQUIREMENTS:

1. LEVELING SYSTEM:
   - Users gain levels based on their total points (1000 points per level)
   - Level up notifications with celebration messages (🎉 LEVEL UP!)
   - Display of current level and points needed for next level
   - Automatic level calculation and progression tracking

2. ACHIEVEMENT SYSTEM:
   - 6 different achievements that unlock based on points earned:
     * "First Steps" - Earn your first 100 points
     * "Goal Setter" - Create your first goal
     * "Dedicated" - Earn 500 points
     * "Spiritual Warrior" - Earn 1000 points
     * "Eternal Seeker" - Earn 2500 points
     * "Master of Goals" - Complete 5 different goals
   - Visual indicators (✅ UNLOCKED / 🔒 LOCKED) for achievement status
   - Achievement unlock notifications with celebration messages (🏆 ACHIEVEMENT UNLOCKED!)
   - Dedicated menu option (option 6) to view all achievements

3. ENHANCED USER EXPERIENCE:
   - Emoji usage for visual appeal (🏆, 🎉, ✅, 🔒) throughout the interface
   - Celebration messages for level ups and achievements
   - Clear progress tracking with points to next level display
   - Professional menu layout with numbered options
   - Welcome message and program description

4. GAMIFICATION ELEMENTS:
   - Points-based progression system with level milestones
   - Achievement badges for motivation and engagement
   - Level progression for long-term user engagement
   - Visual feedback for accomplishments and milestones
   - Progress visualization to encourage continued participation

5. TECHNICAL ENHANCEMENTS:
   - Achievement class with unlock logic and status tracking
   - Level calculation methods with automatic updates
   - Enhanced GoalManager with achievement checking
   - Visual status indicators for all achievements
   - Celebration system for user motivation

These features transform the basic goal tracking into an engaging, game-like experience
that motivates users to continue working on their spiritual goals through positive
reinforcement, progress visualization, and achievement-based motivation systems.
The program now feels like a spiritual RPG where users can level up and unlock
achievements as they progress on their eternal quest.
*/
