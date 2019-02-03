using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombAttack : MonoBehaviour, Attack 
{
    #region Member Variables

        [SerializeField]
        private SO_Tag _AttackTag;

        [SerializeField]
        private int _Ammo = 10; 

        private SO_BombAttackStats _BombAttackStats;
        [HideInInspector]
        public UnityEvent BombFiredEvent; 

    #endregion
    
    #region Life Cycle

        private void Start()
        {
            BombFiredEvent = null;
            var playerController = GetComponent<PlayerController>();
            _BombAttackStats = playerController.PlayerData.BombAttackStats;
            _BombAttackStats.Initialize();
        }

        private void OnTriggerEnter(Collider collider)
        {
            Pickup pickup = collider.GetComponent<Pickup>();
            
            if (pickup != null && pickup.PickupTag == _AttackTag)
            {
                _Ammo += pickup.Collect();
            }
        }

    #endregion

    #region Member Functions

        public void Fire()
        {
            if (_Ammo > 0 && BombFiredEvent == null)
            {
                BombFiredEvent = new UnityEvent();
                ABomb bomb = Instantiate(_BombAttackStats.BombPrefab, transform.position, Quaternion.identity);
                bomb.Initialize(this, _BombAttackStats);
                --_Ammo;
            }
            else
            {
                BombFiredEvent.Invoke();
                BombFiredEvent = null; 
            }
        }

    #endregion

    #region Properties

        public int Ammo
        {
            get
            {
                return _Ammo;
            }
        }

    #endregion
}
