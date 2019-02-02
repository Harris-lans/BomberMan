using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombAttack : MonoBehaviour, Attack 
{
    #region Member Variables

        [SerializeField]
        private int _Ammo = 10; 

        [Header("Bomb Details")]
        [SerializeField]
        private ABomb _BombPrefab;
        public UnityEvent BombFiredEvent; 

    #endregion
    
    #region Member Functions

        private void Start()
        {
            BombFiredEvent = null;
        }

        public void Fire()
        {
            if (_Ammo > 0 && BombFiredEvent == null)
            {
                BombFiredEvent = new UnityEvent();
                ABomb bomb = Instantiate(_BombPrefab, transform.position, Quaternion.identity);
                bomb.Initialize(this);
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
