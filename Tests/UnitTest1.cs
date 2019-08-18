using System;
using Xunit;
using WebApiDummies;
using WebApiDummies.Controllers;

namespace Tests
{
    public class UnitTest1
    {
        ValuesController ValuesController = new ValuesController();



        [Fact]
        public void HiTest()
        {
            var result = ValuesController.GetHi("hello");
            Assert.Equal("hi", result);

        }

        [Fact]
        public void HelloTest()
        {
            var result = ValuesController.GetHello("hi");
            Assert.Equal("hello", result);

        }
    }
}
