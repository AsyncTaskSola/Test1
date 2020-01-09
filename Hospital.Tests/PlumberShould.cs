using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Hospital.Tests
{

    public class PlumberShould
    {
        #region solution 1
        /// <summary>
        /// 正确的薪水  
        /// </summary>
        [Fact]
        public void HaveCorrenctSalary()
        {
            var plumber = new Patient.Plumber();
            //错误 单元测试
            //Assert.Equal(66.666, plumber.Salary);
            Assert.Equal(66.667, plumber.Salary, precision: 3);//精确度
        }
        #endregion

        #region solution2 null的问题
        [Fact]
        public void HaveCorrenctName()
        {
            var p = new Patient.Plumber()
            {
                Name = "Evan Huang"
            };
            Assert.NotNull(p.Name);
        }
        #endregion

        #region solution3  contains
        [Fact]
        public void HaveKnife()
        {
            var p = new Patient.Plumber();
            Assert.Contains("刀", p.Tools);
            //Assert.DoesNotContain("刀", p.Tools);
            Assert.Contains(p.Tools, t => t.Contains("刀"));
            Assert.All(p.Tools,t=>Assert.False(string.IsNullOrEmpty(t)));
        }
        #endregion
    }
}
