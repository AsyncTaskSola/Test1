using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Patient
    {
        public Patient()
        {
            IsNew = true;
            _bloodSugar = 5.0f;
        }
        #region 血糖部分
        private float _bloodSugar; 
        public float BloodSugar
        {
            get { return _bloodSugar; }
            set { _bloodSugar = value; }
        }

        public void HaveDinner()
        {
            var random = new Random();
            _bloodSugar += (float) random.Next(1, 1000) / 1000;
        }
        #endregion

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        /// <summary>
        /// 心跳记录
        /// </summary>
        public int HeartBeatRate { get; set; }

        public bool IsNew { get; set; }
        /// <summary>
        /// 增加心跳率
        /// </summary>
        public void IncreaseHeartBeatBate()
        {
            HeartBeatRate = CalculateHearBeatRate() + 2;
        }
        /// <summary>
        /// 计算心跳率
        /// </summary>
        /// <returns></returns>
        private int CalculateHearBeatRate()
        {
            var random=new Random();
            return random.Next(1, 100);
        }

    }
 

}
