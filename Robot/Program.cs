using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var motorHat = new MotorHat())
            {
                // MotorNumber can be 1, 2, 3 or 4, following the labbelling in the board: M1, M2, M3 or M4
                var motor = motorHat.CreateDCMotor(1); 

                // Speed goes from -1 to 1, where -1 is max backward speed, 1 is max forward speed and 0 means stopping the motor
                motor.Speed = 1; 
            }
        }
    }
}