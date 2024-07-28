using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider health;



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK_Gau"))
        {
            health.value = health.value - 5;
        }
    }
}
