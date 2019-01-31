using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

			// Attacks
			if (Input.GetKey(PlayerData.FireKey))
			{
				_Attack.Fire();
			} 
		}

	#endregion 
}
