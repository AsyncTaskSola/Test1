using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Event2
{
    /// <summary>
    /// 事件拥有者   
    /// </summary>
    public class Man
    {
        //人的事件(这里用了执行无参数无返回值方法的委托类型)
        public event Action Fire;

        //封装事件的类方法
        public void ManAction()
        {
            if (Fire != null)
            {
                Console.WriteLine("有人开枪了");
            }

            //触发事件【事件本身 开火】
            Fire();
        }
    }
}
