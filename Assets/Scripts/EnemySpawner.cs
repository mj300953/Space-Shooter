using UnityEngine;
using System.Collections;
using Damageables;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private Transform spawnPoint4;
    [SerializeField] private Transform spawnPoint5;
    [SerializeField] private Transform spawnPoint6;
    [SerializeField] private Transform spawnPoint7;
    [SerializeField] private Transform spawnPoint8;
    [SerializeField] private Transform spawnPoint9;
    [SerializeField] private Transform kamikazeT;
    [SerializeField] private Transform kamikazeLT;
    [SerializeField] private Transform kamikazeRT;
    [SerializeField] private GameObject bomber;
    [SerializeField] private GameObject kamikaze;
    [SerializeField] private GameObject kamikazeL;
    [SerializeField] private GameObject kamikazeR;
    [SerializeField] private float spawnInterval;

	private IEnumerator _spawn1;
	private IEnumerator _spawn2;
	private IEnumerator _spawn3;
	private IEnumerator _spawn4;
	private IEnumerator _spawn5;
	private EnemyDamageable _enemy;
	private PlayerDamageable _player;

	public int TotalEnemyCount;

	private int _starsAmount;
	
	private void Start()
	{
		StartCoroutine(SpawnManager());
	}

	private IEnumerator SpawnManager()
	{
		yield return new WaitForSeconds(5f);

		_spawn1 = Spawn(kamikazeL, spawnPoint2, kamikazeLT);
		StartCoroutine(_spawn1);
		yield return new WaitForSeconds(5 * spawnInterval);
		StopCoroutine(_spawn1);
		yield return new WaitForSeconds(2f);

		_spawn1 = Spawn(kamikazeR, spawnPoint3, kamikazeRT);
		StartCoroutine(_spawn1);
		yield return new WaitForSeconds(5 * spawnInterval);
		StopCoroutine(_spawn1);
		yield return new WaitForSeconds(2f);

		_spawn1 = Spawn(kamikazeL, spawnPoint1, kamikazeLT);
		StartCoroutine(_spawn1);
		yield return new WaitForSeconds(5 * spawnInterval);
		StopCoroutine(_spawn1);
		yield return new WaitForSeconds(2f);

		_spawn1 = Spawn(kamikazeR, spawnPoint4, kamikazeRT);
		StartCoroutine(_spawn1);
		yield return new WaitForSeconds(5 * spawnInterval);
		StopCoroutine(_spawn1);
		yield return new WaitForSeconds(2f);

		_spawn1 = Spawn(kamikaze, spawnPoint7, kamikazeT);
		_spawn2 = Spawn(kamikaze, spawnPoint6, kamikazeT);
		_spawn3 = Spawn(kamikaze, spawnPoint8, kamikazeT);
		_spawn4 = Spawn(kamikaze, spawnPoint5, kamikazeT);
		_spawn5 = Spawn(kamikaze, spawnPoint9, kamikazeT);
		StartCoroutine(_spawn1);
		StartCoroutine(_spawn2);
		StartCoroutine(_spawn3);
		StartCoroutine(_spawn4);
		StartCoroutine(_spawn5);
		yield return new WaitForSeconds(spawnInterval);
		StopCoroutine(_spawn1);
		StopCoroutine(_spawn2);
		StopCoroutine(_spawn3);
		StopCoroutine(_spawn4);
		StopCoroutine(_spawn5);
		yield return new WaitForSeconds(2f);

		_spawn1 = Spawn(bomber, spawnPoint5, kamikazeT);
		_spawn2 = Spawn(bomber, spawnPoint9, kamikazeT);
		_spawn3 = Spawn(kamikaze, spawnPoint5, kamikazeT);
		_spawn4 = Spawn(kamikaze, spawnPoint9, kamikazeT);
		StartCoroutine(_spawn1);
		StartCoroutine(_spawn2);
		yield return new WaitForSeconds(spawnInterval);
		StopCoroutine(_spawn1);
		StopCoroutine(_spawn2);
		yield return new WaitForSeconds(5f);
		StartCoroutine(_spawn3);
		StartCoroutine(_spawn4);
		yield return new WaitForSeconds(5 * spawnInterval);
		StopCoroutine(_spawn3);
		StopCoroutine(_spawn4);
		GameEnded();
	}

	private IEnumerator Spawn(GameObject spawn,Transform pos, Transform rot)
	{
		yield return null;

		while (true)
		{
			TotalEnemyCount ++;
			Debug.Log("there are " + TotalEnemyCount + " enemies");
			Instantiate(spawn, pos.position, rot.rotation);
			yield return new WaitForSeconds(spawnInterval);
		}
	}

	private void GameEnded()
	{
		float killedPercentage = _enemy.KilledEnemyCount / TotalEnemyCount;
		switch (killedPercentage)			
		{				
			case 1f:
				_starsAmount = 3;
Debug.Log("_starsAmount");
				break;

			case > 0.8f:
				_starsAmount = 2;				
Debug.Log("_starsAmount");	
				break;

			case 0.8f:
				_starsAmount = 2;
Debug.Log("_starsAmount");
				break;

			case < 0.8f:				
				_starsAmount = 1;
Debug.Log("_starsAmount");
				break;
		}
	}
}
