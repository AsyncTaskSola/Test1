using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
            _bloodSugar += (float)random.Next(1, 1000) / 1000;
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
            var random = new Random();
            return random.Next(1, 100);
        }

        #region 浮点型数值的assert 
        public abstract class Worker
        {
            public string Name { get; set; }
            /// <summary>
            /// 总奖赏
            /// </summary>
            public abstract double TotalReward { get; }

            public abstract double Hours { get; }
            public double Salary => TotalReward / Hours;
            public List<string> Tools { get; set; }
        }
        /// <summary>
        /// 水管工
        /// </summary>
        public class Plumber : Worker
        {
            public Plumber()
            {
                Tools = new List<string>
                {
                    "刀",
                    "叉"
                };
            }
            public override double TotalReward => 200;
            public override double Hours => 3;
        }
        #endregion

        #region 针对object类型的assert
        public class Programmer : Worker
        {
            public override double TotalReward => 1000;
            public override double Hours => 3.5;
        }
        public class WorkerFactory
        {
            public Worker Create(string name, bool isProgrammer = false)
            {
                if (name == null)
                {
                    throw new  ArgumentNullException(nameof(name));
                }
                if (isProgrammer)
                {
                    return new Programmer { Name = name };
                }
                return new Plumber() { Name = name };
            }
        }
        #endregion
    }


}
