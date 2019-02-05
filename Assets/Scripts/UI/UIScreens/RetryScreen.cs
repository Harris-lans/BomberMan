using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryScreen : UIScreen 
{
	[SerializeField]
	private SO_GenericEvent _Player1DeathEvent;
	[SerializeField]
	private SO_GenericEvent _Player2DeathEvent;
	[SerializeField]
	private SO_GenericEvent _GameTimerOverEvent;
	[SerializeField]
	private SO_MatchState _MatchState;
	[SerializeField]
	private SO_Tag _MainMenuScreenTag;
	[SerializeField]
	private SO_Tag _InGameScreenTag;

	[Header("UI Elements")]
	[SerializeField]
	private Text _GameResultText;

	public override void Initialize()
	{
		_Player1DeathEvent.AddListenerToEvent(OnPlayer1Death);
		_Player2DeathEvent.AddListenerToEvent(OnPlayer2Death);
		_GameTimerOverEvent.AddListenerToEvent(OnGameTimerOver);
	}

	private void OnDestroy()
	{
		_Player1DeathEvent.RemoveListenerToEvent(OnPlayer1Death);
		_Player2DeathEvent.RemoveListenerToEvent(OnPlayer2Death);
		_GameTimerOverEvent.RemoveListenerToEvent(OnGameTimerOver);
	}

	private void OnPlayer1Death(object data)
	{
		if (!_MatchState.MatchOver)
		{
			_GameResultText.text = "Player 2 Wins";
			_MatchState.Player2Score++;
			_MatchState.MatchOver = true;
		}
	}

	private void OnPlayer2Death(object data)
	{
		if (!_MatchState.MatchOver)
		{
			_GameResultText.text = "Player 1 Wins";
			_MatchState.Player1Score++;
			_MatchState.MatchOver = true;
		}
	}

	private void OnGameTimerOver(object data)
	{
		_GameResultText.text = "It's a Draw";
		_MatchState.MatchOver = true;
	}

	public void OnSelectRetry()
	{
		_UIManager.SetScreen(_InGameScreenTag);
		SceneManager.LoadScene("Level");
	}

	public void OnSelectMainMenu()
	{
		_UIManager.SetScreen(_MainMenuScreenTag);
		SceneManager.LoadScene("MainMenu");
	}
}
