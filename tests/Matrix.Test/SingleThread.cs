using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace Matrix.Test
{
    [TestClass]
    public class OneThread
    {
        [TestMethod]
        public void SimpleDimple()
        {
            Matrix matrix = new Matrix();

            var assert = 1;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void IdentityMatrixSize2()
        {
            Matrix matrix = new Matrix(new int[,] {{1, 0}, {0, 1}});

            var assert = 1;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void IdentityMatrixSize3()
        {
            Matrix matrix = new Matrix(new int[,] {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}});

            var assert = 1;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void IdentityMatrixSize4()
        {
            Matrix matrix = new Matrix(new int[,] {{1, 0, 0, 0}, {0, 1, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 1}});

            var assert = 1;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void MatrixSize2()
        {
            Matrix matrix = new Matrix(new int[,] {{1, 2}, {3, 4}});

            var assert = -2;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void MatrixSize3()
        {
            Matrix matrix = new Matrix(new int[,] {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}});

            var assert = 0;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void MatrixSize4()
        {
            Matrix matrix = new Matrix(new int[,] {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}});

            var assert = 0;

            var actual = matrix.Determinant();

            Assert.AreEqual(assert, actual);
        }
    }
}
