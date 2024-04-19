namespace matrix
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        private readonly int a, b, c, d;

        public static readonly Matrix2D Id = new(1, 0, 0, 1);
        public static readonly Matrix2D Zero = new(0, 0, 0, 0);

        public Matrix2D(int a, int b, int c, int d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public Matrix2D() : this(1, 0, 0, 1) { }

        public override string ToString()
        {
            return $"[[{a}, {b}], [{c}, {d}]]";
        }

        public bool Equals(Matrix2D? other)
        {
            return other != null && a == other.a && b == other.b && c == other.c && d == other.d;
        }

        public override bool Equals(object? obj)
        {
            return obj is Matrix2D m && Equals(m);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(a, b, c, d);
        }

        public static bool operator ==(Matrix2D? m1, Matrix2D? m2)
        {
            if (ReferenceEquals(m1, m2))
            {
                return true;
            }

            return m1 is not null && m2 is not null && m1.Equals(m2);
        }

        public static bool operator !=(Matrix2D? m1, Matrix2D? m2)
        {
            return !(m1 == m2);
        }

        public static Matrix2D operator +(Matrix2D m1, Matrix2D m2)
        {
            return new Matrix2D(m1.a + m2.a, m1.b + m2.b, m1.c + m2.c, m1.d + m2.d);
        }

        public static Matrix2D operator -(Matrix2D m1, Matrix2D m2)
        {
            return new Matrix2D(m1.a - m2.a, m1.b - m2.b, m1.c - m2.c, m1.d - m2.d);
        }

        public static Matrix2D operator *(Matrix2D m1, Matrix2D m2)
        {
            return new Matrix2D(
                m1.a * m2.a + m1.b * m2.c,
                m1.a * m2.b + m1.b * m2.d,
                m1.c * m2.a + m1.d * m2.c,
                m1.c * m2.b + m1.d * m2.d
            );
        }

        public static Matrix2D operator *(int scalar, Matrix2D m)
        {
            return new Matrix2D(scalar * m.a, scalar * m.b, scalar * m.c, scalar * m.d);
        }

        public static Matrix2D operator *(Matrix2D m, int scalar)
        {
            return scalar * m;
        }

        public static Matrix2D operator -(Matrix2D m)
        {
            return new Matrix2D(-m.a, -m.b, -m.c, -m.d);
        }

        public Matrix2D Transpose()
        {
            return new Matrix2D(a, c, b, d);
        }

        public int Determinant()
        {
            return a * d - b * c;
        }

        public static int Determinant(Matrix2D m)
        {
            return m.Determinant();
        }

        public static explicit operator int[,](Matrix2D m)
        {
            return new[,] { { m.a, m.b }, { m.c, m.d } };
        }

        public static Matrix2D Parse(string s)
        {
            try
            {
                s = s.Trim('[', ']').Replace("],[", ";").Replace("[", "").Replace("]", "");
                var entries = s.Split(';', ',');
                if (entries.Length != 4) throw new FormatException("Ciąg musi zawierać DOKŁADNIE 4 LICZBY!!!!!1");

                static int parseOrThrow(string numberString)
                {
                    if (!int.TryParse(numberString, out int result))
                    {
                        throw new FormatException("Ciąg zawiera nieprawidłowe liczby !1!!");
                    }
                    return result;
                }

                return new Matrix2D(
                    parseOrThrow(entries[0]),
                    parseOrThrow(entries[1]),
                    parseOrThrow(entries[2]),
                    parseOrThrow(entries[3])
                );
            }
            catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
            {
                throw new FormatException("Ciąg jest w złym formacie !!", ex);
            }
        }
    }
}
