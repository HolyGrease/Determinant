using System;
using System.Diagnostics;

using ThreadPool;
using Matrix;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Benchmarking
            for (uint size = 4; size < 16; size++)
            {
                for (uint threadNumber = 7; threadNumber < 8; threadNumber++)
                {
                    Stopwatch stopwatch = new Stopwatch();
                    Matrix.Matrix matrix = new Matrix.Matrix(size);
                    
                    stopwatch.Start();
                    matrix.MultiThreadDeterminant(threadNumber);
                    stopwatch.Stop();

                    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
                    
                    GC.Collect();

                    stopwatch.Start();
                    matrix.Determinant();
                    stopwatch.Stop();

                    Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

                    Console.WriteLine();
                }
            }
        }
    }
}
