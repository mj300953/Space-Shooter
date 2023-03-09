using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float animationTime;

	private void Start()
    {
        Destroy(gameObject, animationTime);
    }
}
