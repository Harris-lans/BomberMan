using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombAttack : MonoBehaviour, Attack 
{
    #region Member Variables

        [SerializeField]
        private SO_Tag _AttackTag;

        private SO_BombAttackStats _BombAttackStats;
        [HideInInspector]
        public UnityEvent BombFiredEvent;
        [HideInInspector]
        public bool CanFireBomb;

    #endregion
    
    #region Life Cycle

        private void Start()
        {
            BombFiredEvent = new UnityEvent();
            CanFireBomb = true;
            var playerController = GetComponent<PlayerController>();
            _BombAttackStats = playerController.PlayerData.BombAttackStats;
            _BombAttackStats.Initialize();
        }

        private void OnTriggerEnter(Collider collider)
        {
            Pickup pickup = collider.GetComponent<Pickup>();
            
            if (pickup != null && pickup.PickupTag == _AttackTag)
            {
                _BombAttackStats.Ammo += pickup.Collect();
            }
        }

    #endregion

    #region Member Functions

        public void Fire()
        {
            if (_BombAttackStats.Ammo > 0 && CanFireBomb)
            {
                ABomb bomb = Instantiate(_BombAttackStats.BombPrefab, transform.position, Quaternion.identity);
                bomb.Initialize(this, _BombAttackStats);
                --_BombAttackStats.Ammo;
            }
            BombFiredEvent.Invoke();
        }

    #endregion

    #region Properties

        public int Ammo
        {
            get
            {
                return _BombAttackStats.Ammo;
            }
        }

    #endregion
}
