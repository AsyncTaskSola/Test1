using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Event
{
    /// <summary>
    /// 消费者
    /// </summary>
    public class Consumer
    {
        public string Name { get; set; }
        public Consumer(string name)
        {
            Name = name;
        }

        public void NewBookHere(object obj, BookInfoEventArgs e)
        {
            Console.WriteLine($"用户：{Name},书名{e.BookName}");
        }
    }
}
