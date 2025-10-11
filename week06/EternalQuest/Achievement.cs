using System;

namespace EternalQuest
{
    public class Achievement
    {
        private string _name;
        private string _description;
        private int _pointsRequired;
        private bool _unlocked;

        public Achievement(string name, string description, int pointsRequired)
        {
            _name = name;
            _description = description;
            _pointsRequired = pointsRequired;
            _unlocked = false;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetDescription()
        {
            return _description;
        }

        public int GetPointsRequired()
        {
            return _pointsRequired;
        }

        public bool IsUnlocked()
        {
            return _unlocked;
        }

        public void Unlock()
        {
            _unlocked = true;
        }

        public bool CheckUnlock(int currentScore)
        {
            if (!_unlocked && currentScore >= _pointsRequired)
            {
                _unlocked = true;
                return true;
            }
            return false;
        }
    }
}
