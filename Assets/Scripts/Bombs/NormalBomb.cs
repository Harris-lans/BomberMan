using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBomb : ABomb
{
	[SerializeField]
	private float _BombDetonationTime; 

	private void Start() 
	{
		StartCoroutine(BombTimer());
	}

	private IEnumerator BombTimer()
	{
		yield return new WaitForSeconds(_BombDetonationTime);
		Explode();
	}
}
