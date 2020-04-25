namespace Robot
{
    public interface IPacketParser
    {
        Vector Convert(string input);
    }

    public class PacketParser : IPacketParser
    {
        private double kmin = 1000;
        private double max = 2000;
        private double zero = 1500;
        public Vector Convert(string input)
        {
            var left = int.Parse(input.Substring(4, 4));
            var right = int.Parse(input.Substring(8, 4));
            
            return new Vector()
            {
                ForwardtoBackward = (left - zero) / (max - zero),
                LeftToRight = (right - zero) / (max - zero)
            };
        }
    }
}