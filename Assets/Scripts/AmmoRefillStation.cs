using UnityEngine;

public class AmmoRefillStation : MonoBehaviour
{
    private FPSController player;

    //Coded below added by X.E
    [SerializeField] private int ammoToRefill;

    private void OnTriggerEnter(Collider other)
    {
        player = other.gameObject.GetComponent<FPSController>();

        if (player != null)
        {
            Debug.Log("player in");
            player.onInteracted += RefillAmmo;
        }
    }


    private void OnTriggerExit(Collider other)
    { 
        if(other.gameObject == player.gameObject)
        {
            player.onInteracted -= RefillAmmo;
            player = null;
            Debug.Log("player out");
        }
    }


    private void RefillAmmo()
    {
        player.IncreaseAmmo(ammoToRefill);
    }


}
