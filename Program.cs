using System;

namespace ComplexNumberCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to compute? If you want to add, substract,");
            Console.WriteLine("divide or multiply complex number by complex number,");
            Console.WriteLine("type 1 and press Enter. If you want to multiply a number to a complex number,");
            Console.WriteLine("type 2 and press Enter");

            int userChoose = Int32.Parse(Console.ReadLine());

            switch (userChoose)
            {
                case 1:
                    Console.WriteLine("OK. You need to input two complex numbers.");
                    Console.WriteLine("First, put in the real part of first number and press Enter");
                    double real1 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("OK. Now type the imaginary part of the first number and press Enter.");
                    double im1 = Convert.ToDouble(Console.ReadLine());
                    ComplexNumber firstOne = new ComplexNumber(real1, im1);
                    Console.WriteLine("OK. Your first number is " + firstOne.ToString());

                    Console.WriteLine("Now, do the same procedure with the second number. Type the real part:");
                    double real2 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("And the imaginary part:");
                    double im2 = Convert.ToDouble(Console.ReadLine());
                    ComplexNumber secondOne = new ComplexNumber(real2, im2);
                    Console.WriteLine("Your second number is " + secondOne.ToString());


                    Console.WriteLine("Now choose the operation. Press 1 for addition, 2 for substraction,");
                    Console.WriteLine("3 for multiplication and 4 for division.");

                    int userChooseForComplex = Int32.Parse(Console.ReadLine());
                    switch (userChooseForComplex)
                    {
                        case 1:
                            Console.WriteLine("Your result is: " + firstOne.Add(secondOne));
                            break;
                        case 2:
                            Console.WriteLine("Your result is: " + firstOne.Substract(secondOne));
                            break;
                        case 3:
                            Console.WriteLine("Your result is: " + firstOne.Multiply(secondOne));
                            break;
                        case 4:
                            Console.WriteLine("Your result is: " + firstOne.Divide(secondOne));
                            break;
                        default:
                            Console.WriteLine("Sorry, i don't know such operation :(");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("OK. You need to input one complex numbers and one rational number.");
                    Console.WriteLine("First, put in the real part of complex number and press Enter");
                    double real3 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("OK. Now type the imaginary part of the complex number and press Enter.");
                    double im3 = Convert.ToDouble(Console.ReadLine());
                    ComplexNumber thirdOne = new ComplexNumber(real3, im3);
                    Console.WriteLine("OK. Your complex number is " + thirdOne.ToString());

                    Console.WriteLine("Now type the rational number and press Enter:");
                    double rationalNum = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Your rational number is " + rationalNum);

                    Console.WriteLine("The result of multiplication is " + thirdOne.MultiplyByNumber(rationalNum));

                    break;
                default:
                    Console.WriteLine("Sorry, i don't such operation");
                    break;
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    class ComplexNumber
    {
        private double a;
        private double b;

        private ComplexNumber()
        {

        }

        public ComplexNumber(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public ComplexNumber Add(ComplexNumber ToAdd)
        {
            return new ComplexNumber(a + ToAdd.a, b + ToAdd.b);
        }

        public ComplexNumber Substract(ComplexNumber ToAdd)
        {
            return new ComplexNumber(a - ToAdd.a, b - ToAdd.b);
        }

        public ComplexNumber MultiplyByNumber(double NumToMultiply)
        {
            return new ComplexNumber(a * NumToMultiply, b * NumToMultiply);
        }

        public ComplexNumber Multiply(ComplexNumber ToMultiply)
        {
            return new ComplexNumber((a * ToMultiply.a) - (b * ToMultiply.b),
                (a * ToMultiply.b) + (b * ToMultiply.a));
        }

        public ComplexNumber Divide(ComplexNumber ToDivide)
        {
            return new ComplexNumber((a * ToDivide.a + b * ToDivide.b) /
                (Math.Pow(ToDivide.a, 2) + Math.Pow(ToDivide.b, 2)),
                ((ToDivide.a * b) - (a * ToDivide.b)) /
                (Math.Pow(ToDivide.a, 2) + Math.Pow(ToDivide.b, 2)));
        }

        public override bool Equals(object obj)
        {
            return obj is ComplexNumber number &&
                   a == number.a &&
                   b == number.b;
        }

        public override int GetHashCode()
        {
            var hashCode = 2118541809;
            hashCode = hashCode * -1521134295 + a.GetHashCode();
            hashCode = hashCode * -1521134295 + b.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            if (b > 0)
            {
                return a + "+" + b + "i";
            }

            if (b < 0)
            {
                return a + "" + b + "i";
            }

            return a + "+" + b + "i";
        }
    }
}