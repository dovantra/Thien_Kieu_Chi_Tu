using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_DEF : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider health;
    [SerializeField] GameObject parentGameObject;

    [SerializeField] Load_Data_DEF dtDEF;
    [SerializeField] InFor dtAtk;
    [SerializeField] string ten;
    [SerializeField] int damgeQV;
    [SerializeField] int hp;

    void Start()
    {
        int currentLayer = gameObject.layer;
        string ten = LayerMask.LayerToName(currentLayer);

        hp = dtDEF.HP(dtDEF.plants, ten);
        
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject QuaiVat = collision.gameObject; 
        
        int lQV = QuaiVat.layer;
        string layerQV = LayerMask.LayerToName(lQV);

        damgeQV = dtAtk.DMG(dtAtk.tableObjects, layerQV);
        health.value = health.value - damgeQV;

    }
}
