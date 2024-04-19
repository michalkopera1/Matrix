using matrix;
using System;


var matrix1 = new Matrix2D(1, 2, 3, 4);
var matrix2 = new Matrix2D(67, 62, 7, 8);

Console.WriteLine("Macierz 1 :");
Console.WriteLine(matrix1);
Console.WriteLine("Macierz 2 :");
Console.WriteLine(matrix2);

var sum = matrix1 + matrix2;
Console.WriteLine("Dodawanie Macierzy 1 i Macierzy 2 :");
Console.WriteLine(sum);

var difference = matrix1 - matrix2;
Console.WriteLine("Odejmowanie Macierzy 1 i Macierzy 2:");
Console.WriteLine(difference);

var product = matrix1 * matrix2;
Console.WriteLine("Mnożenie Macierzy 1 i Macierzy 2:");
Console.WriteLine(product);

var scalarProduct = 2 * matrix1;
Console.WriteLine("Mnożenie skalarne Macierzy i liczby:");
Console.WriteLine(scalarProduct);

var determinant = matrix1.Determinant();
Console.WriteLine("Wyznacznik Macierzy 1:");
Console.WriteLine(determinant);


var transpose = matrix1.Transpose();
Console.WriteLine("Transpozycja Macierzy 1:");
Console.WriteLine(transpose);



try
{
    var parsedMatrix = Matrix2D.Parse("[[1, 2], [3, 4]]");
    Console.WriteLine("Sparsowana Macierz z ciągu znaków:");
    Console.WriteLine(parsedMatrix);
}
catch (FormatException ex)
{
    Console.WriteLine("Nie udało się sparsować macierzy: " + ex.Message);
}
