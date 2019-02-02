using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour 
{
	[SerializeField]
	private float _TimeBeforeDestroying = 3.0f;

	private void Start() 
	{
		Destroy(gameObject, _TimeBeforeDestroying);
	}
}
