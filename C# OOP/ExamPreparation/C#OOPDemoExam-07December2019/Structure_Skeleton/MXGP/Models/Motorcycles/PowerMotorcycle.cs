using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int CubicCentimetersForType = 450;
        private const int MinHorsePower = 70;
        private const int MaxHorsePower = 100;

        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CubicCentimetersForType)
        {
        }

        public override int HorsePower 
        { 
            get => base.HorsePower; 
            protected set
            {
                if(value<MinHorsePower || value > MaxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                base.HorsePower = value;
            }
        }
    }
}
