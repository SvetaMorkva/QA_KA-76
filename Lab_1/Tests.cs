using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lab_1
{
    [TestFixture]
    class Queue_Tests
    {
        [Test]
        public void AddEmployees_ReturnsLength()
        {
            Mock.AddEmployees();
            Assert.AreEqual(7, Mock.employees.Count);
        }

        [Test]
        public void AddEmployees_TestDequeue_ReturnsFirstCountryAndNewLength()
        {
            Mock.AddEmployees();
            Assert.AreEqual("Germany", Mock.employees.Dequeue().Country);
            Assert.AreEqual(6, Mock.employees.Count);
        }

        [Test]
        public void AddEmployees_TestEnqueue_ReturnsNewLength()
        {
            Mock.AddEmployees();
            Mock.employees.Enqueue(new Employee() { Company = "MrPer4ik Inc.", Contact = "Alexander Khomych", Country = "Ukraine" });
            Assert.AreEqual(8, Mock.employees.Count);
        }

        [Test]
        public void AddEmployees_TestPeek_ReturnsFirstCountryAndLength()
        {
            Mock.AddEmployees();
            Assert.AreEqual("Maria Anders", Mock.employees.Peek().Contact);
            Assert.AreEqual(7, Mock.employees.Count);
        }

        [Test]
        public void AddEmployees_TestClear_ReturnsZeroLength()
        {
            Mock.AddEmployees();
            Mock.employees.Clear();
            Assert.AreEqual(0, Mock.employees.Count);
        }
    }
}
