using System;

class Calculadora {
    static void Main() {
        double num1, num2, result;
        char op;

        Console.Write("Digite o primeiro número: ");
        num1 = double.Parse(Console.ReadLine());

        Console.Write("Digite o segundo número: ");
        num2 = double.Parse(Console.ReadLine());

        Console.Write("Digite a operação (+, -, *, /): ");
        op = char.Parse(Console.ReadLine());

        switch (op) {
            case '+':
                result = num1 + num2;
                Console.WriteLine("O resultado da soma é " + result);
                break;
            case '-':
                result = num1 - num2;
                Console.WriteLine("O resultado da subtração é " + result);
                break;
            case '*':
                result = num1 * num2;
                Console.WriteLine("O resultado da multiplicação é " + result);
                break;
            case '/':
                result = num1 / num2;
                Console.WriteLine("O resultado da divisão é " + result);
                break;
            default:
                Console.WriteLine("Operação inválida");
                break;
        }

        Console.ReadLine();
    }
}
