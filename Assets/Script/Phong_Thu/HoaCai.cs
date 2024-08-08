using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HoaCai : MonoBehaviour
{
    [SerializeField] Animator ani;
    [SerializeField] Transform viTriDan;
    [SerializeField] GameObject Dan;

    [SerializeField] int huong;

    [SerializeField] bool dangBan = false;

    private bool phamVi;
    public float detectionRange = 10f;
    void Start()
    {
        phamVi = false;
    }
    private void Awake()
    {
        
        if (transform.position.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);           
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);           
        }

    }

    void Update()
    {
        #region
        //  if (hit.collider.CompareTag("ATK"))
        //  {
        //          if (dangBan)
        //          {
        //              StartCoroutine(BanDan());
        //          }
        //      Debug.Log("Raycast trúng: " + hit.collider.name);
        //  }
        //  
        //  
        //  
        //  if (!hit.collider.CompareTag("ATK")) 
        //  {
        //      ban = false;
        //      dangBan = false;
        //      ani.SetTrigger("idie");
        //      
        //  }
        #endregion

        if (phamVi)
        {
            if(dangBan == false)
            {
                StartCoroutine(BanDan());
            }           
        }
    }
       

    #region
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("ATK"))
       {
           phamVi = true;
           //StartCoroutine(BanDan());
       }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            phamVi = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            phamVi = false;
            ani.SetTrigger("idie");
        }       
    }
    #endregion
    IEnumerator BanDan()
    {
        if (phamVi)
        {
            dangBan = true;
            ani.SetTrigger("atk");

            yield return new WaitForSeconds(0.5f);
            Instantiate(Dan, viTriDan.position, transform.rotation);

            yield return new WaitForSeconds(0.5f);
            dangBan = false;
        }                
    }
}
