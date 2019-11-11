using System;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            private set
            {
                if (value > 0)
                {
                    this.length = value; ;
                }
                else
                {
                    throw new Exception($"Length cannot be zero or negative.");
                }
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (value > 0)
                {
                    this.width = value; ;
                }
                else
                {
                    throw new Exception($"Width cannot be zero or negative.");
                }
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (value > 0)
                {
                    this.height = value; ;
                }
                else
                {
                    throw new Exception($"Height cannot be zero or negative.");
                }
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * (this.Height * this.Width) + 2 * (this.Height * this.Length) + 2 * (this.Width * this.Length);
        }

        public double GetVolume()
        {
            return this.Height * this.Width * this.Length;
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * this.Height * (this.Length + this.Width);
        }

        public override string ToString()
        {
            var surface = GetSurfaceArea();
            var lateralSurface = GetLateralSurfaceArea();
            var volume = GetVolume();

            var sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {surface:f2}");
            sb.AppendLine($"Lateral Surface Area - {lateralSurface:f2}");
            sb.AppendLine($"Volume - {volume:f2}");

            return sb.ToString().Trim();
        }
    }
}
