public class ConsolePrinter
{
    private int topCounter;
    private Dictionary<char, char[,]> charConsolepair = new Dictionary<char, char[,]>()
    {
        {'0', new char[,]{
            {' ', '-', ' '},
            {'|', ' ', '|'},
            {' ', ' ', ' '},
            {'|', ' ', '|'},
            {' ', '-', ' '},

        }},
        {'1', new char[,]{
            {' ', ' ', ' '},
            {' ', ' ', '|'},
            {' ', ' ', ' '},
            {' ', ' ', '|'},
            {' ', ' ', ' '},

        }},
        {'2', new char[,]{
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', '-', ' '},
            {'|', ' ', ' '},
            {' ', '-', ' '},

        }},
        {'3', new char[,]{
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', '-', ' '},

        }},
        {'4', new char[,]{
            {' ', ' ', ' '},
            {'|', ' ', '|'},
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', ' ', ' '},

        }},
        {'5', new char[,]{
            {' ', '-', ' '},
            {'|', ' ', ' '},
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', '-', ' '},

        }},
        {'6', new char[,]{
            {' ', '-', ' '},
            {'|', ' ', ' '},
            {' ', '-', ' '},
            {'|', ' ', '|'},
            {' ', '-', ' '},

        }},
        {'7', new char[,]{
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', ' ', ' '},
            {' ', ' ', '|'},
            {' ', ' ', ' '},

        }},
        {'8', new char[,]{
            {' ', '-', ' '},
            {'|', ' ', '|'},
            {' ', '-', ' '},
            {'|', ' ', '|'},
            {' ', '-', ' '},

        }},
        {'9', new char[,]{
            {' ', '-', ' '},
            {'|', ' ', '|'},
            {' ', '-', ' '},
            {' ', ' ', '|'},
            {' ', '-', ' '},

        }},
        {'+', new char[,]{
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', '+', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        }},
        {'-', new char[,]{
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', '-', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        }},
        {'=', new char[,]{
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', '=', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '},
        }},
    };
    public ConsolePrinter()
    {
        Console.Clear();
    }
    public void PrintEquation(string equation)
    {
        var left = 0;
        for (int i = 0; i < equation.Length; i++)
        {
            DrawChar(charConsolepair[equation[i]], left, topCounter);
            left += 5;
        }
        topCounter += 5;

    }
    private void DrawChar(char[,] arr, int left, int top)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.SetCursorPosition(left, top + i);
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                System.Console.Write(arr[i, j]);
            }
            System.Console.WriteLine();
        }
    }
}
