using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadiusPowerup : APowerup 
{
    [SerializeField]
    private float _NewExplosionRadius;

    public override void Activate()
    {
        base.Activate();
        SO_BombAttackStats bombAttackStats = _Owner.GetComponent<PlayerController>().PlayerData.BombAttackStats;
        bombAttackStats.ExplosionRadius = _NewExplosionRadius;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        SO_BombAttackStats bombAttackStats = _Owner.GetComponent<PlayerController>().PlayerData.BombAttackStats;
        bombAttackStats.ResetExplosionRadius();
    } 
}
