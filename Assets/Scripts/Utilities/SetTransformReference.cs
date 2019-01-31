using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformReference : MonoBehaviour 
{
	public TransformReference _TransformReference;

	private void Awake() 
	{
		if (_TransformReference != null)
		{
			_TransformReference.Reference = transform;
		}	
	}
}
