using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Calculator.Models;

namespace Calculator_test
{
    public class CalculatorTestsStatic
    {
        [Fact]
        public void Calculator_Standard_Static_Test_Success()
        {
            var calc=new Calculator();

            int first = 6;
            int second = 7;

            var result=calc.Addition(first, second);

            Assert.Equal(13, result);
        }

        [Fact]
        public void Calculator_Standard_Static_Test_Success1()
        {
            var calc = new Calculator();

            int first = 13;
            int second = 27;

            var result = calc.Addition(first, second);

            Assert.Equal(40, result);
        }

        //[Fact]
        public void Calculator_Standard_Static_Test_Failed()
        {
            var calc = new Calculator();

            int first = 15;
            int second = 7;

            var result = calc.Addition(first, second);

            Assert.Equal(100, result);
        }

    }
}
