using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsMover : MonoBehaviour, Mover
{
	#region Member Variables

		[Header("Reference for Movement Direction")]
		[SerializeField]
		private TransformReference _TransformReference;

		private SO_MovementStats _MovementStats;
		private Rigidbody _Rigidbody;
		private Vector3 _CurrentVelocity;

	#endregion

	#region Life Cycle

		private void Start()
		{
			_Rigidbody = GetComponent<Rigidbody>();
			_CurrentVelocity = Vector3.zero;
			var playerController = GetComponent<PlayerController>();
            _MovementStats = playerController.PlayerData.MovementStats;
            _MovementStats.Initialize();
		}

		private void FixedUpdate() 
		{
			_Rigidbody.velocity = _CurrentVelocity * _MovementStats.MovementSpeed;

			// Resetting the velocity for the next fixed update
			_CurrentVelocity = Vector3.zero;
		}

	#endregion

	#region Member Functions

		public void MoveDown()
		{
			_CurrentVelocity += -1 * _TransformReference.Reference.forward.normalized;
		}

		public void MoveLeft()
		{
			_CurrentVelocity += -1 * _TransformReference.Reference.right.normalized;
		}

		public void MoveRight()
		{
			_CurrentVelocity +=  _TransformReference.Reference.right.normalized;
		}

		public void MoveUp()
		{
			_CurrentVelocity += _TransformReference.Reference.forward.normalized;
		}

	#endregion
}
