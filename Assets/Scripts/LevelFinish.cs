using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Canvas endMenu;
    [SerializeField] private Image star1;
    [SerializeField] private Image star2;
    [SerializeField] private Image star3;

    public static bool PlayerLeaving { get; private set; }
    
    private int _exitLayer;
    private int _starsAmount;
    private bool _playerLeft;

    private static readonly int AdjustingHash = Animator.StringToHash("Adjusting");
    private static readonly int ExitingHash = Animator.StringToHash("Exiting");

    private void Awake()
    {
        PlayerLeaving = false;
        _exitLayer = LayerMask.NameToLayer("Start");
    }

    private void Start()
    {
        StartCoroutine(Exit());
    }

    private void Update()
    {
        gameObject.SetActive(Ended.GameEnded);
        endMenu.gameObject.SetActive(_playerLeft);
        star1.gameObject.SetActive(_starsAmount >= 1);
        star2.gameObject.SetActive(_starsAmount >= 2);
        star3.gameObject.SetActive(_starsAmount == 3);
    }

    private IEnumerator Exit()
    {
        PlayerLeaving = true;
        playerTransform.gameObject.layer = _exitLayer;
        playerAnimator.SetTrigger(AdjustingHash);
        yield return Adjust(Vector3.zero, new Vector3(1.5f, 1.5f, 0f));
        yield return new WaitForSeconds(0.1f);
        yield return Adjust(new Vector3(0f, -1f, 0f), new Vector3(1.5f, 1.5f, 0f));
        playerAnimator.SetTrigger(ExitingHash);
        yield return ExitScene(new Vector3(0f, 8f, 0f));
        yield return new WaitForSeconds(0.5f);
        _playerLeft = true;
        GameEnded();
    }

    private IEnumerator Adjust(Vector3 position, Vector3 scale)
    {
        while (Vector2.Distance(playerTransform.position, position) > 0.1f ||
               Vector2.Distance(playerTransform.localScale, scale) > 0.1f)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, position, Time.deltaTime * 2f);
            playerTransform.localScale = Vector3.MoveTowards(playerTransform.localScale, scale, Time.deltaTime * 0.75f);
            yield return null;
        }
    }

    private IEnumerator ExitScene(Vector3 position)
    {
        while (Vector2.Distance(playerTransform.position, position) > 0.5f)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, position, Time.deltaTime * 5f);
            yield return null;
        }
    }

    private void GameEnded()
    {
        float killedPercentage = (float)Damageables.EnemyDamageable.KilledEnemyCount / EnemySpawner.EnemyCount;
        switch (killedPercentage)
        {
            case 1f:
                _starsAmount = 3;
                break;

            case > 0.8f:
                _starsAmount = 2;
                break;

            case 0.8f:
                _starsAmount = 2;
                break;

            case < 0.8f:
                _starsAmount = 1;
                break;
        }
    }
}