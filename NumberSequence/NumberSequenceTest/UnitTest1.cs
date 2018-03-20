using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using NumberSequence;
using NumberSequence.Abstract;

namespace NumberSequenceTest
{
    [TestClass]
    public class UnitTest1
    {
        private NumberSequence.NumberSequenceCounter numberSequence;


        [TestMethod]
        public void WriteSequence_Should_Only_Write_Numbers_Between_1_And_100()
        {
            Mock<IOutput> mockOutput = new Mock<IOutput>();
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>())).Callback<int>(i =>
            {
                i.Should().BeGreaterThan(NumberSequenceCounter.MIN_COUNT - 1);
                i.Should().BeLessThan(NumberSequenceCounter.MAX_COUNT + 1);
            });
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>(), It.IsAny<string>())).Callback<int, string>((i, m) =>
            {
                i.Should().BeGreaterThan(NumberSequenceCounter.MIN_COUNT - 1);
                i.Should().BeLessThan(NumberSequenceCounter.MAX_COUNT  + 1);
            });
            numberSequence = new NumberSequenceCounter(mockOutput.Object);
            numberSequence.WriteSequence();
        }

        [TestMethod]
        public void WriteMessage_Should_Write_All_Integers_Between_1_And_100()
        {
            List<int> counter = new List<int>();
            Mock<IOutput> mockOutput = new Mock<IOutput>();
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>())).Callback<int>(i =>
            {
                counter.Add(i);
            });
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>(), It.IsAny<string>())).Callback<int, string>((i, m) =>
            {
                counter.Add(i);
            });
            numberSequence = new NumberSequenceCounter(mockOutput.Object);
            numberSequence.WriteSequence();
            var uniqueInts = counter.Distinct();
            uniqueInts.Min().Should().Be(NumberSequenceCounter.MIN_COUNT);
            uniqueInts.Max().Should().Be(NumberSequenceCounter.MAX_COUNT);
            uniqueInts.Count().Should().Be(100);
        }

        [TestMethod]
        public void WriteSequence_Should_Not_Display_Message_For_Non_Multiples_Of_3_Or_5()
        {
            Mock<IOutput> mockOutput = new Mock<IOutput>();
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>())).Callback<int>(i =>
            {
                var multipleOf3 = i % NumberSequenceCounter.ANSIBLE_NUMBER;
                var multipleOf5 = i % NumberSequenceCounter.AUSTRALIA_NUMBER;
                multipleOf3.Should().NotBe(0);
                multipleOf5.Should().NotBe(0);
            });
            numberSequence = new NumberSequenceCounter(mockOutput.Object);
            numberSequence.WriteSequence();
        }

        [TestMethod]
        public void WriteSequence_Should_Write_Ansible_For_Multiples_Of_3()
        {
            Mock<IOutput> mockOutput = new Mock<IOutput>();
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>(), It.IsAny<string>())).Callback<int, string>((i, message) =>
            {
                var multipleOf3 = i % NumberSequenceCounter.ANSIBLE_NUMBER;
                var multipleOf5 = i % NumberSequenceCounter.AUSTRALIA_NUMBER;
                if (multipleOf3 == 0 && multipleOf5 != 0)
                {
                    message.Should().Be(NumberSequenceCounter.ANSIBLE);
                }
                else
                {
                    message.Should().NotBe(NumberSequenceCounter.ANSIBLE);
                }
            });
            numberSequence = new NumberSequenceCounter(mockOutput.Object);
            numberSequence.WriteSequence();
        }

        [TestMethod]
        public void WriteSequence_Should_Write_Australia_For_Multiples_Of_5()
        {
            Mock<IOutput> mockOutput = new Mock<IOutput>();
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>(), It.IsAny<string>())).Callback<int, string>((i, message) =>
            {
                var multipleOf3 = i % NumberSequenceCounter.ANSIBLE_NUMBER;
                var multipleOf5 = i % NumberSequenceCounter.AUSTRALIA_NUMBER;
                if (multipleOf5 == 0 && multipleOf3 != 0)
                {
                    message.Should().Be(NumberSequenceCounter.AUSTRALIA);
                }
                else
                {
                    message.Should().NotBe(NumberSequenceCounter.AUSTRALIA);
                }
            });
            numberSequence = new NumberSequenceCounter(mockOutput.Object);
            numberSequence.WriteSequence();
        }

        [TestMethod]
        public void WriteSequence_Should_Write_Ansible_Australia_For_Multiples_Of_5_And_3()
        {
            Mock<IOutput> mockOutput = new Mock<IOutput>();
            mockOutput.Setup(x => x.WriteLine(It.IsAny<int>(), It.IsAny<string>())).Callback<int, string>((i, message) =>
            {
                var multipleOf3 = i % NumberSequenceCounter.ANSIBLE_NUMBER;
                var multipleOf5 = i % NumberSequenceCounter.AUSTRALIA_NUMBER;
                if (multipleOf5 == 0 && multipleOf3 == 0)
                {
                    message.Should().Be(NumberSequenceCounter.ANSIBLE_AUSTRALIA);
                }
                else
                {
                    message.Should().NotBe(NumberSequenceCounter.ANSIBLE_AUSTRALIA);
                }
            });
            numberSequence = new NumberSequenceCounter(mockOutput.Object);
            numberSequence.WriteSequence();
        }
    }
}
