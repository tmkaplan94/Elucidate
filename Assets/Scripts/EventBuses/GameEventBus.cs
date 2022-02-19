/*
 * Authors: Grant Reed, Tyler
 * Contributors:
 * Description: GameManager controls and maintains the flow of the game.
 *
 * GameManager extends Singleton, which extends MonoBehavior.
 */
using System;

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
    public static Action PlayerDeath;
}

public enum GameEvent
{
    TITLE, COUNTDOWN, START, PAUSE, RESUME, WIN, LOSS, QUIT, ENEMYADDED, ENEMYKILLED, PLAYERDEATH
}