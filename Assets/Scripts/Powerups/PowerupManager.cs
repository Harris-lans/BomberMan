using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour 
{
	#region Member Variables

		private List<APowerup> _Powerups;
		private SO_GenericEvent _PowerupDeactivatedEvent;

	#endregion

	#region Life Cycle

		private void Start()
		{
			_Powerups = new List<APowerup>();
		}

		private void OnEnable()
		{
			var playerController = GetComponent<PlayerController>();
			playerController.PlayerData.PowerupDeactivatedEvent.AddListenerToEvent(OnPowerupDeactivated);
		}

		private void OnDisable()
		{
			var playerController = GetComponent<PlayerController>();
			playerController.PlayerData.PowerupDeactivatedEvent.RemoveListenerToEvent(OnPowerupDeactivated);
		}

		private void OnTriggerEnter(Collider collider)
		{
			APowerup powerup = collider.GetComponent<APowerup>();
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

				// Picking up the power up
				collider.gameObject.GetComponent<Renderer>().enabled = false;
				collider.enabled = false;
				powerup.transform.parent = transform;
				powerup.Initialize(this);
			}	
		}

	#endregion

	#region Member Functions

		private void OnPowerupDeactivated(object data)
		{
			APowerup powerup = (APowerup)data;
			_Powerups.Remove(powerup);
			Destroy(powerup.gameObject, 3);
		}

	#endregion
}
