using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	private SO_GenericEvent _PlayerDeathEvent;

	private void Start()
	{
		_PlayerDeathEvent = GetComponent<PlayerController>().PlayerData.PlayerDeathEvent;
	}

	public void Kill()
	{
		_PlayerDeathEvent.Invoke(null);
		Destroy(gameObject);
	}
}
