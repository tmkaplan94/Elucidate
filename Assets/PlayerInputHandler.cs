
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] PickUpSystem _pickUpSystem;
    [SerializeField] FireWeapon _fireWeapon;
    private PlayerInputScript _inputActions;
    private Vector3 movementInput;
    private Vector3 rotateTarget;

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
        _inputActions.Default.Interact.performed += _ => Interact();
        /*_inputActions.Default.Move.performed += ctx => Move(ctx.ReadValue<Vector3>());*/
        _inputActions.Default.Shoot.performed += _ => Shoot();
    }
    private void Update()
    {
       rotateTarget = _playerMovement.GetLookAtTarget(_inputActions.Default.Aim.ReadValue<Vector2>());
       movementInput = _inputActions.Default.Move.ReadValue<Vector3>();
    }
    private void FixedUpdate()
    {
        _playerMovement.Rotate(rotateTarget);
        _playerMovement.Move(movementInput);
    }

    private void Shoot()
    {
        _fireWeapon.Shoot();
    }
    private void Interact()
    {
        /********************* FIX THIS : HEAVY COUPLING HERE *********************/
        GameObject itemPickedUp = _pickUpSystem.Interacted();
        if (itemPickedUp)
        {
            if (itemPickedUp.CompareTag("Weapon"))
            {
                _fireWeapon.UpdateCurrentWeapon();
            }
        }
    }
}
