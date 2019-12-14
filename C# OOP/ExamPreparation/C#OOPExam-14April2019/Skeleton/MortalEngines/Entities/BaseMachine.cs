using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get => pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            double difference = Math.Abs(this.AttackPoints - target.DefensePoints);

            target.HealthPoints = Math.Max(target.HealthPoints - difference, 0);

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- {this.Name:f2}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:f2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:f2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:f2}");

            if (this.Targets.Count > 0)
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }
            else
            {
                sb.AppendLine(" *Targets: None");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
