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
        internal void Action(Person sender, FireEventArgs e)
        {
            Console.WriteLine("由于" + sender.Name + "开枪，" + e.Animal.Name + "受到了惊吓。"); if (e.Animal.Name == "鸟") { Console.WriteLine(e.Animal.Name + "飞了"); }
        }
    }
}
