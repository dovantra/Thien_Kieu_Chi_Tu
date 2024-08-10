using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("references")]
    [SerializeField] TextMeshProUGUI currencyUI;

    [SerializeField] Animator anim;
    private bool isMenuOpen = true;
    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;

        anim.SetBool("MenuOpen", isMenuOpen);
    }
    private void OnGUI()
    {
        currencyUI.text=LeverManager.main.currency.ToString();
    }
    public void SETSelected()
    {

    }
}
