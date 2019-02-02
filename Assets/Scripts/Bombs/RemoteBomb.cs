using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBomb : ABomb 
{
	private void Start () 
	{
		// Listening to the detonating event
		_Owner.BombFiredEvent.AddListener(Explode);
	}
}
