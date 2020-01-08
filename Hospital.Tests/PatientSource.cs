using System;
using Xunit;

namespace Hospital.Tests
{
    /// <summary>
    /// ������Դ
    /// </summary>
    public class PatientSource
    {
        [Fact]
        public void HaveHeartBeatWhenNew()
        {
            #region solution 1
            //var patient = new Patient();
            //Assert.True(patient.IsNew);

            //Assert.False(patient.IsNew); ���Դ���
            #endregion

            #region solution 2

            var patient = new Patient()
            {
                FirstName = "Evan",
                LastName = "Huang"
            };
            //Assert.Equal("Evan Huang", patient.FullName,ignoreCase:true);   //string�����ִ�дд�ģ������ں���Ӹ�������-���ִ�Сд

            //�����Ƿ������ص��ַ���
            Assert.Contains("Ev", patient.FullName);//acual ʵ��Ч��
            #endregion

            #region solution3 ������ʽmatches ����FirstName��LastName ��д�Ƿ����ִ�Сд
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
