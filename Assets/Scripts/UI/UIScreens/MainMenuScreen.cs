using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : UIScreen 
{
	[SerializeField]
	private SO_Tag _InGameScreenTag;
	[SerializeField]
	private string _LevelSceneName;
	[SerializeField]
	private SO_MatchState _MatchState;

	public void OnClickPlay()
	{
		_MatchState.ResetMatchStats();
		_UIManager.SetScreen(_InGameScreenTag);
		SceneManager.LoadScene(_LevelSceneName);
	}

}
