using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScreen : UIScreen 
{
	[SerializeField]
	private SO_MatchState _MatchState;
	[SerializeField]
	private Text _MatchTimer;
	[SerializeField]
	private Text _Player1Score;
	[SerializeField]
	private Text _Player2Score;

	private void OnEnable()
	{
		_Player1Score.text = _MatchState.Player1Score.ToString();
		_Player2Score.text = _MatchState.Player2Score.ToString();
	}

	private void Update()
	{
		_MatchTimer.text = _MatchState.MatchTime.ToString();
	}

}
