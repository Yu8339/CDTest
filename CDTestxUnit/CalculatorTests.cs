using CDTestLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDTestxUnit
{
    public class CalculatorTests
    {
        [Fact]
        public void Test_Add()
        {
            var calc = new Calculator();
            Assert.Equal(4, calc.Add(1, 3));
        }
    }
}
