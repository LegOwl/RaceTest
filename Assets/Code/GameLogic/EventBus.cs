using System;

public class EventBus
{
    private static EventBus _instance;
    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventBus();
            }
            return _instance;
        }
    }

    public event Action onStartRace;
    public void StartRace() 
    {
        if (onStartRace != null) 
        {
            onStartRace();
        }
    }
    
    public event Action onFinishRace;
    public void FinishRace() 
    {
        if (onFinishRace != null) 
        {
            onFinishRace();
        }
    }
    
    public event Action onCountdownStart;
    public void CountdownStart() 
    {
        if (onCountdownStart != null) 
        {
            onCountdownStart();
        }
    }
    
    public event Action onEndGame;
    public void EndGame() 
    {
        if (onEndGame != null) 
        {
            onEndGame();
        }
    }
    
}