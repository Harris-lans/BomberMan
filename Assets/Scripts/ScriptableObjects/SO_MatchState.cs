using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MatchState", menuName = "BomberMan/MatchState")]

public class SO_MatchState : ScriptableObject 
{
	public int Player1Score = 0;
	public int Player2Score = 0;
	[Tooltip("In Seconds")]
	public int MaximumMatchTime = 100;
	[HideInInspector]
	public int MatchTime;
	public bool MatchOver;

	public void ResetMatchStats()
	{
		Player1Score = 0;
		Player2Score = 0;
		MatchTime = MaximumMatchTime;
		MatchOver = false;
	}

	public void ResetMatchTimer()
	{
		MatchTime = MaximumMatchTime;
	}
}
