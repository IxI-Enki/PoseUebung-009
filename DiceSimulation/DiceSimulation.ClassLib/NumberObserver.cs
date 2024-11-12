namespace DiceSimulation.ClassLib;

public class NumberObserver(int observedNumber)
{
  protected int observedNumber = observedNumber;

  public virtual void Update(int value)
  {
    if (value == observedNumber)
      Console.WriteLine($"Observer for {observedNumber} notified!");
  }


  /*
  #region FIELDS
  private readonly int _watchNumber = watchNumber;
  private int _watchCount;
  private int _count;
  #endregion

  #region PROPERTIES
  public int Count { get => _count; }
  public int WatchCount { get => _watchCount; }
  public int WatchNumber { get => _watchNumber; }
  #endregion

  #region CONSTRUCTOR
  // Used primary constructor
  #endregion

  #region METHODS
  public void Notify(int number)
  {
    _count++;
    if (number == _watchNumber)
      _watchCount++;
  }
  #endregion

  #region OVERRIDES
  public override string ToString()
    => $"Zahl {_watchNumber}: {_watchCount}";   // add statistic here 
  #endregion
  */
}