namespace DiceSimulation.ClassLib;

public class NumberObserver(int watchNumber)
{
  #region FIELDS
  private readonly int _watchNumber = watchNumber;

  private int
    _watchCount,
    _count;
  #endregion

  #region PROPERTIES
  /// <summary>
  ///  Ruft die Anzahl von Wuerfen ab.
  /// </summary>
  public int Count { get => _count; }

  /// <summary>
  ///  Ruft die Anzahl der beobachteten Zahl ab.
  /// </summary>
  public int WatchCount { get => _watchCount; }

  /// <summary>
  ///  Ruft die Zahl ab, welche beobachtet wird.
  /// </summary>
  public int WatchNumber { get => _watchNumber; }
  #endregion

  #region METHODS
  public void Notify(int number)
  {
    _count++;
    if (number == _watchNumber)
    {
      _watchCount++;
      Console.WriteLine($"Observer for {_watchNumber} notified!");
    }
  }
  #endregion

  #region OVERRIDES
  public override string ToString() => $"Zahl {_watchNumber}: {_watchCount}";
  #endregion
}