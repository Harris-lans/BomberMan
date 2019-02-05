using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
	public void SpawnGameobject(GameObject gameObject)
	{
		Instantiate(gameObject, transform.position, Quaternion.identity);
	}
}
