using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }

    [SerializeField]
    private Image healthBarImage;

    [SerializeField]
    private Text depthChargeText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateHealthBar(float health)
    {
        healthBarImage.fillAmount = health / 100;
    }

    public void UpdateDepthChargeText(int depthChargeStock, int depthChargeMaxCapacity)
    {
        depthChargeText.text = depthChargeStock + "/" + depthChargeMaxCapacity; 
    }
}
