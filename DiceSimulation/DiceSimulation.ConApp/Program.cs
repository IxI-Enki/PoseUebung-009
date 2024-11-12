using DiceSimulation.ClassLib;
using System.Text;

namespace DiceSimulation.ConApp;

internal class Program
{
  static void Main()
  {
    PrintHeader();
    int numberOfDiceRolls = PromptUser();

    Dice dice = new();
    NumberObserver[ ] numberObservers = new NumberObserver[ 6 ];

    for (int i = 0 ; i < 6 ; i++)
    {
      numberObservers[ i ] = new(i + 1);
      dice.DiceRolled += numberObservers[ i ].Update;
    }

    while (numberOfDiceRolls > 0)
    {
      dice.Roll();
      numberOfDiceRolls--;
    }
  }

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