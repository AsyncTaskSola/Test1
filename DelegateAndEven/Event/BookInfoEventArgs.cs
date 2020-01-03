using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateAndEvent.Event
{
    public class BookInfoEventArgs : EventArgs
    {
        public string BookName { get; set; }

        public BookInfoEventArgs(string bookname)
        {
            BookName = bookname; 
        }
    }
}
