using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPickupSpawner : MonoBehaviour 
{
	[SerializeField]
	private GameObject[] _PickupPool;
	[SerializeField]
	[Range(0, 100)]
	private int _ChanceToSpawn;

	public void SpawnPickup()
	{
		int chance = Random.Range(1, 101);
		if (chance >= 1 && chance <= _ChanceToSpawn)
		{
			GameObject chosenPickup = _PickupPool[Random.Range(0, _PickupPool.Length)];
			Instantiate(chosenPickup, transform.position, chosenPickup.transform.rotation);
		}
	}
}
