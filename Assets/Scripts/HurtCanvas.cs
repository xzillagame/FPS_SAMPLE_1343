using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtCanvas : MonoBehaviour
{

    [SerializeField] Image HurtImage;
    [SerializeField] private float ColorChangeRate;
    [SerializeField] private float HurtColorAlpha;


    private void Update()
    {
        Color curColor = HurtImage.color;
        curColor.a = curColor.a > 0f ? curColor.a - ColorChangeRate * Time.deltaTime : 0f;
        HurtImage.color = curColor;

    }


    [ContextMenu("Hurt Screen")]
    public void BeginHurtRedScreen()
    {
        Color tempColor = HurtImage.color;

        tempColor.a = (HurtColorAlpha / 255f);

        HurtImage.color = tempColor;
    }




}
