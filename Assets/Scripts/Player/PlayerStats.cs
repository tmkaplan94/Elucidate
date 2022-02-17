/*
 * Author: Grant Reed
 * Contributors: Loc Trinh
 * Description: This class holds all the information about a player.
 *
 * This includes health, move speed, current weapon, current items, etc.
 * This class has getters and setters for each of its adjustable fields in game.
 * This is how player states are actually changed in game.
 * There is a lot of communication between this class and many other classes about the player in game.
 *        
 * TODO: Changing damage and pickups will require a lot of change with this class as well.
 */
using UnityEngine;
using Photon.Pun;

public class PlayerStats : MonoBehaviourPunCallbacks, IDamageable<float>, IPunObservable
{
    // editor exposed fields
    [SerializeField] PhotonView _view;
    [SerializeField] RectTransform _uihealthbar;
    [SerializeField] GameObject uiHealth;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _pickupRange;
    [SerializeField] private GameObject _currentWeapon;
    [SerializeField] private float _rotationSpeed;
    //[SerializeField] private GameObject currentItem;
    
    #region Properties
    
    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = value;
    }
    public float Health
    {
        get => _health;
        set => _health = value;
    }
    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }
    public float PickUpRange
    {
        get => _pickupRange;
        set => _pickupRange = value;
    }
    public float RotationSpeed
    {
        get => _rotationSpeed;
        set => _rotationSpeed = value;
    }
    public GameObject CurrentWeapon
    {
        get => _currentWeapon;
        set => _currentWeapon = value;
    }

    #endregion
    
    private void Start()
    {
        _health = _maxHealth;
        if(_view.IsMine)
        {
            uiHealth.SetActive(true);
            SetHealthBar(_health);
        }   
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            //stream.SendNext(IsFiring);
            stream.SendNext(_health);
        }
        else
        {
            // Network player, receive data
            //this.IsFiring = (bool)stream.ReceiveNext();
            _health = (float)stream.ReceiveNext();
        }
    }

    // IDamagable method to decrement _health, calls Die() if _health reaches 0.
    public void TakeDamage(float damage)
    {
        if(_view.IsMine)
        {
            _health -= damage;
            SetHealthBar(_health);
            if (_health <= 0f)
            {
                Kill();
            }
        }
    }

    // IDamageable method to die if _health has reached 0.
    public void Kill()
    {
        PhotonNetwork.Destroy(gameObject);
        if(_view.IsMine)
        {
            Debug.Log("dead");
            GameEventBus.Publish(GameEvent.LOSS);
        }
    }

    void SetHealthBar(float amount)
    {
        _uihealthbar.localScale = new Vector3(((float)amount/(float)MaxHealth), 1f, 1f);
    }
}
