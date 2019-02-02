using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABomb : MonoBehaviour 
{
	#region Member Variables

		[Header("Bomb Explosion Details")]
		[SerializeField]
		protected float _ExplosionTime = 3;
		[SerializeField]
		protected GameObject _ExplosionPrefab;
		[SerializeField]
		protected float _ExplosionRadius;
		[SerializeField]
		protected Vector3[] _ExplosionDirections;

		protected BombAttack _Owner;

	#endregion

	private void Awake() 
	{
		// Normalizing Directions in case the 
		for (int i = 0; i < _ExplosionDirections.Length; ++i)
		{
			_ExplosionDirections[i].Normalize();
		}	
	}

	protected virtual void Explode()
	{
		// Directional Explosion
		foreach (var direction in _ExplosionDirections)
		{
			// Instantiating the explosion
			GameObject explosion = Instantiate(_ExplosionPrefab);
			Vector3 pointOfReachOfExplosion = transform.position + (direction * _ExplosionRadius);
			RaycastHit raycastHit;
			
			if (Physics.Raycast(transform.position, direction, out raycastHit, _ExplosionRadius))
			{
				pointOfReachOfExplosion = raycastHit.point;
			}
			
			// Placing the explosion in the middle
			explosion.transform.position = ((transform.position - pointOfReachOfExplosion) / 2) + transform.position;

			// Rotating the explosion
			explosion.transform.rotation = Quaternion.FromToRotation(Vector3.up, (transform.position - pointOfReachOfExplosion));

			// Scaling the lightning arc
			Vector3 currentScale = explosion.transform.localScale;
			currentScale.y = Vector3.Magnitude(transform.position - pointOfReachOfExplosion) / 2; 
			explosion.transform.localScale = currentScale;

			Destroy(explosion.gameObject, _ExplosionTime); 
		}

		Destroy(gameObject);
	}

	public void Initialize(BombAttack owner)
	{
		_Owner = owner;
	}
}
