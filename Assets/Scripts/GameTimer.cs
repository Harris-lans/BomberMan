using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour 
{
	[SerializeField]
	private SO_MatchState _MatchState;
	[SerializeField]
	private SO_GenericEvent _GameTimeOverEvent;

	private void Start()
	{
		StartCoroutine(Timer());
	}

	private IEnumerator Timer()
	{
		while(_MatchState.MatchTime > 0)
		{
			_MatchState.MatchTime -= 1;
			yield return new WaitForSeconds(1);
		}
		_GameTimeOverEvent.Invoke(null);
	}
}
