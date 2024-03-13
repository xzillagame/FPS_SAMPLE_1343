using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] TMP_Text currentAmmoText;
    [SerializeField] TMP_Text maxAmmoText;

    FPSController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPSController>();
        player.onDamaged.AddListener(DisplayUpdatedHealth);
        //player.onDamaged += DisplayUpdatedHealth;
    }

    #region Health Update
    public void DisplayUpdatedHealth()
    {
        healthBar.fillAmount = healthBar.fillAmount > 0f? healthBar.fillAmount - .1f : 0f;
    }

    #endregion

    #region Ammo Update
    public void DisplayCurrentAmmo(int curAmmo)
    {
        currentAmmoText.text = curAmmo.ToString();
    }

    public void DisplayMaxAmmo(int maxAmmo)
    {
        maxAmmoText.text = maxAmmo.ToString();
    }
    #endregion


    private void OnDisable()
    {
        player.onDamaged.RemoveListener(DisplayUpdatedHealth);
    }


}
