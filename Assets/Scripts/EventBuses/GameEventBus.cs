/*
 * Authors: Grant Reed, Tyler
 * Contributors:
 * Description: 
 *
 *
 */
using System;
using System.Collections.Generic;

public static class GameEventBus
{
    public static Action Title;
    public static Action Countdown;
    public static Action Start;
    public static Action Pause;
    public static Action Resume;
    public static Action Win;
    public static Action Loss;
    public static Action Quit;
    
    public static Action EnemyAdded;
    public static Action EnemyKilled;
    public static Action<int> PlayerDeath;
    public static Action<int, PlayerStats> PlayerAdded;

}

//This enum Just allows the game manager to keep track of the current state of the game.
public enum GameEvent
{
    TITLE, COUNTDOWN, START, PAUSE, RESUME, WIN, LOSS, QUIT, ENEMYADDED, ENEMYKILLED, PLAYERDEATH
}