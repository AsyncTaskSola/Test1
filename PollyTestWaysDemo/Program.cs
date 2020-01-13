using Polly;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PollyTestWaysDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            #region solution1 Polly默认处理策略需要指定抛出的具体异常或者执行抛出异常返回的结果
            //try
            //{
            //    var retryTwoTimesPolicy = Policy.Handle<DivideByZeroException>()
            //        .Retry(3, (ex, count) =>
            //            {
            //                Console.WriteLine($"执行失败重试的次数为{count}");
            //                Console.WriteLine($"异常错误{0}，{ex.GetType().Name}");
            //            }
            //        );
            //    retryTwoTimesPolicy.Execute(() => { Compute(); });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            #endregion

            #region solution2 指定处理多个异常类型通过OR即可

            //try
            //{
            //    var politicaWaitAndRetry = Policy
            //        .Handle<DivideByZeroException>()
            //        .WaitAndRetry(new[]
            //        {
            //            TimeSpan.FromSeconds(1),
            //            TimeSpan.FromSeconds(3),
            //            TimeSpan.FromSeconds(5),
            //            TimeSpan.FromSeconds(7)
            //        }, ReportaError);
            //    politicaWaitAndRetry.Execute(() =>
            //    {
            //        ZeroExcepcion();
            //    });
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Executed Failed,Message:({e.Message})");
            //}
            #endregion

            #region solution 反馈策略，执行失败后返回的结果
            var fallBackPolicy =
                Policy<string>
                    .Handle<Exception>()
                    .Fallback("执行失败，返回Fallback");
            var fallback = fallBackPolicy.Execute(() => { return ThrowException(); });
            Console.WriteLine(fallback);

            var politicaWaitAndRetrys = Policy<string>.Handle<Exception>().Retry(3,
                (ex, Count) => { Console.WriteLine($"执行失败,重试{Count} 异常来自 {ex.GetType().Name}"); });
            var mixedPolicy = Policy.Wrap(fallBackPolicy, politicaWaitAndRetrys);
            var mixresult = mixedPolicy.Execute(() => { return ThrowException(); });
            Console.WriteLine($"执行结果{mixresult}");
            #endregion
        }
        static int Compute()
        {
            var a = 0;
            return 1 / a;
        }

        /// <summary>
        /// 抛出异常
        /// </summary>
        static void ZeroExcepcion()
        {
            throw new DivideByZeroException();
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        /// <param name="e"></param>
        /// <param name="time"></param>
        /// <param name="intento">意图</param>
        /// <param name="context"></param>
        static void ReportaError(Exception e, TimeSpan time, int intento, Context context)
        {
            Console.WriteLine($"异常: {intento:00} (调用秒数: {time.Seconds} 秒)\t执行时间: {DateTime.Now}");
        }

        static string ThrowException()
        {
            throw new Exception();
        }
    }

}
