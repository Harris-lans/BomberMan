using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Attack))]

public class PlayerController : MonoBehaviour 
{
	#region Member Variables

		public SO_PlayerData PlayerData;

		private Mover _Mover;
		private Attack _Attack;

	#endregion

	#region Life Cycle

		private void Start()
		{
			_Mover = GetComponent<Mover>();
			_Attack = GetComponent<Attack>();
		}

		private void Update()
		{
			// Attacks
			if (Input.GetKeyDown(PlayerData.FireKey))
			{
				_Attack.Fire();
			} 

			// Up and down movement of the character
			if (Input.GetKey(PlayerData.UpKey))
			{
				_Mover.MoveUp();
			}
			else if (Input.GetKey(PlayerData.DownKey))
			{
				_Mover.MoveDown();
			}

			// Left and right Movement of the Character
			if (Input.GetKey(PlayerData.LeftKey))
			{
				_Mover.MoveLeft();
			}
			else if (Input.GetKey(PlayerData.RightKey))
			{
				_Mover.MoveRight();
			}
		}

	#endregion 

	#region Member Functions

		public void Initialize(SO_PlayerData playerData)
		{
			PlayerData = playerData;
			Renderer renderer = GetComponentInChildren<Renderer>();
			foreach (var material in renderer.materials)
			{
				material.color = playerData.PlayerColorShade;
				material.SetColor("_EmissionColor", playerData.PlayerColorShade);
			}
		}

	#endregion
}
