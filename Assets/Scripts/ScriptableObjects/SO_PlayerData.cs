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

	[Header("Player Identification")]
	public Color PlayerColorShade = Color.blue;
}
