
public class Player 
{
    int playerNum;
    bool isTurn
    {
        get;
        set;
    }
    int[] moves 
    {
        get;
        set;
    }

    public Player(int index, bool starts) 
    {
        playerNum = index;
        isTurn = starts;
        moves = new int[5];
    }
}