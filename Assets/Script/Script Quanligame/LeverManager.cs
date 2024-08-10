using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public static LeverManager main;

  //  public Transform StartPoint;
    public Transform[] StartPoint; //sau lafm casc diem radom quai

    public int currency; // tiền

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        currency = 100;
    }

    public void InCreasecurrency( int amount)   // hàm tăng tiền .
    {
         
       currency += amount;
    }    
    public bool SpendCurrency( int amount )          // mua tháp
    {

        if (amount <= currency)
        {
            //buyitem   
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("Ko đủ tiền để mua item");
            return false;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
