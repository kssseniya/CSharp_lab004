public class MyMatrix
{
    private int[,] matrix;

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public MyMatrix(int rows, int columns, int minRange, int maxRange)
    {
        if (minRange > maxRange)
            throw new ArgumentException("Минимальное значение должно быть меньше максимального.");

        Rows = rows;
        Columns = columns;
        matrix = new int[rows, columns];

        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minRange, maxRange + 1);
            }
        }
    }

    //Индексатор
    public int this[int row, int column]
    {
        get
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new IndexOutOfRangeException("Индекс находится за пределами допустимых значений.");
            }
            return matrix[row, column];
        }
        set
        {
            if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            {
                throw new IndexOutOfRangeException("Индекс находится за пределами допустимых значений.");
            }
            matrix[row, column] = value;
        }
    }

    //Сложение матриц
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
        {
            throw new ArgumentException("Матрицы должны иметь одинаковое количество строк и столбцов для сложения.");
        }

        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

    //Вычитание матриц
    public static MyMatrix operator -(MyMatrix a, MyMatrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
        {
            throw new ArgumentException("Матрицы должны иметь одинаковое количество строк и столбцов для вычитания.");
        }

        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result[i, j] = a[i, j] - b[i, j];
            }
        }
        return result;
    }

    //Умножение матриц
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.Columns != b.Rows)
        {
            throw new ArgumentException("При умножении количество столбцов первой матрицы должно быть равно количеству строк второй матрицы.");
        }

        MyMatrix result = new MyMatrix(a.Rows, b.Columns, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Columns; j++)
            {
                for (int k = 0; k < a.Columns; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    //Умножение матрицы на число
    public static MyMatrix operator *(MyMatrix a, int scalar)
    {
        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result[i, j] = a[i, j] * scalar;
            }
        }
        return result;
    }

    //Деление матрицы на число
    public static MyMatrix operator /(MyMatrix a, int scalar)
    {
        if (scalar == 0)
        {
            throw new DivideByZeroException("Деление на ноль невозможно.");
        }

        MyMatrix result = new MyMatrix(a.Rows, a.Columns, 0, 0);
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result[i, j] = a[i, j] / scalar;
            }
        }
        return result;
    }
 
    //Вывод матрицы
    public override string ToString()
    {
        string output = "";
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                output += matrix[i, j].ToString("F2") + "\t"; //До двух знаков после запятой
            }
            output += "\n";
        }
        return output;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите минимальное значение диапазона:");
        int minRange = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите максимальное значение диапазона:");
        int maxRange = Convert.ToInt32(Console.ReadLine());

        //Создание матриц с разными размерами для тестирования
        MyMatrix matrix1 = new MyMatrix(3, 4, minRange, maxRange);
        MyMatrix matrix2 = new MyMatrix(3, 4, minRange, maxRange);

        //Вывод матриц
        Console.WriteLine("Матрица 1:\n" + matrix1);
        Console.WriteLine("Матрица 2:\n" + matrix2);

        //Операции с матрицами
        try
        {
            Console.WriteLine("\nСложение матриц:\n" + (matrix1 + matrix2));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        try
        {
        Console.WriteLine("\nВычитание матриц:\n" + (matrix1 - matrix2));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        try
        {
            Console.WriteLine("\nУмножение матриц:\n" + (matrix1 * matrix2));
        }
        catch (Exception ex) {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        Console.WriteLine("\nУмножение матрицы на число:\n" + (matrix1 * 3));
        Console.WriteLine("\nДеление матрицы на число:\n" + (matrix1 / 2));
        Console.WriteLine("\nЭлемент матрицы [1][2]: " + matrix1[0, 1]);
    }
}