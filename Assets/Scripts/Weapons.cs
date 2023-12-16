using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

	//Basic Weapon Script for making Weapons
	//contains common information which almost all weapon need

	public float ammo;
	public float damage;
	public float range;
	public float reloadTime;
	public float timeBetweenShooting;

	public bool collected;
	public bool isEquiped;
	public bool readyToShoot;


}
