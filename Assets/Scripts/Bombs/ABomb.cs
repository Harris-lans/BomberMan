using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABomb : MonoBehaviour 
{
	#region Member Variables

		[SerializeField]
		protected float _Damage = 25;
		protected BombAttack _Owner;
		protected SO_BombAttackStats _BombStats;

	#endregion

	#region Life Cycle

		private void Start() 
		{
			// Normalizing Directions in case the 
			for (int i = 0; i < _BombStats.ExplosionDirections.Length; ++i)
			{
				_BombStats.ExplosionDirections[i].Normalize();
			}	
		}

	#endregion


	#region Member Functions

		protected virtual void Explode()
		{
			// Directional Explosion
			foreach (var direction in _BombStats.ExplosionDirections)
			{
				// Instantiating the explosion
				GameObject explosion = Instantiate(_BombStats.ExplosionPrefab);
				Vector3 pointOfReachOfExplosion = transform.position + (direction * _BombStats.ExplosionRadius);
				RaycastHit raycastHit;
				
				if (Physics.Raycast(transform.position, direction, out raycastHit, _BombStats.ExplosionRadius))
				{
					if (raycastHit.collider.GetComponent<Explosion>() == null)
					{
						pointOfReachOfExplosion = raycastHit.point;
					}
				}
				
				// Placing the explosion in the middle
				explosion.transform.position = ((transform.position - pointOfReachOfExplosion) / 2) + transform.position;

				// Rotating the explosion
				explosion.transform.rotation = Quaternion.FromToRotation(Vector3.up, (pointOfReachOfExplosion - transform.position));

				// Scaling the lightning arc
				Vector3 currentScale = explosion.transform.localScale;
				currentScale.y = Vector3.Magnitude(transform.position - pointOfReachOfExplosion) / 2; 
				explosion.transform.localScale = currentScale;

				Destroy(explosion.gameObject, _BombStats.ExplosionTime); 
			}

			Destroy(gameObject);
		}

		public void Initialize(BombAttack owner, SO_BombAttackStats stats)
		{
			_Owner = owner;
			_BombStats = stats;
		}

	#endregion
}
