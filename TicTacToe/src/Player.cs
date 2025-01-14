
public class Player 
{
    private int[] _moves;
    public bool isTurn
    {
        get { return isTurn; }
        set { isTurn = value; }
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