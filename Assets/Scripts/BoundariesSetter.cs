using UnityEngine;
using System.Collections;

public class BoundariesSetter : MonoBehaviour
{
    [SerializeField] private Transform leftBoundary;
    [SerializeField] private Transform rightBoundary;
    [SerializeField] private Transform upperBoundary;
    [SerializeField] private Transform lowerBoundary;
    [SerializeField] private Transform background;
    [SerializeField] private Transform respawnPosition;
    [SerializeField] private Transform player;
    [SerializeField] private Animator playerAnimator;

    private Camera _camera;
    
    private Vector2 _leftDownCameraCorner;
    private Vector2 _rightUpCameraCorner;
    private float _boxColliderHeight;
    private float _boxColliderWidth;
    private int _startLayer;
    private int _playerLayer;
    
    private const float BorderWidth = 1f;
    private const float RespawnPosition = 1f;
    
    private static readonly int EnteredHash = Animator.StringToHash("Entered");
    
    private void Awake()
    {
        _camera = Camera.main;
        _startLayer = LayerMask.NameToLayer("Start");
        _playerLayer = LayerMask.NameToLayer("Player");
    }

    private void Start()
    {
        player.gameObject.layer = _startLayer;
        GetSetupValues();
        SetupScale();
        SetupPositions();
        StartCoroutine(Starting());
    }

    private void GetSetupValues()
    {
        _leftDownCameraCorner = _camera.ViewportToWorldPoint(new Vector2(0f, 0f));
        _rightUpCameraCorner = _camera.ViewportToWorldPoint(new Vector2(1f, 1f));
        _boxColliderHeight = _rightUpCameraCorner.y - _leftDownCameraCorner.y;
        _boxColliderWidth = _rightUpCameraCorner.x - _leftDownCameraCorner.x;
    }

    private void SetupScale()
    {
        leftBoundary.localScale = new Vector3(BorderWidth, _boxColliderHeight, 0);
        rightBoundary.localScale = new Vector3(BorderWidth, _boxColliderHeight, 0);
        lowerBoundary.localScale = new Vector3(_boxColliderWidth, BorderWidth, 0);
        upperBoundary.localScale = new Vector3(_boxColliderWidth, BorderWidth, 0);
        background.localScale = new Vector3(_boxColliderWidth, _boxColliderWidth, 0);
        player.localScale = new Vector2(1.5f, 1.5f);
    }

    private void SetupPositions()
    {
        leftBoundary.position = new Vector3(_leftDownCameraCorner.x - BorderWidth / 2, 0, 0);
        lowerBoundary.position = new Vector3(0, _leftDownCameraCorner.y - BorderWidth / 2, 0);
        rightBoundary.position = new Vector3(_rightUpCameraCorner.x + BorderWidth / 2, 0, 0);
        upperBoundary.position = new Vector3(0, _rightUpCameraCorner.y + BorderWidth / 2, 0);
        respawnPosition.position = new Vector3(0, _leftDownCameraCorner.y + RespawnPosition, 0);
        player.position = new Vector3(0, _leftDownCameraCorner.y - 2 * RespawnPosition, 0);
    }
    
    private IEnumerator Starting()
    {
        yield return EnterScene(Vector3.zero);
        playerAnimator.SetTrigger(EnteredHash);
        yield return new WaitForSeconds(0.1f);
        yield return Adjust(respawnPosition.position, Vector3.one);
        player.gameObject.layer = _playerLayer;
    }
    
    private IEnumerator EnterScene(Vector3 position)
    {
        while (Vector2.Distance(player.position, position) > 0.5f)
        {
            player.position = Vector3.MoveTowards(player.position, position, Time.deltaTime * 5f);
            yield return null;
        }
    }
    
    private IEnumerator Adjust(Vector3 position, Vector3 scale)
    {
        while (Vector2.Distance(player.position, position) > 0.1f || Vector2.Distance(player.localScale, scale) > 0.1f)
        {
            player.position = Vector3.MoveTowards(player.position, position, Time.deltaTime * 2f);
            player.localScale = Vector3.MoveTowards(player.localScale, scale, Time.deltaTime * 0.75f);
            yield return null;
        }
    }
}
