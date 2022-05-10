using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrimeCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 N , M;
            int nThreads;
            Int64.TryParse(args[0],out N);
            Int64.TryParse(args[1], out M);
            int.TryParse(args[2], out nThreads);
            Int64 jump = (M - N) / nThreads;
            Thread[] threads = new Thread[nThreads];
            for(int index = 0; index < nThreads; index++)
            {
                if (N + jump < M)
                {
                    new Thread(() => prime(N, N+jump)).Start();

                    Thread.Sleep(1);
                    N += jump+1;
                }
                else
                {
                    threads[index] = new Thread(() => prime(N, M));
                    threads[index].Start();
                }
            }

        }

        static void prime(Int64 n, Int64 m)
        {
            bool flag;

            for (Int64 i = n; i <= m; i++)
            {
                flag = true;
                for(Int64 j = 3; j <= (int)Math.Floor(Math.Sqrt(i)); j+=2)
                {
                    if(i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if( i > 1 && i%2 == 0)
                {
                    flag = false;
                }
                if (flag)
                {
                    Console.WriteLine("Thread [{0}]: {1}",System.Threading.Thread.CurrentThread.ManagedThreadId, i);
                }
            }
        }
    }
}
