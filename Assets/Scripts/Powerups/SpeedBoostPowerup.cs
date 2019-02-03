using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerup : Powerup
{
    [SerializeField]
    private float _NewMovementSpeed;

    public override void Activate()
    {
        base.Activate();
        SO_MovementStats movementStats = _Owner.GetComponent<PlayerController>().PlayerData.MovementStats;
        movementStats.MovementSpeed = _NewMovementSpeed;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        SO_MovementStats movementStats = _Owner.GetComponent<PlayerController>().PlayerData.MovementStats;
        movementStats.ResetMovementSpeed();
    }
}
