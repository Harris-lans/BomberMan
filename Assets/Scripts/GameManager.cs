using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	[SerializeField]
	private SO_MatchState _MatchState;
	[SerializeField]
	private SO_PlayerData[] _PlayerDatas;
	[SerializeField]
	private PlayerController _PlayerPrefab;
	[SerializeField]
	private Transform[] _PlayerSpawns;
	[SerializeField]
	private SO_Tag _GameOverScreen;
	[SerializeField]
	private SO_GenericEvent _GameTimerOverEvent;

	private UIManager _UIManager;

	private void Start()
	{
		SpawnPlayers();
		_UIManager = UIManager.Instance; 
		Powerup.SpawnedPowerups = new List<Powerup>();
	}

	private void OnEnable() 
	{
		// Subscribing to global events
		foreach (var playerData in _PlayerDatas)
		{
			playerData.PlayerDeathEvent.AddListenerToEvent(OnMatchOver);
		}
		_GameTimerOverEvent.AddListenerToEvent(OnMatchOver);
	}

	private void OnDisable()
	{
		// Unsubcscribing from global events
		foreach (var playerData in _PlayerDatas)
		{
			playerData.PlayerDeathEvent.RemoveListenerToEvent(OnMatchOver);
		}
		_GameTimerOverEvent.RemoveListenerToEvent(OnMatchOver);
	}

	private void SpawnPlayers()
	{
		List<Transform> chosenSpawnPoints = new List<Transform>();	

		for (int i = 0; i < _PlayerDatas.Length; ++i)
		{
			while (chosenSpawnPoints.Count < _PlayerDatas.Length)
			{
				int chosenSpawnPointIndex = Random.Range(0, _PlayerSpawns.Length);
				Transform chosenSpawnPoint = _PlayerSpawns[chosenSpawnPointIndex];
				if (!chosenSpawnPoints.Contains(chosenSpawnPoint))
				{
					chosenSpawnPoints.Add(chosenSpawnPoint);
					PlayerController playerController = Instantiate(_PlayerPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
					playerController.Initialize(_PlayerDatas[i]);
					break;
				}
			} 
		}
	}

	private void OnMatchOver(object data)
	{
		_MatchState.ResetMatchTimer();
		_UIManager.SetScreen(_GameOverScreen);
		SceneManager.LoadScene("MainMenu");
	}
}
