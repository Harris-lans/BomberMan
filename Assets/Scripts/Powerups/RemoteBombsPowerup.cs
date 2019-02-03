using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBombsPowerup : Powerup 
{
    [SerializeField]
    private ABomb _RemoteBombPrefab;

    public override void Activate()
    {
        base.Activate();
        SO_BombAttackStats bombAttackStats = _Owner.GetComponent<PlayerController>().PlayerData.BombAttackStats;
        bombAttackStats.BombPrefab = _RemoteBombPrefab;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        SO_BombAttackStats bombAttackStats = _Owner.GetComponent<PlayerController>().PlayerData.BombAttackStats;
        bombAttackStats.ResetBomb();
    } 
}
