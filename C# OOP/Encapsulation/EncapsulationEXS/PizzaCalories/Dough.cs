using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;

        private string bakingTechnique;

        private double weight;

        private Dictionary<string, double> doughs;
       
        private Dictionary<string, double> bakingTechniques;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.doughs = new Dictionary<string, double>
            {
                ["white"] = 1.5,
                ["wholegrain"] = 1.0
            };
            this.bakingTechniques = new Dictionary<string, double>
            {
                ["crispy"] = 0.9,
                ["chewy"] = 1.1,
                ["homemade"] = 1.0
            };
            
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get => this.flourType;
            set
            {
                if (!this.doughs.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                else
                {
                    this.flourType = value;
                }
            }
        }
        private string BakingTechnique
        {
            get => this.bakingTechnique;
            set
            {
                if (!this.bakingTechniques.ContainsKey(value.ToLower()))
                {
                    throw new Exception("Invalid type of dough.");
                }
                else
                {
                    this.bakingTechnique = value;
                }
            }
        }
        private double Weight 
        { 
            get => this.weight;
            set
            {
                if(value<1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        public double GetCalories()
        {
            return (2 * this.Weight) * this.doughs[FlourType.ToLower()] * bakingTechniques[BakingTechnique.ToLower()];
        }
    }
}
