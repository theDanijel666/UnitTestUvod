using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Calculator.Models;

namespace Calculator_test
{
    public class CalculatorTestClassData
    {

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void Calculator_ClassData_Theory_Test_success(int first,int second,int expected)
        {
            var calc = new Calculator();
            
            var res=calc.Addition(first,second);

            Assert.Equal(expected,res);
        }
    }

    public class CalculatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 2, 6, 8 };
            yield return new object[] { -2, -6, -8 };
            yield return new object[] { -2, 6, 4 };
            yield return new object[] { 6, 8, 14 };
            yield return new object[] { int.MinValue, -1, int.MaxValue };
            yield return new object[] { int.MinValue, int.MaxValue, -1 };
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
