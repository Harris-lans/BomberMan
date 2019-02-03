using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenericEvent", menuName = "BomberMan/Utilities/GenericEvent")]
public class SO_GenericEvent : ScriptableObject 
{
	private event GenericAction _Event;

	public void AddListenerToEvent(GenericAction action)
	{
		_Event += action;
	}

	public void RemoveListenerToEvent(GenericAction action)
	{
		_Event -= action;
	}

	public void Invoke(object data)
	{
		_Event.Invoke(data);
	}

	public delegate void GenericAction (object data);
}
