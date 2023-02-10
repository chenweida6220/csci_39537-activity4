using System;

interface IMyInterface {
    void Display();
}

class MyAddition : IMyInterface {
    public int num1 { get; set; }
    public int num2 { get; set; }
    public double num3 { get; set; }
    public string instanceName { get; set; }

    public event EventHandler CalculationComplete;

    public double Sum() {
      double total = num1 + num2 + num3;
      OnCalculationComplete();
      return total;
    }

    protected virtual void OnCalculationComplete()
    {
        CalculationComplete?.Invoke(this, EventArgs.Empty);
    }

    public void Display() {
        Console.WriteLine("I am an instance called " + instanceName + " of MyAddition.");
    }
}

class Program {
    static void Main(string[] args)
    {
      MyAddition numOp1 = new MyAddition();
      numOp1.num1 = 1;
      numOp1.num2 = 2;
      numOp1.num3 = 3.5;
      numOp1.instanceName = "numOp1";
      numOp1.CalculationComplete += NumOp1_CalculationComplete;

      Console.WriteLine("Sum: " + numOp1.Sum());

      IMyInterface myInterface = numOp1;
      myInterface.Display();
      }

    private static void NumOp1_CalculationComplete(object sender, EventArgs e)
    {
        Console.WriteLine("Calculation complete.");
    }
}
