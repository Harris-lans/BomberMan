using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BombAttackStats", menuName = "BomberMan/Stats/AttackStats/BombAttackStats")]
public class SO_BombAttackStats : ScriptableObject 
{
	[Header("Bomb Details")]
	[SerializeField]
	private ABomb _BombPrefab;
	[SerializeField]
	private int _Ammo;

	[Header("Bomb Explosion Details")]
	[SerializeField]
	private float _ExplosionTime = 3;
	[SerializeField]
	private GameObject _ExplosionPrefab;
	[SerializeField]
	private float _ExplosionRadius;
	[SerializeField]
	private Vector3[] _ExplosionDirections;

	[HideInInspector]
	public ABomb BombPrefab;
	[HideInInspector]
	public int Ammo;
	[HideInInspector]
	public float ExplosionTime;
	[HideInInspector]
	public GameObject ExplosionPrefab;
	[HideInInspector] 
	public float ExplosionRadius;
	[HideInInspector]
	public Vector3[] ExplosionDirections;

	public void Initialize()
	{
		BombPrefab = _BombPrefab;
		Ammo = _Ammo;
		ExplosionTime = _ExplosionTime;
		ExplosionPrefab = _ExplosionPrefab;
		ExplosionRadius = _ExplosionRadius;
		ExplosionDirections = _ExplosionDirections;
	}

	public void ResetBomb()
	{
		BombPrefab = _BombPrefab;
	}

	public void ResetAmmo()
	{
		Ammo = _Ammo;
	}

	public void ResetExplosionTime()
	{
		ExplosionTime = _ExplosionTime;
	}

	public void ResetExplosionPrefab()
	{
		ExplosionPrefab = _ExplosionPrefab;	
	}

	public void ResetExplosionRadius()
	{
		ExplosionRadius = _ExplosionRadius;
	}

	public void ResetExplosionDirections()
	{
		ExplosionDirections = _ExplosionDirections;
	}
}
