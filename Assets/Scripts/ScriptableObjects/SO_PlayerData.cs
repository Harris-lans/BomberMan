using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "BomberMan/PlayerData")]

public class SO_PlayerData : ScriptableObject
{
	[Header("Key Bindings")]
	public KeyCode UpKey = KeyCode.W;
	public KeyCode DownKey = KeyCode.S;
	public KeyCode RightKey = KeyCode.D;
	public KeyCode LeftKey = KeyCode.A;
	public KeyCode FireKey = KeyCode.Space;

	[Header("Player Identification")]
	public Color PlayerColorShade = Color.blue;

	[Header("Global Events")]
	public SO_GenericEvent PowerupActivatedEvent;
	public SO_GenericEvent PowerupDeactivatedEvent;

	[Header("Stats")]
	public SO_BombAttackStats BombAttackStats;
	public SO_MovementStats MovementStats;
}
