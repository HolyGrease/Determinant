using System;

namespace Matrix
{
    public class Matrix
    {
        private int[,] matrix;

        public Matrix() {
            matrix = new int[2,2] {{1, 0}, {0, 1}};
        }

        public int Determinant() {
            return 0;
        }
    }
}
