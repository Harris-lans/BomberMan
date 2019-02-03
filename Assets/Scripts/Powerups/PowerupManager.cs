using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour 
{
	#region Member Variables

		private List<Powerup> _Powerups;
		private SO_GenericEvent _PowerupDeactivatedEvent;

	#endregion

	#region Life Cycle

		private void Start()
		{
			_Powerups = new List<Powerup>();
			var playerController = GetComponent<PlayerController>();
			_PowerupDeactivatedEvent = playerController.PlayerData.PowerupDeactivatedEvent;
			_PowerupDeactivatedEvent.AddListenerToEvent(OnPowerupDeactivated);
		}

		private void OnTriggerEnter(Collider collider)
		{
			Powerup powerup = collider.GetComponent<Powerup>();

			if (powerup != null)
			{
				// Resetting a powerup if it has already been picked up
				for (int i = 0; i < _Powerups.Count; ++i)
				{
					if (_Powerups[i].PowerupTag == powerup.PowerupTag)
					{
						_Powerups[i].Deactivate();
						break;
					}
				}

				// Creating a new instance of the power up
				powerup = Instantiate(powerup);
				powerup.transform.parent = transform;
				powerup.Initialize(this);
			}	
		}

	#endregion

	#region Member Functions

		private void OnPowerupDeactivated(object data)
		{
			Powerup powerup = (Powerup)data;
			_Powerups.Remove(powerup);
			Destroy(powerup);
		}

	#endregion
}
