using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Addprefab : MonoBehaviour
{
    [Header("Goi scriptable Object")]
    public Quaizat[] gg;
    public int socard;
    public GameObject prefab;   // khai bao prefab
    public Transform Transform1;

    [Header("Thong so rieng trong code")]
    public GameObject[] card1;// phải gọi mảng chứa card
    public int cost;
    public Texture icon;
    public float cooldown;

    private void Start()
    {

        card1 = new GameObject[socard];

           for(int i = 0; i < socard; i++)
        {
            Addcard(i);
        }        
    }
    private void Update()
    {  



 
    }
    public void Addcard(int index)
    {
        GameObject card = Instantiate(prefab, Transform1); // đẻ ra thẻ
        card1[index]= card;
        
        cost = gg[index].cost;
        icon= gg[index].icon;
        cooldown= gg[index].cooldown;   


        card.GetComponentInChildren<RawImage>().texture= icon;
        card.GetComponentInChildren<TMP_Text>().text = "" + cost;



         
    
    
    
    
    
    
    
    }

       
}
