using System.Text;
using DiceSimulation.ClassLib;
namespace DiceSimulation.ConApp;

internal class Program
{
  /// <summary>
  ///  Program Entry-Point
  /// </summary>
  static void Main()
  {
    PrintHeader();
    int numberOfDiceRolls = PromptUser();

    Dice dice = new();
    List<NumberObserver> numberObservers = [ ];
    for (int i = 0 ; i < 6 ; i++)
    {
      numberObservers.Add(new NumberObserver(i + 1));
      dice.DiceRolled += numberObservers[ i ].Notify;
    }
    dice.NumberObservers = numberObservers;

    while (numberOfDiceRolls > 0)
    {
      dice.Roll();
      numberOfDiceRolls--;
    }

    Console.Write($"\n{dice}");
    Console.ReadLine();
  }

  // Program-Initialisation Methods
  private static int PromptUser()
  {
    Console.Write("Anzahl der Würfe: ");

    return int.TryParse(Console.ReadLine() , out int numberOfDiceRolls) ? numberOfDiceRolls
      : numberOfDiceRolls > 0 ? numberOfDiceRolls : 0;
  }
  private static void PrintHeader()
  {
    StringBuilder sb = new();
    sb.Append(new String('*' , 33));
    sb.Append("\n* Würfel - Ist der Würfel echt? *\n");
    sb.Append(new String('*' , 33));
    Console.Write($"{sb}\n\n");
  }
}