using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Event3
{
    public class EventInfo
    {
        //public delegate void FireEvenHandle(Person person, FireEventArgs eventArgs);
    }
    public class FireEventArgs : EventArgs
    {
        public Animal Animal { get; set; }
    }
    public class Person
    {
        public EventHandler<FireEventArgs> FirEventHandler;
        //public void RunInfo()
        //{
        //    FirEventHandler?.Invoke(this, new FireEventArgs());
        //}

        #region 第二种写法
        //public delegate void FireEventHandle(Person person, FireEventArgs eventArgs);
        //private event FireEventHandle fireEventHandler;
        ////封装委托类型的事件
        //public event FireEventHandle Fire
        //{
        //    add
        //    {
        //        //添加事件处理器 
        //        //value:在订阅事件时添加的事件处理器
        //        this.fireEventHandler += value;
        //    }
        //    remove
        //    {
        //        //移除事件处理器
        //        this.fireEventHandler -= value;
        //    }
        //}
        #endregion
        public string Name { get; set; }

        public void OnFire(FireEventArgs e)
        {
            Console.WriteLine($"{Name}正在开枪");
            if (FirEventHandler != null)
            {
                FirEventHandler.Invoke(this, e);
            }
        }
    }

    public class Animal
    {
        public string Name { get; set; }

        public void Action(object obj, FireEventArgs e)
        {
            Console.WriteLine("由于" + ((Person)obj).Name + "开枪，" + e.Animal.Name + "受到了惊吓。"); if (e.Animal.Name == "鸟")
            {
                Console.WriteLine(e.Animal.Name + "飞了");
            }
        }
        #region 第二种写法
        //internal void Action(Person sender, FireEventArgs e)
        //{
        //    Console.WriteLine("由于" + sender.Name + "开枪，" + e.Animal.Name + "受到了惊吓。"); if (e.Animal.Name == "鸟") { Console.WriteLine(e.Animal.Name + "飞了"); }
        //}
        #endregion
    }
}
