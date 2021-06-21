using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadoutObject : MonoBehaviour
{
    public GameObject ammunitionPrefab;
    public float rateOfFire;
    public GameObject appearance;
    public GameObject muzzle;

    public void Fire()
    {
        Instantiate(ammunitionPrefab, muzzle.transform.position, muzzle.transform.rotation);
    }
}
