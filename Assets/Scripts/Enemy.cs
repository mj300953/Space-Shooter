using System;
using System.Collections;
using PathCreation;
using UnityEngine;
using Weapons;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float firstShot;
    [SerializeField] private float secondShot;
    
    private BaseWeapon _weapon;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _transform = transform;
        _weapon = GetComponent<BaseWeapon>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private void Update()
    {
        if(_transform.position.y <= -5.8f || _transform.position.y >= 7f)
        {
            Destroy(gameObject);
        }
    }

    public void Init(VertexPath path)
    {
        StartCoroutine(Move(path));
    }
    
    public IEnumerator Init2(VertexPath path, float waitBeforeSpawn)
    {
        StartCoroutine(Move2(path, waitBeforeSpawn));
        return null;
    }

    private IEnumerator Shooting()
    {
        yield return new WaitForSeconds(firstShot);
        if (_spriteRenderer.enabled)
        {
            _weapon.TryShooting();
        }
        yield return new WaitForSeconds(secondShot);
        if (_spriteRenderer.enabled)
        {
            _weapon.TryShooting();
        }
    }

    private IEnumerator Move(VertexPath path)
    {
        float traveledDistance = 0f;
        float maxDistance = path.length;

        while (traveledDistance < maxDistance)
        {
            _transform.position = path.GetPointAtDistance(traveledDistance);
            traveledDistance += Time.deltaTime * moveSpeed;
            yield return null;
        }
    }
    
    private IEnumerator Move2(VertexPath path, float waitBeforeSpawn)
    {
        yield return new WaitForSeconds(waitBeforeSpawn);
        float traveledDistance = 0f;
        float maxDistance = path.length;

        while (traveledDistance < maxDistance)
        {
            _transform.position = path.GetPointAtDistance(traveledDistance);
            traveledDistance += Time.deltaTime * moveSpeed;
            yield return null;
        }
    }
}
