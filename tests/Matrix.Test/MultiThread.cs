using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace Matrix.Test
{
    [TestClass]
    public class MultiThread
    {
        [TestMethod]
        public void SimpleDimple()
        {
            Matrix matrix = new Matrix();

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(2);

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void RandomTestSize4Thread1()
        {
            Matrix matrix = new Matrix(4);

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(1);

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void RandomTestSize4Thread2()
        {
            Matrix matrix = new Matrix(4);

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(2);

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void RandomTestSize4Thread4()
        {
            Matrix matrix = new Matrix(4);

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(4);

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void RandomTestSize8Thread4()
        {
            Matrix matrix = new Matrix(8);

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(4);

            Assert.AreEqual(assert, actual);
        }

        [TestMethod]
        public void RandomTestSize10Thread4()
        {
            Matrix matrix = new Matrix(10);

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(4);

            Assert.AreEqual(assert, actual);
        }
    }
}
