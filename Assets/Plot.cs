using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    

    private GameObject tower;
    private Color starColor;

    private void Start()
    {
        starColor = sr.color;
    }
    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sr.color = starColor;   
    }
    private void OnMouseDown()
    {   
        
        if(tower != null)
        {
            return;
        }
    Tower  towertoBuild= BuildManager.main.GetSelectedTower();
      

        if (towertoBuild.cost > LeverManager.main.currency)
        {
            //  note 1: sau sẽ gọi ra 1 cái dòng chữ nhỏ ở góc rằng : bạn không đủ tiền.
            Debug.Log("ko du tien");
            return;
        }
 
      tower =  Instantiate(towertoBuild.prefab,transform.position,Quaternion.identity);
       
    }


}
