using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int CubicCentimetersForType = 125;
        private const int MinHorsePower = 50;
        private const int MaxHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CubicCentimetersForType)
        {
        }

        public override int HorsePower
        {
            get => base.HorsePower;
            protected set
            {
                if (value < MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                base.HorsePower = value;
            }
        }
    }
}
