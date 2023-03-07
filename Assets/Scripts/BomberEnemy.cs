using System;
using System.Collections;
using UnityEngine;
using Weapons;

public class BomberEnemy : MonoBehaviour
{
    [SerializeField] private Vector3 entranceMoveVector;
    [SerializeField] private Vector3 exitMoveVector;
    [SerializeField] private float moveSpeed = 10f;

    private BaseWeapon _weapon;
    private Vector3 _entrancePosition;
    private Vector3 _exitPosition;

    private void Awake()
    {
        _weapon = GetComponent<BaseWeapon>();
        _entrancePosition = transform.position + entranceMoveVector;
    }

    private void Start()
    {
        StartCoroutine(Interact());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Interact()
    {
        yield return Move(_entrancePosition);
        _exitPosition = transform.position + exitMoveVector;
        yield return new WaitForSeconds(0.25f);
        _weapon.TryShooting();
        yield return new WaitForSeconds(1.5f);
        _weapon.TryShooting();
        yield return new WaitForSeconds(4f);
        yield return Move(_exitPosition);
    }

    private IEnumerator Move(Vector3 position)
    {
        while (Vector2.Distance(transform.position, position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}
