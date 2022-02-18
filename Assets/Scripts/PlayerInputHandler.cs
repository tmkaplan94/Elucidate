
using UnityEngine;
using Photon.Pun;

public class PlayerInputHandler : MonoBehaviourPun
{
    [SerializeField] PlayerMovement _playerMovement;
    private PlayerInputScript _inputActions;
    private Vector3 movementInput;
    private Vector3 rotateTarget;

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
    }
    private void OnDisable()
    {
        _inputActions.Disable();
    }
    private void Start()
    {      
        _inputActions.Default.Interact.performed += _ => InteractPressed();
    }
    #endregion
    private void InteractPressed()
    {
        if(Interact != null)
            Interact();
        if(CheckInteract != null)
            CheckInteract();
    }
    private void Update()
    {
        rotateTarget = _playerMovement.GetLookAtTarget(_inputActions.Default.Aim.ReadValue<Vector2>());
        movementInput = _inputActions.Default.Move.ReadValue<Vector3>();
        if (_inputActions.Default.Shoot.ReadValue<float>() > 0f)
        {
            if (Shoot != null)
                Shoot();
        }
    }
    private void FixedUpdate()
    {
        _playerMovement.Rotate(rotateTarget);
        _playerMovement.Move(movementInput);
    }
}
