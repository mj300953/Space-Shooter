using System;
using System.Collections;
using UnityEngine;
using Damageables;
using PathCreation;
using UnityEngine.Serialization;

[Serializable]
	public struct EnemySpawnData
	{
		[SerializeField] private PathCreator creator1;
		[SerializeField] private PathCreator creator2;
		[SerializeField] private Enemy prefab;

		public PathCreator Creator1 => creator1;
		public PathCreator Creator2 => creator2;
		public Enemy Prefab => prefab;
	}
	
	[Serializable]
	public struct EnemiesSpawnData
	{
		[SerializeField] private EnemySpawnData[] enemySpawnsData;
		[SerializeField] private float postSpawnInterval;

		public EnemySpawnData[] EnemySpawnsData => enemySpawnsData;
		public float PostSpawnInterval => postSpawnInterval;
	}
	
	[Serializable]
	public struct EnemyWave
	{
		[SerializeField] private EnemiesSpawnData[] enemiesSpawnsData;

		public EnemiesSpawnData[] EnemiesSpawnsData => enemiesSpawnsData;
	}

	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private EnemyWave[] enemyWaves;
		[SerializeField] private float spawnDelay;

        
		public static int EnemyCount { get; private set; }

		private void Start()
		{
			StartCoroutine(SpawnEnemies());
		}

		private IEnumerator SpawnEnemies()
		{
			yield return new WaitForSeconds(spawnDelay);

			foreach (EnemyWave wave in enemyWaves)
			{
				foreach (EnemiesSpawnData enemiesSpawnData in wave.EnemiesSpawnsData)
				{
					foreach (EnemySpawnData enemySpawnData in enemiesSpawnData.EnemySpawnsData)
					{
						EnemyCount++;
						Enemy enemy = Instantiate(enemySpawnData.Prefab, Vector3.up, Quaternion.identity);
						enemy.Init(enemySpawnData.Creator1.path);
						enemy.Init2(enemySpawnData.Creator2.path, 8f);
						yield return new WaitForSeconds(enemiesSpawnData.PostSpawnInterval);
					}
				}
			}
		}
	}
	
