namespace DiceSimulation.ClassLib;

public delegate void DiceRolledEventHandler(int value);

public class Dice
{
  public event DiceRolledEventHandler? DiceRolled;

  public void Roll()
  {
    Random random = new();
    int value = random.Next(1 , 7);
    DiceRolled?.Invoke(value);
  }

  #region OUTDATED CODE (first try)
  /*
  #region FIELDS
  private readonly Random _random = new();
  private int _count = 0;
  private int _lastNumber = 0;
  #endregion

  #region PROPERTIES
  public int Count { get => _count; }
  public int LastNumber { get => _lastNumber; }
   
  #endregion

  #region CONSTRUCTOR
  public Dice() { }
  #endregion

  #region METHODS
  public void Roll()
  {
    _lastNumber = _random.Next(1 , 7);
    _count++;
    NotifyObservers();
  }
  public void Reset()
  {
    _count = 0;
    _lastNumber = 0;
  }
  protected void NotifyObservers() { }
  #endregion
  */
  #endregion
}