namespace PracticalWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\Commands.txt";
            var calcul = new Calculator();
            calcul.PerformCalculate(path);
            calcul.PerformCalculate();
        }
    }
}
