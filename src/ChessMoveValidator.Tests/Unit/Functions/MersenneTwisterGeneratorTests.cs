namespace ChessMoveValidator.Tests.Unit.Functions
{
    using System;
    using System.Collections.Generic;

    using ChessMoveValidator.BusinessLogic.Functions;

    using NUnit.Framework;

    [TestFixture]
    public class MersenneTwisterGeneratorTests
    {
        [Test]
        public void Generate_WhenGivenNoSeed_ShouldReturnRandomNumber()
        {
            var g = new MersenneTwister();

            var n = g.Next();

            Assert.That(n > 0);
        }

        [Test]
        public void Generate_WhenGivenSeed_ShouldReturnRandomNumber()
        {
            var g = new MersenneTwister(1024);

            var n = g.Next();

            Assert.That(n > 0);
        }

        [Test]
        public void GenerateUInt_WhenGivenNoSeed_ShouldReturnRandomNumber()
        {
            var g = new MersenneTwister();

            var n = g.Next();
            var l = Convert.ToUInt64(n);

            Assert.That(l > 0);
        }

        [Test]
        public void GenerateUIntSequence_WhenGivenNoSeed_ShouldReturnRandomNumberSequence()
        {
            var g = new MersenneTwister();

            var list = new List<ulong>();

            for (var i = 0; i < 781; ++i)
            {
                var n = g.Next();
                var l = Convert.ToUInt64(n);

                list.Add(l);
            }

            Assert.That(list.Count  == 781);
            Assert.That(list, Is.Unique);

            list.ForEach(Console.WriteLine);
        }

        [Test]
        public void GenerateUIntHexSequence_WhenGivenNoSeed_ShouldReturnRandomHexNumberSequence()
        {
            var g = new MersenneTwister();

            var list = new List<string>();

            for (var i = 0; i < 781; ++i)
            {
                var n = g.Next();
                var l = Convert.ToUInt64(n);

                list.Add(string.Format("0x{0:X}UL", l | l << 32));
            }

            Assert.That(list.Count == 781);
            Assert.That(list, Is.Unique);

            // Validate that keys are correct when converted to uint and back again
            list.ForEach(
                x =>
                    {
                        var u = Convert.ToUInt64(x.Substring(0, x.Length - 2), 16);
                        var s = string.Format("0x{0:X}UL", u | u << 32);

                        Assert.That(s == x);
                    });

            list.ForEach(Console.WriteLine);
        }
    }
}