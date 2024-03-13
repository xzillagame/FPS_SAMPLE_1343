using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    // references
    [SerializeField] Transform gunBarrelEnd;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Animator anim;

    // stats
    [SerializeField] int maxAmmo;
    [SerializeField] float timeBetweenShots = 0.1f;

    // private variables
    int ammo;
    float elapsed = 0;

    //Events
    public UnityEvent onSuccessfulFire;
    public UnityEvent<int> onCurrentAmmoChanged;
    public UnityEvent<int> onMaxAmmoNeeded;
    

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;

        //Events Added X.E
        onCurrentAmmoChanged?.Invoke(ammo);
        onMaxAmmoNeeded?.Invoke(maxAmmo);

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
    }

    public bool AttemptFire()
    {
        if (ammo <= 0)
        {
            return false;
        }

        if(elapsed < timeBetweenShots)
        {
            return false;
        }

        Debug.Log("Bang");
        Instantiate(bulletPrefab, gunBarrelEnd.transform.position, gunBarrelEnd.rotation);
        anim.SetTrigger("shoot");
        timeBetweenShots = 0;
        ammo -= 1;

        //Event Added X.E
        onCurrentAmmoChanged?.Invoke(ammo);
        onSuccessfulFire?.Invoke();

        return true;
    }

    public void AddAmmo(int amount)
    {
        ammo += amount;

        //Event Added X.E
        onCurrentAmmoChanged?.Invoke(ammo);
    }
}
