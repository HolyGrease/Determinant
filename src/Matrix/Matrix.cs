using System;
using System.Threading;
using ThreadPool;

namespace Matrix
{
    public class Matrix
    {
        private int[,] matrix;

        public Matrix()
        {
            matrix = new int[2,2] {{1, 0}, {0, 1}};
        }

        public Matrix(uint size)
        {
            Random random = new Random();

            this.matrix = new int[size, size];

            for (int i = 0; i < this.matrix.GetLength(0); i++)
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                    this.matrix[i, j] = random.Next();
        }

        public Matrix(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public int Determinant()
        {
            if (this.matrix.GetLength(0) == 1)
                return this.matrix[0, 0];

            if (this.matrix.GetLength(0) == 2)
                return this.matrix[0, 0] * this.matrix[1, 1] -
                    this.matrix[0, 1] * this.matrix[1, 0];

            int summ = 0;

            for (uint i = 0; i < this.matrix.GetLength(0); i++)
            {
                int value = this.matrix[i, 0] * this.Trim(i, 0).Determinant();
                if (i % 2 == 0)
                    summ += value;
                else
                    summ -= value;
            }
            
            GC.Collect();

            return summ;
        }

        public Matrix Trim(uint row, uint col)
        {
            // TODO add bounds check
            int[,] result = new int[this.matrix.GetLength(0) - 1, this.matrix.GetLength(1) - 1];

            for (uint i = 0, j = 0; i < this.matrix.GetLength(0); i++)
            {
                if (i == row)
                    continue;

                for (uint k = 0, u = 0; k < this.matrix.GetLength(1); k++)
                {
                    if (k == col)
                        continue;

                    result[j, u] = this.matrix[i, k];
                    u++;
                }
                j++;
            }

            return new Matrix(result);
        }

        public void Print()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                    Console.Write(this.matrix[i, j].ToString() + " ");
                Console.WriteLine();
            }
        }

        class Task: ITask<int>
        {
            private Matrix matrix;
            private int value;

            public Task(Matrix matrix, int value)
            {
                this.matrix = matrix;
                this.value = value;
            }

            public int Run()
            {
                return value * this.matrix.Determinant();
            }
        }

        public int MultiThreadDeterminant(uint threadNumber)
        {
            ParametrizeThreadPool<int> threadPool = new ParametrizeThreadPool<int>(threadNumber);

            for (uint i = 0; i < this.matrix.GetLength(0); i++)
            {
                int value = this.matrix[i, 0];
                if (i % 2 != 0)
                    value *= -1;

                threadPool.Execute(new Task(this.Trim(i, 0), value));
            }

            lock (threadPool.results)
            {
                while (threadPool.results.Count != this.matrix.GetLength(0))
                    Monitor.Wait(threadPool.results);
            }

            int summ = 0;
            foreach (int value in threadPool.results)
            {
                summ += value;
            }
            return summ;
        }
    }
}
