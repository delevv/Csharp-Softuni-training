using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (CheckStat(value))
                {
                    throw new Exception("Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (CheckStat(value))
                {
                    throw new Exception("Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (CheckStat(value))
                {
                    throw new Exception("Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                if (CheckStat(value))
                {
                    throw new Exception("Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (CheckStat(value))
                {
                    throw new Exception("Shooting should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }

        public double SkillLevel => (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;

        private bool CheckStat(int value)
        {
            if (value < 0 || value > 100)
            {
                return true;
            }
            return false;
        }
    }
}
