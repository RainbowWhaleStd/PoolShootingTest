using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Pool[] pools;
	[SerializeField] private GameObject[] spawnPoints;
	[SerializeField, Range(0, 2)] public int objectType = 0;
	[SerializeField, Range(1, 3)] public int spawnType = 1;
	[SerializeField] private float spawnRate = 1f;

	private float nextSpawn = 0f;

	protected void FixedUpdate()
	{
		if (Time.time > nextSpawn)
		{
			nextSpawn = Time.time + spawnRate;
			Spawn();
		}
	}

	void Spawn()
	{
		switch (spawnType)
		{
			case 1:
				CreateObject(pools[objectType], spawnPoints[0], 0);
				break;
			case 2:
				CreateObject(pools[objectType], spawnPoints[1], 0);
				CreateObject(pools[objectType], spawnPoints[2], 0);

				break;
			case 3:
				CreateObject(pools[objectType], spawnPoints[0], 0);
				CreateObject(pools[objectType], spawnPoints[1], 5);
				CreateObject(pools[objectType], spawnPoints[2], -5);
				break;
		}
	}

	private void CreateObject(Pool bulletPool, GameObject firePoint, float rotatateAngle)
	{
		var obj = bulletPool.Spawn();
		obj.transform.position = firePoint.transform.position;
		obj.transform.rotation = Quaternion.Euler(0, 0, rotatateAngle);
	}
}
