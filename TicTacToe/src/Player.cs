
public class Player 
{
    bool _isTurn;
    public bool isTurn
    {
        get { return _isTurn; }
        set { _isTurn = value; }
    }

    public Player() 
    {
        isTurn = false;
    }
}