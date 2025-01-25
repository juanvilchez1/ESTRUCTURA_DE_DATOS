using System;
using System.Collections.Generic;

class BalancedExpression
{
    public static bool IsBalanced(string expression)
    {
        // Stack para guardar los caracteres de apertura
        Stack<char> stack = new Stack<char>();

        // Recorrer cada carácter de la expresión
        foreach (char c in expression)
        {
            // Si el carácter es un símbolo de apertura, se añade a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            // Si el carácter es un símbolo de cierre, se verifica
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía, no está balanceado
                if (stack.Count == 0)
                {
                    return false;
                }

                // Obtener el símbolo de apertura en la parte superior de la pila
                char top = stack.Pop();

                // Verificar que el símbolo de apertura coincida con el de cierre
                if (!IsMatchingPair(top, c))
                {
                    return false;
                }
            }
        }

        // Si la pila está vacía al final, está balanceado
        return stack.Count == 0;
    }

    // Método auxiliar para verificar si los pares coinciden
    private static bool IsMatchingPair(char opening, char closing)
    {
        return (opening == '(' && closing == ')') ||
               (opening == '{' && closing == '}') ||
               (opening == '[' && closing == ']');
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese una fórmula matemática:");
        string expression = Console.ReadLine();

        if (IsBalanced(expression))
        {
            Console.WriteLine("La fórmula está balanceada.");
        }
        else
        {
            Console.WriteLine("La fórmula no está balanceada.");
    