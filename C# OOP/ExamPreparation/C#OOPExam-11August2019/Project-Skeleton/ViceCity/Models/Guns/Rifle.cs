using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int BulletsCountPerShot = 5;

        public Rifle(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsCountPerShot > this.BulletsPerBarrel)
            {
                this.Reload();
            }

            if (this.CanFire)
            {
                this.BulletsPerBarrel -= BulletsCountPerShot;
                return BulletsCountPerShot;
            }

            return 0;
        }

        private void Reload()
        {
            if (this.TotalBullets > 0)
            {
                this.BulletsPerBarrel = InitialBulletsPerBarrel;
                this.TotalBullets -= InitialBulletsPerBarrel;
            }
        }
    }
}
