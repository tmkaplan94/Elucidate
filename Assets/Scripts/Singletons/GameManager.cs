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
    private bool _isMultiplayer;
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
        _isMultiplayer = false;
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
    //loads the title scene, disconnects player from server, clears player list. Essentially resets the game.
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Current game status: " + CurrentStatus);
    }
    
    private void LossEvent()
    {
        CurrentStatus = GameEvent.LOSS;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Current game status: " + CurrentStatus);
    }

    private void QuitEvent()
    {
        CurrentStatus = GameEvent.QUIT;
        Debug.Log("Quit successfully");
        Application.Quit();
    }
    
    //These two are just used for singleplayer games.
    private void EnemyAddedEvent()
    {
        EnemyCount++;
    }
    
    private void EnemyKilledEvent()
    {
        EnemyCount--;
        if(EnemyCount <= 0 && !_isMultiplayer)
        {
            GameEventBus.Win?.Invoke();
        }
    }
    
    private void PlayerDeathEvent(int id)
    {
        //remove dead player from player list
        PlayerStats deadPlayer = players.GetItem(id);
        PhotonView deadPlayerView = deadPlayer.gameObject.GetPhotonView();
        players.Remove(id);
        //in singleplayer game, only lose if player dies and there are enemies remaining.
        if (!_isMultiplayer && EnemyCount > 0)
        {
            GameEventBus.Loss?.Invoke();
        }
        //don't do anything if player id doesn't exist or if it is the last player in the scene.
        if (deadPlayer == null || players.Length() < 1)
            return;
        //if the player who died is the local player, call loss.
        if (deadPlayerView.IsMine)
        {
            Debug.Log("loss " + id);
            GameEventBus.Loss?.Invoke();
        }
        //if the player who died is not the local player and they are the last player in the game then call win.
        else if (!deadPlayerView.IsMine && players.Length() < 2)
        {
             Debug.Log("win " + id);
             GameEventBus.Win?.Invoke();
        }  
    }
    //Adds player to the players list.
    private void PlayerAddedEvent(int id, PlayerStats player)
    {
        players.Add(id, player);
        if(players.Length() > 1)
        {
            _isMultiplayer = true;
        }
        Debug.Log("player added " + id + "  " + players.Length());
    }

    #endregion

}
