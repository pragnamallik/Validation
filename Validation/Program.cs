using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validation
{
    class Program
    {
        static char GetOpeningBracket(char i)
        {
            if (i == ')')
                return '(';
            else if (i == '}')
                return '{';
            else if (i == ']')
                return '[';
            else
                return ' ';
        }

        static void Main(string[] args)
        {
            bool invalid = false;
            int position = 0;
            Console.WriteLine("Enter the string");
            string input = Console.ReadLine();
            Stack<char> inputBrackets = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                position++;
                if (input[i] == '(' || input[i] == '{' || input[i] == '[')
                {
                    inputBrackets.Push(input[i]);
                }
                else if (input[i] == ')' || input[i] == '}' || input[i] == ']')
                {
                    try
                    {
                        if (inputBrackets.Pop() != GetOpeningBracket(input[i]))
                        {
                            invalid = true;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        invalid = true;
                        break;
                    }
                }
            }
            if (invalid || inputBrackets.Count != 0)
                Console.WriteLine("Invalid Expression. Position at " + position);
            else
                Console.WriteLine("Valid Expression");
            Console.ReadLine();
        }
    }
}
