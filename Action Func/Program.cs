using System;

namespace Action_Func
{
    /// <summary>
    /// func 有返回值  Action 无返回值
    /// </summary>
    class Program
    {
        private delegate string Say();
        static void Main(string[] args)
        {
            #region Func部分
            #region solution1
            //Say sa = SayDemo;
            #endregion

            #region solution2   func<TResult>
            Func<string> sa = SayDemo;
            #endregion

            #region solution3   Func<T,TResult>  T为传入类型：string  以最后的那个类型为返回类型
            //Func<string, int> sa3 = Count;
            //Console.WriteLine(sa3("4"));
            //Int32 Count(string number)
            //{
            //    return Convert.ToInt32(number);
            //}
            #endregion
            //Console.WriteLine(sa());

            #region solution4  Func<T1,T2,TResult>  也可以和匿名的方法一起用

            string text = "the func demo";
            Func<string, int, string[]> ExtractMeth = delegate (string s, int i)
            {
                char[] delimiters = new char[] { ' ' };
                return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
            };
            #region lumbda 写法
            //Func<string, int, string[]> LumbdaExtractMeth = (s,i)=>
            //{
            //    char[] delimiters = new char[] { ' ' };
            //    return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
            //};
            #endregion
            foreach (var work in ExtractMeth(text, 3))
            {
                Console.WriteLine(work);
            }
            #endregion
            #endregion

            #region Action 部分
            #region solution1
            Action say = SayDemoForAction;
            say();
            #endregion

            #region solution2 Action<T>
            Action<string> SayType = SayDemoForActionType;
            SayType("SayDemoForActionType");
            #endregion

            #region Action Lambda
            Action<string> action = a => { Console.WriteLine(a); };
            action("ActionLambda");
            #endregion
            #endregion
        }
        public static string SayDemo()
        {
            return "saydemo";
        }

        public static void SayDemoForAction()
        {
            Console.WriteLine("SayDemoForAction");
        }

        public static void SayDemoForActionType(string word)
        {
            Console.WriteLine(word);
        }
    }
}
