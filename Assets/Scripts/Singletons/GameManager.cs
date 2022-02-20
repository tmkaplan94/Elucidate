/*
 * Author: Tyler Kaplan
 * Contributors: Grant Reed
 * Description: GameManager controls and maintains the flow of the game.
 *
 * GameManager extends Singleton, which extends MonoBehavior.
 */
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private PlayerList players;
    
    public static GameEvent CurrentStatus { get; private set; }
    public static int EnemyCount { get; private set; }

    // subscribe all event functions to game events
    private void OnEnable()
    {
        GameEventBus.Title += TitleEvent;
        GameEventBus.Countdown += CountdownEvent;
        GameEventBus.Start += StartEvent;
        GameEventBus.Pause += PauseEvent;
        GameEventBus.Resume += ResumeEvent;
        GameEventBus.Win += WinEvent;
        GameEventBus.Loss += LossEvent;
        GameEventBus.Quit += QuitEvent;
        
        GameEventBus.EnemyAdded += EnemyAddedEvent;
        GameEventBus.EnemyKilled += EnemyKilledEvent;
        GameEventBus.PlayerDeath += PlayerDeathEvent;
        GameEventBus.PlayerAdded += PlayerAddedEvent;
    }

    // initially set the game status
    private void Start()
    {
        CurrentStatus = GameEvent.TITLE;
        Debug.Log("Current game status: " + CurrentStatus);
    }

    // unsubscribe all event functions from game events
    private void OnDisable()
    {
        GameEventBus.Title -= TitleEvent;
        GameEventBus.Countdown -= CountdownEvent;
        GameEventBus.Start -= StartEvent;
        GameEventBus.Pause -= PauseEvent;
        GameEventBus.Resume -= ResumeEvent;
        GameEventBus.Win -= WinEvent;
        GameEventBus.Loss -= LossEvent;
        GameEventBus.Quit -= QuitEvent;
        
        GameEventBus.EnemyAdded -= EnemyAddedEvent;
        GameEventBus.EnemyKilled -= EnemyKilledEvent;
        GameEventBus.PlayerDeath -= PlayerDeathEvent;
        GameEventBus.PlayerAdded -= PlayerAddedEvent;
    }

    // event functions update the current game status and dictate the behaviors that happen on event
    #region Private Event Functions

    private void TitleEvent()
    {
        CurrentStatus = GameEvent.TITLE;
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        SceneManager.LoadScene(0);
        if (players.Length() > 0)
            players.ClearAll();
        Debug.Log("Current game status: " + CurrentStatus);
    }

    private void CountdownEvent()
    {
        CurrentStatus = GameEvent.COUNTDOWN;
        Debug.Log("Current game status: " + CurrentStatus);
    }
    
    private void StartEvent()
    {
        CurrentStatus = GameEvent.START;
        SceneManager.LoadScene(1);

        Debug.Log("Current game status: " + CurrentStatus);
    }

    private void PauseEvent()
    {
        CurrentStatus = GameEvent.PAUSE;
        Debug.Log("Current game status: " + CurrentStatus);
    }
    
    private void ResumeEvent()
    {
        CurrentStatus = GameEvent.RESUME;
        Debug.Log("Current game status: " + CurrentStatus);
    }
    
    private void WinEvent()
    {
        CurrentStatus = GameEvent.WIN;
        SceneManager.LoadScene(4);
        Debug.Log("Current game status: " + CurrentStatus);
    }
    
    private void LossEvent()
    {
        CurrentStatus = GameEvent.LOSS;
        SceneManager.LoadScene(4);
        Debug.Log("Current game status: " + CurrentStatus);
    }

    private void QuitEvent()
    {
        CurrentStatus = GameEvent.QUIT;
        Debug.Log("Quit successfully");
        Application.Quit();
    }
    
    private void EnemyAddedEvent()
    {
        EnemyCount++;
    }
    
    private void EnemyKilledEvent()
    {
        EnemyCount--;
        if(EnemyCount <= 0)
        {
            GameEventBus.EnemyKilled?.Invoke();
        }
    }
    
    private void PlayerDeathEvent(int id)
    {
        PlayerStats deadPlayer = players.GetItem(id);
        players.Remove(id);
        if (deadPlayer == null || players.Length() < 1)
            return;
        if (!deadPlayer.gameObject.GetPhotonView().IsMine)
        {
             Debug.Log("win " + id);
             GameEventBus.Win?.Invoke();
        }
        else
        {
             Debug.Log("loss " + id);
             GameEventBus.Loss?.Invoke();
        }  
    }

    private void PlayerAddedEvent(int id, PlayerStats player)
    {

        players.Add(id, player);
        Debug.Log("player added " + id + "  " + players.Length());
    }

    #endregion

}
