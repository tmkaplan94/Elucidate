
/*
 * Author: Grant Reed, Tyler Kaplan
 * Contributors: Loc Trinh
 * Description: PlayerInputHandler invokes events based on the player's input. It calls the movement functions
 *              in the playerMovement script to make its player actually move.
 *              It is turned off by playernetworkstart.cs if this player is not the local player.
 *              It also prevents the player from moving when this player pauses their game.
 */
using UnityEngine;
using Photon.Pun;

public class PlayerInputHandler : MonoBehaviourPun
{
    [SerializeField] PlayerMovement _playerMovement;
    private PlayerInputScript _inputActions;
    private Vector3 movementInput;
    private Vector3 rotateTarget;
    private bool isPause = false;

    public delegate void PlayerInput();
    public event PlayerInput Shoot;
    public event PlayerInput Interact;
    public event PlayerInput CheckInteract;
    

    #region
    private void Awake()
    {
        _inputActions = new PlayerInputScript();
    }
    private void OnEnable()
    {
        _inputActions.Enable();
        GameEventBus.Resume += DisableMovement; // Need this for when Resume is clicked
        _inputActions.Default.Interact.performed += _ => InteractPressed();
        _inputActions.Default.Pause.performed += _ => escapePressed();  // Need this for when Esc is pressed
    }
    private void OnDisable()
    {
        _inputActions.Disable();
        GameEventBus.Resume -= DisableMovement; 
        _inputActions.Default.Interact.performed -= _ => InteractPressed();
        _inputActions.Default.Pause.performed -= _ => escapePressed();
    }
    #endregion
    private void InteractPressed()
    {
        if(!isPause)
        {
            Interact?.Invoke();
            CheckInteract?.Invoke();
        }
    }
    private void DisableMovement()
    {
        isPause = false;
    }
    private void escapePressed()
    {
        if(isPause)
        {
            GameEventBus.Resume?.Invoke();
            DisableMovement();
        }
        else{
            GameEventBus.Pause?.Invoke();
            isPause = true;
        }
    }
    private void Update()
    {
        if(!isPause)
        {
            rotateTarget = _playerMovement.GetLookAtTarget(_inputActions.Default.Aim.ReadValue<Vector2>());
            movementInput = _inputActions.Default.Move.ReadValue<Vector3>();
            if (_inputActions.Default.Shoot.ReadValue<float>() > 0f)
            {
                Shoot?.Invoke();
            }
        }
    }
    private void FixedUpdate()
    {
        if(!isPause)
        {
            _playerMovement.Rotate(rotateTarget);
            _playerMovement.Move(movementInput);
        }
    }
}
