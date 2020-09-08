using System;

namespace FunctionPong
{
    class Program
    {
        static void Main(string[] args)
        {
            OpSet set = new OpSet();

            MyOp op1 = set.Add;
            //op1 = op1 + set.Subtract + set.Add - set.Subtract;
            op1 += set.Subtract;
            op1 += set.Add;
            op1 -= set.Subtract;

            foreach(var fun in op1.GetInvocationList())
            {
                Console.WriteLine(fun.Method.Name);
            }

            int res = op1(3, 4);

            Console.WriteLine(res);



            return;
            Calculator math = new Calculator();
            //math.Calculate(Add);
            math.Calculate(set.Add);

            int age = 10;
            MyOp var1 = Rubbish;

            MyOp[] ops = new MyOp[3];

            int result = var1(3, 4);
            Console.WriteLine(result);

        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Rubbish(int w, int x)
        {
            Console.WriteLine($"{w}, {x}");
            return 42;
        }
    }
}
