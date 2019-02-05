using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[Header("Pickup Details")]
	public SO_Tag PickupTag;
	
	[Header("Number of bombs available")]
    [SerializeField]
    private int _AmmoToAdd;

    private bool _PickedUp;

    private void Start()
    {
        _PickedUp = false;
    }

    public int Collect()
    {
        if (!_PickedUp)
        {
            Destroy(gameObject);
            _PickedUp = true;
            return _AmmoToAdd;
        }
        return 0;
    }
}
