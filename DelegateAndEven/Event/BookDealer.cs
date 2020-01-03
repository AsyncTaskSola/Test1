using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Event
{
    /// <summary>
    /// 书商
    /// </summary>
    public class BookDealer
    {
        //泛型委托，定义两个参数，一个object sender ，第二个是泛型 TEventArgs 的e
        //public delegate void NewBookInfoEventHandler(object obj, EventArgs e);

        //public event NewBookInfoEventHandler NewBookInfo;

        //简化
        public event EventHandler<BookInfoEventArgs> NewBookInfo;

        public void NewBook(string bookName)
        {
            UpdateNewBookInfo(bookName);
        }

        public void UpdateNewBookInfo(string bookName)
        {
            NewBookInfo?.Invoke(this,new BookInfoEventArgs(bookName));
        }

    }
}
