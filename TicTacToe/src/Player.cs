
/// <summary>
/// TODO
/// </summary>
public class Player 
{
    /// <summary>
    /// TODO
    /// </summary>
    bool _isTurn;
    public bool isTurn
    {
        get { return _isTurn; }
        set { _isTurn = value; }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public Player() 
    {
        isTurn = false;
    }
}