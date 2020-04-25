using NUnit.Framework;
using Robot;

namespace TestProject1
{
    public class PacketParserTests
    {
        [Test]
        public void MoveForward()
        {
            var sut = new PacketParser();
            var vector = sut.Convert("1500200015001500");
        }
        
        [Test]
        public void Turn()
        {
            var sut = new PacketParser();
            var vector = sut.Convert("1500200015001000");
        }
    }
}