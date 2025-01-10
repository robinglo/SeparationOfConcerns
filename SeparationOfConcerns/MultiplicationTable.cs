namespace SeparationOfConcerns;

public class MultiplicationTable
{
    public static void For(List<int> numbers)
    {
        var biggest = GetBiggestValue(numbers);
        var magnitude = GetMagnitude(biggest);
        PrintTable(numbers, magnitude);
    }
    
    
    // GetBiggestValue Method
    private static int GetBiggestValue(List<int> numbers)   
    {
        var biggest = int.MinValue;

        foreach (var number in numbers)
        {
            if (number < 0)
            {
                throw new ArgumentException("negative numbers are not supported");
            }

            if (number > biggest)
            {
                biggest = number;
            }
        }
        return biggest;
    }
        

    // GetMagnitude Method
    private static int GetMagnitude(int biggest)
    {
        var biggestResult = biggest * biggest;
        var magnitude = 0;

        while (biggestResult > 0)
        {
            magnitude++;
            biggestResult /= 10;
        }
        magnitude++;

        return magnitude;
    }


    // PrintTable Method
    private static void PrintTable(List<int> numbers, int magnitude){
        var titleRow = "";
        titleRow += "*".PadLeft(magnitude) + " ||";

        foreach (var col in numbers)
        {
            titleRow += $"{col}".PadLeft(magnitude) + " |";
        }
        Console.WriteLine(titleRow);


        for (var i = 0; i < titleRow.Length; i++)
        {
            Console.Write("=");
        }
        Console.WriteLine();


        foreach (var row in numbers)
        {
            Console.Write($"{row}".PadLeft(magnitude) + " ||");

            foreach (var col in numbers)
            {
                var product = row * col;
                Console.Write($"{product}".PadLeft(magnitude) + " |");
            }
            Console.WriteLine();
        }
    }   
}
