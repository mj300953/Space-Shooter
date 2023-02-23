using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Bullet
{
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float shotCooldown;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _playerRigidbody;

    private float _horizontalInput;
    private float _verticalInput;
    private float _shotFinish;
    
    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _playerRigidbody.velocity = moveSpeed * _horizontalInput * Vector2.right + moveSpeed * _verticalInput * Vector2.up;
        
        if (Input.GetKey(KeyCode.Space) && Time.time >= _shotFinish)
        {
            Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, Quaternion.identity);
            bullet.Shot();
            _shotFinish = Time.time + shotCooldown;
        }
    }
}