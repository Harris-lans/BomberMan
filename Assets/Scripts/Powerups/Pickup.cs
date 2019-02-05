using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	[Header("Pickup Details")]
	public SO_Tag PickupTag;
	
	[Header("Number of bombs available")]
    [SerializeField]
    private int _AmmoToAdd = 3;

    public int Collect()
    {
        Destroy(gameObject);
        return _AmmoToAdd;
    }
}
