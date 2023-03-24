using UnityEngine;
using Weapons;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
	[SerializeField] private GameObject canvas;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _playerRigidbody2D;
    private BaseWeapon _weapon;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private GameObject _gameObject;
    
    private float _horizontalInput;
    private float _verticalInput;
    private int _powerUpCounter;
    private bool _gotShotInput;
    
	private const float EntryTime = 3.1f;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");

    private void Awake()
    {
        _playerRigidbody2D = GetComponent<Rigidbody2D>();
        _weapon = GetComponent<BaseWeapon>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _animator.SetFloat(SpeedHash, Mathf.Abs(_playerRigidbody2D.velocity.x) + Mathf.Abs((_playerRigidbody2D.velocity.y)));
		canvas.SetActive(Time.time > EntryTime);
        GetInput();
        Move();
        TryShooting();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            _powerUpCounter++;
            Debug.Log(_powerUpCounter);
        }
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _gotShotInput = Input.GetKey(KeyCode.Space);
    }

    private void Move()
    {
        if (_spriteRenderer.enabled && Time.time > EntryTime)
        {
            Vector2 horizontalDirection = _horizontalInput * Vector2.right;
            Vector2 verticalDirection = _verticalInput * Vector2.up;
            Vector2 targetDirection = horizontalDirection + verticalDirection;
            targetDirection = Vector2.ClampMagnitude(targetDirection, 1f);
            _playerRigidbody2D.velocity = targetDirection * moveSpeed;
        }
    }

    private void TryShooting()
    {
        if (_gotShotInput && _spriteRenderer.enabled && Time.time > EntryTime)
        {
            _weapon.TryShooting();
        }
    }
}