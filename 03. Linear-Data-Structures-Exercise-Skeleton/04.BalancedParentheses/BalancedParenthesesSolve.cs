namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Queue<char> queue = new Queue<char>(parentheses);
            Stack<char> stack = new Stack<char>();

            while (queue.Count > 0)
            {
                char c = queue.Dequeue();
                switch (c)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            return false;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            return false;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }
    }
}
