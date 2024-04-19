using NUnit.Framework;
using Matrix2DTests;
using matrix;

namespace Matrix2DTests
{
    [TestFixture]
    public class Matrix2DTests
    {
        [Test]
        public void Constructor_WithParameters_SetsValuesCorrectly()
        {
            var matrix = new Matrix2D(20, 30, 40, 50);
            Assert.That(matrix.ToString(), Is.EqualTo("[[20, 30], [40, 50]]"));
        }

        [Test]
        public void Addition_OfTwoMatrices_ReturnsCorrectMatrix()
        {
            var matrix1 = new Matrix2D(20, 30, 40, 50);
            var matrix2 = new Matrix2D(10, 15, 20, 25);
            var expected = new Matrix2D(30, 45, 60, 75);
            Assert.That(matrix1 + matrix2, Is.EqualTo(expected));
        }

        [Test]
        public void Multiplication_OfTwoMatrices_ReturnsCorrectMatrix()
        {
            var matrix1 = new Matrix2D(20, 30, 40, 50);
            var matrix2 = new Matrix2D(10, 15, 20, 25);
            var expected = new Matrix2D(20 * 10 + 30 * 20, 20 * 15 + 30 * 25, 40 * 10 + 50 * 20, 40 * 15 + 50 * 25);
            Assert.That(matrix1 * matrix2, Is.EqualTo(expected));
        }

        [Test]
        public void ScalarMultiplication_MultipliesMatrixCorrectly()
        {
            var matrix = new Matrix2D(20, 30, 40, 50);
            var scalar = 2;
            var expected = new Matrix2D(40, 60, 80, 100);
            Assert.That(scalar * matrix, Is.EqualTo(expected));
        }

        [Test]
        public void Determinant_OfMatrix_ReturnsCorrectValue()
        {
            var matrix = new Matrix2D(20, 30, 40, 50);
            var expectedDeterminant = 20 * 50 - 30 * 40;
            Assert.That(matrix.Determinant(), Is.EqualTo(expectedDeterminant));
        }

        [Test]
        public void Transpose_OfMatrix_ReturnsCorrectTranspose()
        {
            var matrix = new Matrix2D(20, 30, 40, 50);
            var expected = new Matrix2D(20, 40, 30, 50);
            Assert.That(matrix.Transpose(), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_ValidString_ReturnsCorrectMatrix()
        {
            var expected = new Matrix2D(1, 2, 3, 4);
            Assert.That(Matrix2D.Parse("[[1, 2], [3, 4]]"), Is.EqualTo(expected));
        }

        [Test]
        public void Parse_InvalidString_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(() => Matrix2D.Parse("[[1, 2] [3, 4]]"));
        }
    }
}
