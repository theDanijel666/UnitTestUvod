using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Calculator.Models;

namespace Calculator_test
{
    public class CalculatorTestsDynamic
    {

        [Theory]
        [InlineData(5,7,12)]
        [InlineData(6,8,14)]
        [InlineData(-7,9,2)]
        [InlineData(-5,5,0)]
        [InlineData(-666,666,0)]
        [InlineData(int.MinValue,-1,int.MaxValue)]
        //[InlineData(1,1,1)]
        //[InlineData(5,7)]
        //[InlineData(6,3,4,14)]
        //[InlineData(9,3,"12")]
        public void Calculator_Standard_theory_Test_Success(int first, int second,int expected)
        {
            var calculator=new Calculator();

            var result = calculator.Addition(first, second);

            Assert.Equal(expected, result);
        }
    }
}
