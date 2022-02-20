
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
        GameEventBus.Resume += MenuUnPause; // Need this for when Resume is clicked
        _inputActions.Default.Interact.performed += _ => InteractPressed();
        _inputActions.Default.Pause.performed += _ => escapePressed();  // Need this for when Esc is pressed
    }
    private void OnDisable()
    {
        _inputActions.Disable();
        GameEventBus.Resume -= MenuUnPause; 
        _inputActions.Default.Interact.performed -= _ => InteractPressed();
        _inputActions.Default.Pause.performed -= _ => escapePressed();
    }
    #endregion
    private void InteractPressed()
    {
        if(!isPause)
        {
            if(Interact != null)
                Interact();
            if(CheckInteract != null)
                CheckInteract();
        }
    }
    private void MenuUnPause()
    {
        isPause = false;
    }
    private void escapePressed()
    {
        if(isPause)
        {
            GameEventBus.Resume?.Invoke();
            MenuUnPause();
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
                if (Shoot != null)
                    Shoot();
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
