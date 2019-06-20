using System;
using CoreMedia;
using Security;

namespace MathSkia.Classes
{
    public struct Point
    {
        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        public readonly int X;
        public readonly int Y;
    }
    public class ProjectilePhysics
    {
        private const float GravAccelleration = -9.8f;
        private readonly float _velocity;
        private readonly int _launchElevation;
        private readonly double _launchAngle;
        private double HorizontalVelocity => _velocity * Math.Cos(_launchAngle);
        private double VerticalVelocity => _velocity * Math.Sin(_launchAngle);
        
        public Point Position (double t) => new Point(GetXPos(t),GetYPos(t));


        private int GetXPos(double t)
        {
            return (int) Math.Round(_launchElevation + HorizontalVelocity * t + 0.5 * 0 * Math.Pow(t, 2));
        }

        private int GetYPos(double t)
        {
            return (int) Math.Round(_launchElevation + VerticalVelocity * t + 0.5 * GravAccelleration * Math.Pow(t, 2));
        }
        
        
        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public double CalculateTimeOfFlight()
        {
            if (_launchElevation > 0)
            {
                //t = [Vy + √(Vy² + 2 * g * h)] / g
                return (VerticalVelocity +
                        Math.Sqrt(Math.Pow(VerticalVelocity, 2) + 2 * GravAccelleration * _launchElevation)) /
                       GravAccelleration;
            }
            return 2 * VerticalVelocity / GravAccelleration;
        }


        public ProjectilePhysics(float velocity, int launchElevation, int launchAngle)
        {
            this._velocity = velocity;
            this._launchElevation = launchElevation;
            this._launchAngle = ProjectilePhysics.DegreeToRadian(launchAngle);
        }
    }
}