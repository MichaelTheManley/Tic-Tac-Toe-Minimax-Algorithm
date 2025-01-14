
public class Player 
{
    int[] _moves;
    bool _isTurn;
    public bool isTurn
    {
        get { return _isTurn; }
        set { _isTurn = value; }
    }
    public int[] moves 
    {
        get { return _moves; }
        set { _moves = value; }
    }

    public Player() 
    {
        _moves = new int[5];
    }
}