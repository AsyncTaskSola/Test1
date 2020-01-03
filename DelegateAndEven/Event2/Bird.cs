using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Event2
{
    public class Bird
    {
        public string birdName { get; set; }

        //声明一个集合类型的静态字段，用于保存实例化的所有Bird类
        public static List<Bird> Birds = new List<Bird>();

        //鸟对开枪事件的处理器 【事件处理器】
        internal static void Fly()
        {
            for (int i = 0; i < Birds.Count; i++)
            {
                Console.WriteLine(Birds[i].birdName+i
                +"飞走了");//飞走了鸟是订阅者
            }
        }

        public Bird()
        {
            Birds.Add(this);
        }
    }
}
