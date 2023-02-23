using UnityEngine;
using Weapons;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _playerRigidbody;
    private BaseWeapon _weapon;

    private float _horizontalInput;
    private float _verticalInput;
    private bool _gotShotInput;
    
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _weapon = GetComponent<BaseWeapon>();
    }

    private void Update()
    {
        GetInput();
        Move();
        TryShooting();
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _gotShotInput = Input.GetKey(KeyCode.Space);
    }

    private void Move()
    {
        Vector2 horizontalDirection = _horizontalInput * Vector2.right;
        Vector2 verticalDirection = _verticalInput * Vector2.up;
        Vector2 targetDirection = horizontalDirection + verticalDirection;
        targetDirection = Vector2.ClampMagnitude(targetDirection, 1f);
        _playerRigidbody.velocity = targetDirection * moveSpeed;
    }

    private void TryShooting()
    {
        if (_gotShotInput)
        {
            _weapon.TryShooting();
        }
    }
}