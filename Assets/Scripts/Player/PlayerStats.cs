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


public class PlayerStats : MonoBehaviourPunCallbacks, IDamageable<float>
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

    private int _id;

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
            SetHealthBar();
        }   
    }
    private void OnEnable()
    {
        _id = GetComponent<PhotonView>().ViewID;
        GameEventBus.PlayerAdded?.Invoke(_id, this);
    }
    private void OnDisable()
    {

    }

    // IDamagable method to decrement _health, calls Die() if _health reaches 0.
    public void TakeDamage(float damage)
    {
        if (_view.IsMine)
        {
            photonView.RPC("TakeDamageRPC", RpcTarget.All, damage);
            SetHealthBar(); 
        }
        if (_health <= 0f)
        {
            photonView.RPC("KillRPC", RpcTarget.All);
        }
    }
    bool isdead = false;
    // method to die if _health has reached 0.
    [PunRPC]
    private void KillRPC()
    {
        GameEventBus.PlayerDeath?.Invoke(_id);
        Destroy(gameObject);      
    }
    [PunRPC]
    private void TakeDamageRPC(float amount)
    {
        _health -= amount;
    }

    void SetHealthBar()
    {
        _uihealthbar.localScale = new Vector3(((float)_health/(float)MaxHealth), 1f, 1f);
    }
}
