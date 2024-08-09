using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_ATK : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider health;
    [SerializeField] GameObject parentGameObject;
    [SerializeField] Load_Data_DEF dtDEF;
    [SerializeField] InFor atk;
    [SerializeField] string ten;
    [SerializeField] int damgeQV;
    [SerializeField] int hp;

    void Start()
    {
        int currentLayer = gameObject.layer;
        string ten = LayerMask.LayerToName(currentLayer);

        hp = atk.HP(atk.tableObjects, ten);
        health.maxValue = hp;
        health.value = hp;
        parentGameObject = transform.parent.gameObject;
    }
    private void Update()
    {
        if (health.value <= 0)
        {
            Destroy(parentGameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject QuaiVat = collision.gameObject;

        int lQV = QuaiVat.layer;
        string layerQV = LayerMask.LayerToName(lQV);

        damgeQV = dtDEF.DMG(dtDEF.plants, layerQV);
        health.value = health.value - damgeQV;
    }
}

