using System;
using Xunit;

namespace Hospital.Tests
{
    /// <summary>
    /// 病人来源
    /// </summary>
    public class PatientSource
    {
        [Fact]
        public void HaveHeartBeatWhenNew()
        {
            #region solution 1
            //var patient = new Patient();
            //Assert.True(patient.IsNew);

            //Assert.False(patient.IsNew); 测试错误
            #endregion

            #region solution 2

            var patient = new Patient()
            {
                FirstName = "Evan",
                LastName = "Huang"
            };
            //Assert.Equal("Evan Huang", patient.FullName,ignoreCase:true);   //string是区分大写写的，可以在后面加个属性来-区分大小写

            //测试是否包含相关的字符串
            Assert.Contains("Ev", patient.FullName);//acual 实际效果
            #endregion

            #region solution3 正则表达式matches 测试FirstName和LastName 首写是否区分大小写
            var p = new Patient()
            {
                FirstName = "Evan",
                LastName = "Huang"
            };
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", p.FullName);
            #endregion
        }

        [Fact]
        public void BloodSugerStartWithDefaultValue()
        {
            var p=new Patient();
            Assert.Equal(5.0,p.BloodSugar);
        }

        [Fact]
        public void BooldSugereIncreaseAfterDinner()
        {
            var p=new Patient();
            p.HaveDinner();
            Assert.InRange(p.BloodSugar,5,6);
            Assert.True(p.BloodSugar >= 5 && p.BloodSugar <= 6);
        }

    }
}
