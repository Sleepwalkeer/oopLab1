using System;

public class OneDimensionalArrayHandler
{
    private double[] array;

    public int CountElementsWithAbsLessThan0_3
    {
        get
        {
            int count = 0;
            foreach (var element in array)
            {
                if (Math.Abs(element) < 0.3)
                {
                    count++;
                }
            }
            return count;
        }
    }

    public OneDimensionalArrayHandler(int size, double initialValue)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Array size must be greater than 0");
        }

        array = new double[size];
        FillArray(initialValue);
    }

    public OneDimensionalArrayHandler(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Array size must be greater than 0");
        }

        array = new double[size];
        FillArrayFromConsole();
    }

    public OneDimensionalArrayHandler(double x, int size, bool isTaylorSeries)
    {
        if (size <= 0)
        {
            throw new ArgumentException("Array size must be greater than 0");
        }

        array = new double[size];
        FillArrayWithSinSeries(x);
    }

    private void FillArrayFromConsole()
    {
        Console.WriteLine($"Enter {array.Length} elements for the array:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Element {i + 1}: ");
            if (!double.TryParse(Console.ReadLine(), out array[i]))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                i--; 
            }
        }
    }

    private void FillArray(double value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    // Method to fill the array with parts of the Taylor series for sin x function
    private void FillArrayWithSinSeries(double x)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = CalculateSinSeriesTerm(x, i);
        }
    }

    public void ProcessArray()
    {
        if (array.Length == 0)
        {
            throw new InvalidOperationException("Array is empty. Cannot process an empty array.");
        }

        int lastIndexOfSmallElement = -1;
        double sumOfValues = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) < 0.0001)
            {
                lastIndexOfSmallElement = i;
            }
        }

        for (int i = 0; i < lastIndexOfSmallElement; i++)
        {
            sumOfValues += array[i];
        }

        if (lastIndexOfSmallElement == -1)
        {
            Console.WriteLine("No element with abs < 0.0001 found.");
        }
        else
        {
            Console.WriteLine($"Last element with abs < 0.0001 found at index {lastIndexOfSmallElement}");
            Console.WriteLine($"Sum of values of elements with position < {lastIndexOfSmallElement}: {sumOfValues}");
        }
    }

    // Method to calculate the i-th term of the Taylor series for sin x function
    private double CalculateSinSeriesTerm(double x, int i)
    {
        return Math.Pow(-1, i) * Math.Pow(x, 2 * i + 1) / Factorial(2 * i + 1);
    }

    // Method to calculate the factorial of a number
    private double Factorial(int n)
    {
        double result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public void PrintArray()
    {
        Console.Write("Array elements: ");
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    public static void Main()
    {
        OneDimensionalArrayHandler arrayHandler = new OneDimensionalArrayHandler(5, 42);
        Console.WriteLine("The array filled with specified value for the specified number of elements");

        arrayHandler.PrintArray();

        OneDimensionalArrayHandler arrayHandler1 = new OneDimensionalArrayHandler(5, 5, false);
        Console.WriteLine("The array filled with taylor series for sin x");
        arrayHandler1.PrintArray();

        Console.WriteLine("The array filled with user's input from console");
        OneDimensionalArrayHandler arrayHandler2 = new OneDimensionalArrayHandler(5);
        arrayHandler2.PrintArray();

        Console.WriteLine("The number of elements with abs less than 0,3 stored in a property field");
        Console.WriteLine(arrayHandler2.CountElementsWithAbsLessThan0_3);

        Console.WriteLine("The demo of method to sum all the elements indices of which are lower than of the last element with abs less than 0.0003");
        arrayHandler2.ProcessArray();

    }
}