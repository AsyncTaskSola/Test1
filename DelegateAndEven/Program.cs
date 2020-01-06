using System;
using DelegateAndEvent.Event;
using DelegateAndEvent.Event2;
using DelegateAndEvent.Event3;

namespace DelegateAndEvent
{
    /// <summary>
    /// 多播委托和事件Event
    ///-------------------------------------------
    /// .Net Framework的编码规范：
    //一、委托类型的名称都应该以EventHandler结束
    //二、委托的原型定义：有一个void，并接受两个输入参数：一个Object 类型，一个 EventArgs类型(或继承自EventArgs)
    //三、事件的命名为 委托去掉 EventHandler之后剩余的部分
    //四、继承自EventArgs的类型应该以EventArgs结尾
    //---------------------------------------------
    /// </summary>
    class Program
    {

        #region solution3
    
        #endregion

        static void Main(string[] args)
        {
            #region solution1
            Predicate<int> predicate = FindPoints;
            var points = new int[] { 10, 50, 60, 80, 100 };
            var result = Array.FindAll(points, predicate);
            //  Console.WriteLine($"结果为{string.Join(";", result)}");
            #endregion

            #region  solution2  多播委托
            Action<double> action = MultiplyByTwo;
            //action(1);
            action += Squate;
            action(2);
            #endregion

            #region solution3  Event 事件是基于委托，为委托提供一种发布/订阅机制，声明事件需要使用event关键字
            //我们可以知道Object sender参数代表的是事件发布者本身，而EventArgs e 也就是监视对象了
            var dealer=new BookDealer();
            var consumer1=new Consumer("用户1");
            //左边事件的拥有者和事件本身  右边是事件的订阅者和处理器
            dealer.NewBookInfo += consumer1.NewBookHere;
            dealer.NewBook("book112");

            var consumer2 = new Consumer("用户B");
            dealer.NewBookInfo += consumer2.NewBookHere;
            dealer.NewBook("book_abc");
            #endregion

            #region solution4
            Man man=new Man();
            //左边事件的拥有者和事件本身  右边是事件的订阅者和处理器
            man.Fire += Bird.Fly;
            for (int i = 0; i < 5; i++)
            {
                Bird bird=new Bird();
                bird.birdName = "小鸟";
            }
            //调用封装事件的方法，触发事件
            man.ManAction();
            #endregion

            #region MyRegion

            Person parson = new Person { Name = "Your Name" };

            Animal anime = new Animal { Name = "鸟" };

            parson.FirEventHandler += anime.Action;

            parson.OnFire(new FireEventArgs { Animal = anime });

            #endregion
        }

        public static bool FindPoints(int a)
        {
            return a > 60;
        }

        public static void MultiplyByTwo(double v)
        {
            var result = v * 2;
            Console.WriteLine($"传值：{v};MultiplyByTwode的结果为{result}");
        }

        public static void Squate(double v)
        {
            var result = v * v;
            Console.WriteLine($"传值：{v};Squate的结果为{result}");
        }
    }
}
