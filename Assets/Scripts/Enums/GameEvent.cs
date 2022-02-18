/*
 * Author: Tyler Kaplan
 * Contributors: Grant Reed
 * Description: GameEvent provides enums to represent global game events.
 *
 * Events are managed by the GameManager.
 * Will implement EnemyEvents to be managed by an EnemyManager in the future.
 */
public enum GameEvent
{
    TITLE, COUNTDOWN, START, PAUSE, RESUME, WIN, LOSS, ENEMYKILLED, ENEMYADDED, QUIT, PLAYERKILLED
}
