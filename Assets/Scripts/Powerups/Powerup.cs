using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour
{
	#region Member Variables

		[Header("Powerup Details")]
		public SO_Tag PowerupTag;
		public Sprite PowerupSprite;
		[SerializeField]
		private float _PowerupTime = 10;

		private SO_GenericEvent _PowerupActivatedEvent;
		private SO_GenericEvent _PowerupDeactivatedEvent;
		[HideInInspector]
		public PowerupManager _Owner;
		protected PlayerController _PlayerController;
		public static List<Powerup> SpawnedPowerups;

	#endregion

	
	#region Member Functions

		private void OnEnable()
		{
			SpawnedPowerups.Add(this);
		}

		private void OnDisable()
		{
			SpawnedPowerups.Remove(this);
		}
		
		public virtual void Initialize(PowerupManager owner)
		{
			_Owner = owner;
			_PlayerController = _Owner.GetComponent<PlayerController>();
			_PowerupActivatedEvent = _PlayerController.PlayerData.PowerupActivatedEvent;
			_PowerupDeactivatedEvent = _PlayerController.PlayerData.PowerupDeactivatedEvent;
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

		public float PowerupTime
		{
			get
			{
				return _PowerupTime;
			}
		}

	#endregion
}
