using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestructibleObjects : MonoBehaviour 
{
	[SerializeField]
	[Range(0, 100)]
	private float _ObjectHealth;
	[SerializeField]
	private UnityEvent _ObjectDestroyedEvent;

	public void Damage(float damageAmount)
	{
		_ObjectHealth -= damageAmount;
		if (_ObjectHealth <= 0)
		{
			Destroy(gameObject);
			_ObjectDestroyedEvent.Invoke();
		}
	}
}
