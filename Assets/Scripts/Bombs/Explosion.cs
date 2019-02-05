using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour 
{
	[Header("Explosion Details")]
	[SerializeField]
	private float _DamageAmount;

	private void OnTriggerEnter(Collider collider)
	{
		PlayerHealth playerHealth = collider.GetComponent<PlayerHealth>();
		if (playerHealth != null)
		{
			playerHealth.Kill();
		}

		DestructibleObjects destructibleObjects = collider.GetComponent<DestructibleObjects>();
		if (destructibleObjects != null)
		{
			destructibleObjects.Damage(_DamageAmount);
		}

		if (collider.GetComponent<APowerup>() != null || collider.GetComponent<Pickup>() != null)
		{
			Destroy(collider.gameObject);
		}

		ABomb bomb = collider.GetComponent<ABomb>();
		if (bomb != null)
		{
			bomb.Explode();
		}
	}
}
