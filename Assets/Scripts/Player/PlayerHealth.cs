using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
	private SO_GenericEvent _PlayerDeathEvent;
	private bool _Dead;

	private void Start()
	{
		_PlayerDeathEvent = GetComponent<PlayerController>().PlayerData.PlayerDeathEvent;
		_Dead = false;
	}

	public void Kill()
	{
		Destroy(gameObject);
		_PlayerDeathEvent.Invoke(null);
	}
}
