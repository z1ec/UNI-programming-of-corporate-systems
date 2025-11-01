using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Создать матрицы");
            Console.WriteLine("2. Выход");
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.Write("Введите количество строк: ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Введите количество столбцов: ");
                int m = int.Parse(Console.ReadLine());
                
                double[,] matrix1 = new double[n, m];
                double[,] matrix2 = new double[n, m];
                
                Console.WriteLine("1. Заполнить вручную");
                Console.WriteLine("2. Заполнить случайными числами");
                string fillChoice = Console.ReadLine();
                
                if (fillChoice == "1")
                {
                    FillMatrixManually(matrix1, "первой");
                    FillMatrixManually(matrix2, "второй");
                }
                else
                {
                    Console.Write("Введите a: ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Введите b: ");
                    int b = int.Parse(Console.ReadLine());
                    FillMatrixRandom(matrix1, a, b);
                    FillMatrixRandom(matrix2, a, b);
                }
                
                Console.WriteLine("Первая матрица:");
                PrintMatrix(matrix1);
                Console.WriteLine("Вторая матрица:");
                PrintMatrix(matrix2);
                
                Console.WriteLine("Сложение матриц:");
                AddMatrices(matrix1, matrix2);
                
                Console.WriteLine("Умножение матриц:");
                MultiplyMatrices(matrix1, matrix2);
                
                Console.WriteLine("Детерминант первой матрицы:");
                Determinant(matrix1);
                
                Console.WriteLine("Обратная матрица (первая):");
                InverseMatrix(matrix1);
                
                Console.WriteLine("Транспонирование первой матрицы:");
                TransposeMatrix(matrix1);
                
                Console.WriteLine("Решение системы уравнений:");
                SolveSystem(matrix1);
            }
            else if (choice == "2")
            {
                break;
            }
        }
    }
    
    static void FillMatrixManually(double[,] matrix, string name)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"Введите элемент {name} матрицы [{i},{j}]: ");
                matrix[i, j] = double.Parse(Console.ReadLine());
            }
        }
    }
    
    static void FillMatrixRandom(double[,] matrix, int a, int b)
    {
        Random rnd = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = rnd.Next(a, b + 1);
            }
        }
    }
    
    static void PrintMatrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    
    static void AddMatrices(double[,] m1, double[,] m2)
    {
        if (m1.GetLength(0) != m2.GetLength(0) || m1.GetLength(1) != m2.GetLength(1))
        {
            Console.WriteLine("Нельзя сложить матрицы разных размеров");
            return;
        }
        
        double[,] result = new double[m1.GetLength(0), m1.GetLength(1)];
        for (int i = 0; i < m1.GetLength(0); i++)
        {
            for (int j = 0; j < m1.GetLength(1); j++)
            {
                result[i, j] = m1[i, j] + m2[i, j];
            }
        }
        PrintMatrix(result);
    }
    
    static void MultiplyMatrices(double[,] m1, double[,] m2)
    {
        if (m1.GetLength(1) != m2.GetLength(0))
        {
            Console.WriteLine("Нельзя умножить матрицы: несовместимые размеры");
            return;
        }
        
        double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];
        for (int i = 0; i < m1.GetLength(0); i++)
        {
            for (int j = 0; j < m2.GetLength(1); j++)
            {
                for (int k = 0; k < m1.GetLength(1); k++)
                {
                    result[i, j] += m1[i, k] * m2[k, j];
                }
            }
        }
        PrintMatrix(result);
    }
    
    static void Determinant(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            Console.WriteLine("Детерминант можно найти только для квадратной матрицы");
            return;
        }
        
        if (matrix.GetLength(0) == 2)
        {
            double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            Console.WriteLine(det);
        }
        else if (matrix.GetLength(0) == 3)
        {
            double det = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                        matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                        matrix[0, 2] * matrix[1, 0] * matrix[2, 1] -
                        matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
                        matrix[0, 1] * matrix[1, 0] * matrix[2, 2] -
                        matrix[0, 0] * matrix[1, 2] * matrix[2, 1];
            Console.WriteLine(det);
        }
        else
        {
            Console.WriteLine("Детерминант вычисляется только для матриц 2x2 и 3x3");
        }
    }
    
    static void InverseMatrix(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
        {
            Console.WriteLine("Обратная матрица существует только для квадратных матриц");
            return;
        }
        
        if (matrix.GetLength(0) == 2)
        {
            double det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (det == 0)
            {
                Console.WriteLine("Обратной матрицы не существует (детерминант = 0)");
                return;
            }
            
            double[,] inverse = new double[2, 2];
            inverse[0, 0] = matrix[1, 1] / det;
            inverse[0, 1] = -matrix[0, 1] / det;
            inverse[1, 0] = -matrix[1, 0] / det;
            inverse[1, 1] = matrix[0, 0] / det;
            PrintMatrix(inverse);
        }
        else
        {
            Console.WriteLine("Обратная матрица вычисляется только для матриц 2x2");
        }
    }
    
    static void TransposeMatrix(double[,] matrix)
    {
        double[,] result = new double[matrix.GetLength(1), matrix.GetLength(0)];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                result[j, i] = matrix[i, j];
            }
        }
        PrintMatrix(result);
    }
    
    static void SolveSystem(double[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1) - 1)
        {
            Console.WriteLine("Система должна быть представлена матрицей n x (n+1)");
            return;
        }
        
        if (matrix.GetLength(0) == 2)
        {
            double a1 = matrix[0, 0], b1 = matrix[0, 1], c1 = matrix[0, 2];
            double a2 = matrix[1, 0], b2 = matrix[1, 1], c2 = matrix[1, 2];
            
            double det = a1 * b2 - a2 * b1;
            if (det == 0)
            {
                Console.WriteLine("Система не имеет единственного решения");
                return;
            }
            
            double x = (c1 * b2 - c2 * b1) / det;
            double y = (a1 * c2 - a2 * c1) / det;
            Console.WriteLine($"x = {x}, y = {y}");
        }
        else
        {
            Console.WriteLine("Решение систем поддерживается только для 2 уравнений");
        }
    }
}