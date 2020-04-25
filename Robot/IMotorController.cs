using System;
using Iot.Device.DCMotor;
using Iot.Device.GoPiGo3.Models;

namespace Robot
{
    public interface IMotorController
    {
        void Move(Vector vector);
    }

    class MockMotorController : IMotorController
    {
        public void Move(Vector vector)
        {
            if (vector.LeftToRight > 0)
            {
                Console.WriteLine($"Vroom R : [{vector.ForwardtoBackward - vector.LeftToRight}] L : [{vector.ForwardtoBackward*-1}]");
            }
            else
            {
                Console.WriteLine($"Vroom R : [{vector.ForwardtoBackward}] L : [{(vector.ForwardtoBackward*-1) - vector.LeftToRight}]");
            }
        }
    }

    internal class MotorController : IMotorController
    {
        private MotorHat motorHat;
        private DCMotor leftmotor;
        private DCMotor rightmotor;

        public MotorController()
        {
            motorHat = new MotorHat();
            
            leftmotor = motorHat.CreateDCMotor(1);
            rightmotor = motorHat.CreateDCMotor(2);
        }
        public void Move(Vector vector)
        {
            double lspeed = 0;
            double rspeed = 0;
            if (vector.LeftToRight > 0)
            {
                rspeed = vector.ForwardtoBackward - vector.LeftToRight;
                lspeed = vector.ForwardtoBackward * -1;
            }
            else
            {
                rspeed = vector.ForwardtoBackward - vector.LeftToRight;
                lspeed = (vector.ForwardtoBackward*-1) -vector.LeftToRight;
            }

            leftmotor.Speed = lspeed;
            rightmotor.Speed = rspeed;
        }
    }
}