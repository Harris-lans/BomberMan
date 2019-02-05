using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour 
{
	[SerializeField]
	private SO_PlayerData _PlayerData;

	[Header("UI Information")]
	[SerializeField]
	private GameObject _PowerupContainer;
	[SerializeField]
	private PowerupUI _PowerupUI;
	[SerializeField]
	private Text _BombCount;

	private void OnEnable()
	{
		_PlayerData.PowerupActivatedEvent.AddListenerToEvent(OnPowerupActivated);
	}

	private void OnDisable()
	{
		_PlayerData.PowerupActivatedEvent.RemoveListenerToEvent(OnPowerupActivated);
	}

	private void Update()
	{
		_BombCount.text = _PlayerData.BombAttackStats.Ammo.ToString();	
	}

	private void OnPowerupActivated(object data)
	{
		APowerup powerup = (APowerup)data;

		// Checking if the powerup is already active and removing the UI
		PowerupUI[] powerupUIs = _PowerupContainer.GetComponentsInChildren<PowerupUI>();
		foreach (var powerupUI in powerupUIs)
		{
			if (powerupUI.Powerup.PowerupTag == powerup.PowerupTag)
			{
				Destroy(powerupUI.gameObject);
			}
		}

		// Adding the powerup 
		var ui = Instantiate(_PowerupUI, _PowerupContainer.transform);
		ui.Initialize(powerup);
	}
}
