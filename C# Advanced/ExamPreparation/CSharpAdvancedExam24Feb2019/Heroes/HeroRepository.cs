using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> data;
        public int Count => this.data.Count;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            var currentHero = data.Where(x => x.Name == name).FirstOrDefault();
            this.data.Remove(currentHero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            return data.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        }

        public Hero GetHeroWithHighestAbility()
        {
            return data.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            return data.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var hero in data)
            {
                sb.AppendLine($"Hero: {hero.Name} – {hero.Level}lvl");
                sb.AppendLine("Item:");
                sb.AppendLine($"  * Strength: {hero.Item.Strength}");
                sb.AppendLine($"  * Ability: {hero.Item.Ability}");
                sb.AppendLine($"  * Intelligence: {hero.Item.Intelligence}");
            }

            return sb.ToString().Trim();
        }
    }
}
