using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementStats", menuName = "BomberMan/Stats/MovementStats")]
public class SO_MovementStats : ScriptableObject 
{	
	[Header("Movement Stats")]
	[SerializeField]
	private float _MovementSpeed;

	[HideInInspector]
	public float MovementSpeed;

	public void Initialize()
	{
		MovementSpeed = _MovementSpeed;
	}

	public void ResetMovementSpeed()
	{
		MovementSpeed = _MovementSpeed;
	}
}
