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
        public void RandomTestSize16Thread4()
        {
            Matrix matrix = new Matrix(12);

            var assert = matrix.Determinant();
            var actual = matrix.MultiThreadDeterminant(4);

            Assert.AreEqual(assert, actual);
        }

        // [TestMethod]
        // public void RandomTestSize32Thread4()
        // {
        //     Matrix matrix = new Matrix(32);

        //     int assert = matrix.Determinant();
        //     int actual = matrix.MultiThreadDeterminant(4);

        //     Assert.AreEqual(assert, actual);
        // }

        // [TestMethod]
        // public void RandomTestSize64Thread4()
        // {
        //     Matrix matrix = new Matrix(64);

        //     int assert = matrix.Determinant();
        //     int actual = matrix.MultiThreadDeterminant(4);

        //     Assert.AreEqual(assert, actual);
        // }

        // [TestMethod]
        // public void RandomTestSize256Thread4()
        // {
        //     Matrix matrix = new Matrix(256);

        //     int assert = matrix.Determinant();
        //     int actual = matrix.MultiThreadDeterminant(4);

        //     Assert.AreEqual(assert, actual);
        // }

        // [TestMethod]
        // public void RandomTestSize512Thread4()
        // {
        //     Matrix matrix = new Matrix(512);

        //     int assert = matrix.Determinant();
        //     int actual = matrix.MultiThreadDeterminant(4);

        //     Assert.AreEqual(assert, actual);
        // }
    }
}
