using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
namespace P05_GreedyTimes
{
    public class Bag
    {
        public Bag(long capacity)
        {
            this.Capacity = capacity;
            this.Cash = new Cash();
            this.Gem = new Gem();
            this.Gold = new Gold();
        }

        public long Capacity { get; set; }

        public Cash Cash { get; set; }

        public Gem Gem { get; set; }

        public Gold Gold { get; set; }

        private long currentCapacity => this.Cash.Items.Values.Sum() + this.Gem.Items.Values.Sum() + this.Gold.Items.Values.Sum();

        public void AddItem(string name, long value)
        {
            if (this.currentCapacity + value <= this.Capacity)
            {
                var goldAmount = this.Gold.Items.Values.Sum();
                var gemAmount = this.Gem.Items.Values.Sum();
                var cashAmount = this.Cash.Items.Values.Sum();

                if (name.ToLower() == "gold")
                {
                    if (goldAmount+value >= gemAmount)
                    {
                        this.Gold.AddGold(name, value);
                    }
                }
                else if (name.Length >= 4 && name.ToLower().EndsWith("gem"))
                {
                    if (gemAmount + value >= cashAmount && gemAmount + value <= goldAmount)
                    {
                        this.Gem.AddGem(name, value);
                    }
                }
                else if (name.Length == 3)
                {
                    if (cashAmount + value <= gemAmount)
                    {
                        this.Cash.AddCash(name, value);
                    }
                }
               
            }
        }
        public override string ToString()
        {
            var currentItems = new Dictionary<string, long>
            {
                ["Gold"]= this.Gold.Items.Values.Sum(),
                ["Gem"] = this.Gem.Items.Values.Sum(),
                ["Cash"] = this.Cash.Items.Values.Sum(),
            };

            var sb = new StringBuilder();

            foreach (var item in currentItems.Where(i=>i.Value>0).OrderByDescending(i=>i.Value))
            {
                if (item.Key == "Gold")
                {
                  sb.AppendLine(this.Gold.ToString());
                }
                else if(item.Key=="Gem")
                {
                    sb.AppendLine(this.Gem.ToString());
                }
                else
                {
                    sb.AppendLine(this.Cash.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
