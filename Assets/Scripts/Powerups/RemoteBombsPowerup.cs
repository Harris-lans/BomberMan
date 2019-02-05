using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBombsPowerup : Powerup 
{
    [SerializeField]
    private ABomb _RemoteBombPrefab;

    private BombAttack _BombAttack;

    public override void Initialize(PowerupManager owner)
    {
        base.Initialize(owner);
        _BombAttack = _Owner.GetComponent<BombAttack>();
    }

    public override void Activate()
    {
        base.Activate();
        SO_BombAttackStats bombAttackStats = _PlayerController.PlayerData.BombAttackStats;
        bombAttackStats.BombPrefab = _RemoteBombPrefab;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        SO_BombAttackStats bombAttackStats = _PlayerController.PlayerData.BombAttackStats;
        bombAttackStats.ResetBomb();
    } 

    private void Update()
    {
        if (_PlayerController != null && Input.GetKeyDown(_PlayerController.PlayerData.FireKey))
        {
            _BombAttack.CanFireBomb = !_BombAttack.CanFireBomb;
        }
    }
}
