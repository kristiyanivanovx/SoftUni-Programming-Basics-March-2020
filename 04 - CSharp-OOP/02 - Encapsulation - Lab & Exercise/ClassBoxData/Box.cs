using System;
using System.Collections.Generic;
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
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length 
        { 
            get => this.length;
            private set 
            {

                this.Validate(value, nameof(Length));
                this.length = value;
            } 
        }

        public double Width 
        { 
            get => this.width; 
            private set
            {
                this.Validate(value, nameof(Width));
                this.width = value;
            }
        }

        public double Height 
        { 
            get => this.height; 
            private set
            {
                this.Validate(value, nameof(Height));
                this.height = value;
            }
        }

        // surface area
        public double GetSurfaceArea()
        {
            double frontAndBack = Length * Height * 2;
            double topAndBottom = Length * Width * 2;
            double leftAndRight = Height * Width * 2;
            return frontAndBack + topAndBottom + leftAndRight;
        }

        // lateral surface area
        public double GetLateralArea()
        {
            double frontAndBack = Length * Height * 2;
            double leftAndRight = Height * Width * 2;
            return frontAndBack + leftAndRight;
        }

        // volume
        public double GetVolume()
        {
            return Length * Width * Height;
        }

        private void Validate(double side, string type)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{type} cannot be zero or negative.");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Surface Area - {this.GetSurfaceArea():f2}")
              .AppendLine($"Lateral Surface Area - {this.GetLateralArea():f2}")
              .AppendLine($"Volume - {this.GetVolume():f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
