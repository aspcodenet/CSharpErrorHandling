using System.Runtime.InteropServices;

namespace CSharpErrorHandling.Exceptions;

public class App
{

    public void calculateDifference()
    {
        int difference = 0;
        int[] number = new int[5] { 1, 2, 3, 4, 5 };
        for (int init = 1; init <= 5; init++)
        {
            difference = difference - number[init];
        }
    }



    public void Calc()
    {
        while (true)
        {

            double Num1, Num2;
            double Result = 0.00;
            char op;
            Console.Write("Enter your First Number :  ");
            Num1 = double.Parse(Console.ReadLine());
            Console.Write("Enter an Operator  (+, -, * or /): ");
            op = char.Parse(Console.ReadLine());
            if (op != '+' && op != '-' &&
                op != '*' && op != '/')
                throw new Exception(op.ToString());
            Console.Write("Enter your Second Number :");
            Num2 = double.Parse(Console.ReadLine());
            if (op == '/')
                if (Num2 == 0)
                    throw new DivideByZeroException("Division by zero is not allowed");
            Result = Calculator(Num1, Num2, op);
            Console.WriteLine("\n{0} {1} {2} = {3}", Num1, op, Num2, Result);
        }
    }

    double Calculator(double v1, double v2, char op)
    {
        double Result = 0.00;

        switch (op)
        {
            case '+':
                Result = v1 + v2;
                break;
            case '-':
                Result = v1 - v2;
                break;
            case '*':
                Result = v1 * v2;
                break;
            case '/':
                Result = v1 / v2;
                break;
        }
        return Result;
    }


    public void Run()
    {
        DivideByZero();
        calculateDifference();

        Calc();
        try
        {
            TriggerStackOverflow(100, 200, 300, 400);
        }
        catch (StackOverflowException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private void DivideByZero()
    {
        while (true)
        {
            try
            {
                Console.Write("Tal 1:");
                int tal1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Tal 2:");
                int tal2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(tal1/tal2);
                break;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Oj oj kan inte dela med 0 ju");
            }

        }
    }

    private void TriggerStackOverflow(int v1, int v2, int v3, int v4)
    {
        TriggerStackOverflow(v1,v2,v3,v4);
    }
}