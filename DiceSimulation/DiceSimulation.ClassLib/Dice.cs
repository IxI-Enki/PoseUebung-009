using System;
using System.Text;

namespace DiceSimulation.ClassLib;

public delegate void DiceRolledEventHandler(int rolledNumber);

public class Dice
{
  #region FIELDS
  private readonly Random _random = new();
  private List<NumberObserver> _numberObservers = [ ];

  private int
    _sides = 6,
    _count = 0,
    _lastNumber = 0;
  #endregion

  #region PROPERTIES
  public int Count { get => _count; }
  public int LastNumber { get => _lastNumber; }
  public List<NumberObserver> NumberObservers { get => _numberObservers; set => _numberObservers = value; }
  #endregion

  #region EVENTS
  public event DiceRolledEventHandler? DiceRolled;
  #endregion

  #region METHODS
  // Public Business-Methods

  public void Roll()
  {
    _lastNumber = _random.Next(1 , _sides + 1);
    _count++;
    NotifyObservers();
  }

  public void Reset()
  {
    _count = 0;
    _lastNumber = 0;
  }

  protected void NotifyObservers() => DiceRolled?.Invoke(_lastNumber);


  // Private Helper-Methods
  public string GetStatistics()
  {
    int totalRolls = 0;
    var rollCounts = new Dictionary<int , int>();

    foreach (NumberObserver observer in _numberObservers) // Assuming you have a list of observers
    {
      totalRolls += observer.Count;
      rollCounts[ observer.WatchNumber ] = observer.WatchCount;
    }

    string result = "";
    foreach (var rollCount in rollCounts.OrderBy(x => x.Key))
    {
      double percentage = (double)rollCount.Value / totalRolls * 100;
      result += $"Zahl {rollCount.Key}: {rollCount.Value}  {percentage:F2}%\n";
    }
    return result.TrimEnd('\n');
  }
  #endregion

  #region OVERRIDES
  public override string ToString() => new StringBuilder().
      AppendLine(GetStatistics()).
      AppendLine($"Anzahl der Würfe: {Count}").
      AppendLine($"zuletzt geworfene Zahl: {LastNumber}").
      ToString();
  #endregion
}