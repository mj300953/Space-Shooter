using UnityEngine;
using Weapons;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _playerRigidbody;
    private BaseWeapon _weapon;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    private float _horizontalInput;
    private float _verticalInput;
    private bool _gotShotInput;
    
    private static readonly int SpeedHash = Animator.StringToHash("Speed");
    
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _weapon = GetComponent<BaseWeapon>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedHash, Mathf.Abs(_playerRigidbody.velocity.x) + Mathf.Abs((_playerRigidbody.velocity.y)));
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
        if (_gotShotInput && _spriteRenderer.enabled)
        {
            _weapon.TryShooting();
        }
    }
}