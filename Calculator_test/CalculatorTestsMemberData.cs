using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Calculator.Models;

namespace Calculator_test
{
    public class CalculatorTestsMemberData
    {

        [Theory]
        [MemberData(nameof(CalculatorData))]
        public void Calculator_Memberdata_Theory_Test_Success(int first, int second, int expected)
        {
            var calc=new Calculator();

            var res=calc.Addition(first, second);

            Assert.Equal(expected, res);
        }

        public static IEnumerable<object[]> CalculatorData {
            get
            {
                return new List<object[]>
                {
                    new object[] {5,7,12},
                    new object[] {-5,-7,-12},
                    new object[] {-5,5,0},
                    new object[] {int.MinValue,-1,int.MaxValue},
                    new object[] {54,6,60}
                };
            } 
        }
    }
}
