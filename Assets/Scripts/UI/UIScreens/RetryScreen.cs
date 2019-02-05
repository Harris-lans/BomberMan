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
	private SO_GenericEvent _GameTimerOver;
	[SerializeField]
	private SO_MatchState _MatchState;
	[SerializeField]
	private SO_Tag _MainMenuScreenTag;
	[SerializeField]
	private SO_Tag _InGameScreenTag;

	[Header("UI Elements")]
	[SerializeField]
	private Text _GameResultText;

	private void OnEnable()
	{
		_Player1DeathEvent.AddListenerToEvent(OnPlayer1Death);
		_Player2DeathEvent.AddListenerToEvent(OnPlayer2Death);
		_GameTimerOver.AddListenerToEvent(OnGameTimerOver);
	}

	private void OnDisable()
	{
		_Player1DeathEvent.RemoveListenerToEvent(OnPlayer1Death);
		_Player2DeathEvent.RemoveListenerToEvent(OnPlayer2Death);
		_GameTimerOver.RemoveListenerToEvent(OnGameTimerOver);
	}

	private void OnPlayer1Death(object data)
	{
		_GameResultText.text = "Player 2 Wins";
		_MatchState.Player2Score++;
	}

	private void OnPlayer2Death(object data)
	{
		_GameResultText.text = "Player 1 Wins";
		_MatchState.Player1Score++;
	}

	private void OnGameTimerOver(object data)
	{
		_GameResultText.text = "It's a Draw";
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
