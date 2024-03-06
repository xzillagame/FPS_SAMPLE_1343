using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;
    int ammo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(gunBarrelEnd.position, gunBarrelEnd.position + gunBarrelEnd.forward * 100, Color.red);
    }

    public void Fire()
    {
        //Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;
    }
}
