using System;
using System.Threading;
using ThreadPool;

namespace Matrix
{
    public class Matrix
    {
        private int[][] matrix;

        public Matrix()
        {
            matrix = new int[2][] {new int[]{1, 0}, new int[]{0, 1}};
        }

        public Matrix(uint size)
        {
            Random random = new Random();

            this.matrix = new int[size][];

            for (int i = 0; i < size; i++)
            {
                this.matrix[i] = new int[size];
                for (int j = 0; j < size; j++)
                    this.matrix[i][j] = random.Next();
            }
                
        }

        public Matrix(int[][] matrix)
        {
            this.matrix = matrix;
        }

        public int Determinant()
        {
            return Matrix.Determinant(this.matrix);
        }
        
        public static int Determinant(int[][] matrix)
        {
            int det = 0;
            if (matrix.Length != matrix[0].Length)
                return -1;
            if (matrix.Length == 1)
                return matrix[0][0];

            for (int i = 0; i < matrix.Length; i++)
                det += (int)Math.Pow(-1, i) * matrix[0][i] * Determinant(Minor(matrix, i));

            return det;
        }

        public static int[][] Minor(int[][] matrix, int pos)
        {
            int[][] minor = new int[matrix.Length - 1][];
            for (int i = 0; i < minor.Length; i++)
                minor[i] = new int[minor.Length];

            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 0; j < pos; j++)
                    minor[i - 1][j] = matrix[i][j];
                for (int j = pos + 1; j < matrix.Length; j++)
                    minor[i - 1][j - 1] = matrix[i][j];
            }
            return minor;
        }
        
        public int[][] Trim(uint row, uint col)
        {
            int[][] result = new int[this.matrix.Length - 1][];

            for (uint i = 0, j = 0; i < this.matrix.Length; i++)
            {
                if (i == row)
                    continue;

                result[j] = new int[this.matrix.Length - 1];

                for (uint k = 0, u = 0; k < this.matrix.Length; k++)
                {
                    if (k == col)
                        continue;

                    result[j][u] = this.matrix[i][k];
                    u++;
                }
                j++;
            }

            return result;
        }

        public void Print()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                    Console.Write(this.matrix[i][j].ToString() + " ");
                Console.WriteLine();
            }
        }

        class Task: ITask<int>
        {
            private int[][] matrix;
            private int value;

            public Task(int[][] matrix, int value)
            {
                this.matrix = matrix;
                this.value = value;
            }

            public int Run()
            {
                return value * Matrix.Determinant(this.matrix);
            }
        }

        public int MultiThreadDeterminant(uint threadNumber)
        {
            ParametrizeThreadPool<int> threadPool = new ParametrizeThreadPool<int>(threadNumber);
            if (matrix.Length != matrix[0].Length)
                return -1;
            if (matrix.Length == 1)
                return matrix[0][0];

            for (int i = 0; i < matrix.Length; i++)
                threadPool.Execute(new Task(this.Trim(0, (uint)i), (int)Math.Pow(-1, i) * matrix[0][i]));
            
            lock (threadPool.results)
            {
                while (threadPool.results.Count != this.matrix.GetLength(0))
                    Monitor.Wait(threadPool.results);
            }

            int det = 0;
            foreach (int value in threadPool.results)
            {
                det += value;
            }
            return det;
        }
    }
}
