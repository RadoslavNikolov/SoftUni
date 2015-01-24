using System;

class XExpression
{
    static void Main()
    {
        string input = Console.ReadLine();
        decimal result = 0m;
        decimal bracketResult = 0m;
        bool isInBracket = false;
        char inBracketSign='+';
        char outBracketSign='+';

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i]=='(')
            {
                isInBracket = true;
            }
            if (input[i]==')')
            {
                isInBracket = false;
                switch (outBracketSign)
                {
                    case '+': result += bracketResult; break;
                    case '-': result -= bracketResult; break;
                    case '*': result *= bracketResult; break;
                    case '/': result /= bracketResult; break;
                    default:
                        break;
                }
                bracketResult = 0;
                inBracketSign = '+';
            }

            if (isInBracket==false)
            {
                if (input[i]>='0' && input[i]<='9')
                {
                    switch (outBracketSign)
                    {
                        case '+': result += (int)char.GetNumericValue(input[i]); break;
                        case '-': result -= (int)char.GetNumericValue(input[i]); break;
                        case '*': result *= (int)char.GetNumericValue(input[i]); break;
                        case '/': result /= (int)char.GetNumericValue(input[i]); break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (input[i])
                    {
                        case '+': outBracketSign = '+'; break;
                        case '-': outBracketSign = '-'; break;
                        case '*': outBracketSign = '*'; break;
                        case '/': outBracketSign = '/'; break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (input[i] >= '0' && input[i] <= '9')
                {
                    switch (inBracketSign)
                    {
                        case '+': bracketResult += (int)char.GetNumericValue(input[i]); break;
                        case '-': bracketResult -= (int)char.GetNumericValue(input[i]); break;
                        case '*': bracketResult *= (int)char.GetNumericValue(input[i]); break;
                        case '/': bracketResult /= (int)char.GetNumericValue(input[i]); break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (input[i])
                    {
                        case '+': inBracketSign = '+'; break;
                        case '-': inBracketSign = '-'; break;
                        case '*': inBracketSign = '*'; break;
                        case '/': inBracketSign = '/'; break;
                        default:
                            break;
                    }
                }
            }
            if (input[i]=='=')
            {
                break;
            }
        }
        Console.WriteLine("{0:F2}",result);

    }
}
