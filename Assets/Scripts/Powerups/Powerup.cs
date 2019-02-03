using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
	#region Member Variables

		[Header("Powerup Details")]
		public SO_Tag AttackTag;
		public SO_Tag PowerupTag;
		[SerializeField]
		private float _PowerupTime = 10;

		private SO_GenericEvent _PowerupActivatedEvent;
		private SO_GenericEvent _PowerupDeactivatedEvent;
		public PowerupManager _Owner;

	#endregion

	#region Life Cycle

		private void Awake()
		{
			var owner = _Owner.GetComponent<PlayerController>();
			_PowerupActivatedEvent = owner.PlayerData.PowerupActivatedEvent;
			_PowerupDeactivatedEvent = owner.PlayerData.PowerupDeactivatedEvent;
		}

	#endregion
	
	#region Member Functions
		
		public virtual void Initialize(PowerupManager owner)
		{
			_Owner = owner;
			Activate();
		}

		public virtual void Activate()
		{
			_PowerupActivatedEvent.Invoke(this);
			StartCoroutine(PowerupTimer());
		}

		public virtual void Deactivate()
		{
			_PowerupDeactivatedEvent.Invoke(this);
		}

		private IEnumerator PowerupTimer()
		{
			yield return new WaitForSeconds(_PowerupTime);
			Deactivate();
		}

	#endregion
}
