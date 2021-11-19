using System;
using System.Diagnostics;
using System.Threading;
using ThreadPool;
using Matrix;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Benchmarking
            for (uint size = 4; size <= 12; size++)
            {
                for (uint threadNumber = 4; threadNumber <= 16; threadNumber *= 2)
                {
                    GC.Collect();
                    
                    Console.WriteLine("Size = {0}, threads number = {1}", size, threadNumber);
                    
                    Stopwatch stopwatch = new Stopwatch();
                    Matrix.Matrix matrix = new Matrix.Matrix(size);
                    
                    stopwatch.Start();
                    matrix.MultiThreadDeterminant(threadNumber);
                    stopwatch.Stop();

                    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                    
                    GC.Collect();
                    Thread.Sleep(2000);
                    GC.Collect();
                    
                    stopwatch.Start();
                    matrix.Determinant();
                    stopwatch.Stop();

                    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                    
                    GC.Collect();
                    
                   

                    Console.WriteLine();
                }
            }
        }
    }
}
