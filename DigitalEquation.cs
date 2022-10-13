using System.Text;
public class DigitalEquation
{
    private ConsolePrinter drawer;
    private Dictionary<byte, int> digitValuePair;
    private List<byte> nums = new List<byte>()
    {
        0b1110111,
        0b1000100,
        0b0111101,
        0b1101101,
        0b1001110,
        0b1101011,
        0b1111011,
        0b1000101,
        0b1111111,
        0b1101111
    };
    public DigitalEquation()
    {
        digitValuePair = new Dictionary<byte, int>();
        for (int i = 0; i < nums.Count; i++)
        {
            digitValuePair.Add(nums[i], i);
        }
        drawer = new ConsolePrinter();
    }
    public void Solve(string equation)
    {
        drawer.PrintEquation(equation);
        RemoveDigit(equation);
    }
    private void RemoveDigit(string equation)
    {
        var numList = new List<byte>()
        {
            nums[equation[0]-48],
            nums[equation[2]-48],
            nums[equation[4]-48],
        };
        var sign = equation[1] == '+' ? true : false;

        for (int i = 0; i < equation.Length; i++)
        {
            if (equation[i] == '=' || equation[i] == '-' || equation[i] == '+')
                continue;

            else
            {
                for (int j = 0; j < 7; j++)
                {
                    if ((numList[i / 2] & (1 << j)) >= 1)
                    {
                        numList[i / 2] ^= (byte)(1 << j);
                        AddDigit(numList, sign);
                        numList[i / 2] ^= (byte)(1 << j);
                    }
                }
            }
        }
        if (sign)
        {
            AddDigit(numList, !sign);
        }
    }
    private void AddDigit(List<byte> numList, bool sign)
    {
        for (int i = 0; i < numList.Count; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if ((numList[i] & (1 << j)) == 0)
                {
                    numList[i] ^= (byte)(1 << j);

                    if (CheckDigits(numList))
                    {
                        if (CheckEquation(
                            digitValuePair[numList[0]],
                            sign,
                            digitValuePair[numList[1]],
                            digitValuePair[numList[2]]))
                        {
                            drawer.PrintEquation(ConvertToString(numList, sign));
                        }
                    }
                    numList[i] ^= (byte)(1 << j);
                }
            }
        }
        if (!sign)
        {
            if (CheckDigits(numList) && CheckEquation(
                            digitValuePair[numList[0]],
                            !sign,
                            digitValuePair[numList[1]],
                            digitValuePair[numList[2]]))
            {
                drawer.PrintEquation(ConvertToString(numList, !sign));
            }
        }
    }
    private string ConvertToString(List<byte> numList, bool sign)
    {
        return (char)(digitValuePair[numList[0]] + 48)
                + (sign ? "+" : "-")
                + (char)(digitValuePair[numList[1]] + 48)
                + "="
                + (char)(digitValuePair[numList[2]] + 48);
    }
    private bool CheckDigits(List<byte> numList)
    {
        for (int i = 0; i < numList.Count; i++)
        {
            if (!digitValuePair.ContainsKey(numList[i]))
                return false;
        }
        return true;
    }
    private bool CheckEquation(int num1, bool sign, int num2, int result)
    {
        num2 = sign ? num2 : -num2;
        return num1 + num2 == result;
    }
}