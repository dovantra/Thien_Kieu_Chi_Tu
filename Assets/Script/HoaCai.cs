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
    [SerializeField] bool cham = false;


    void Start()
    {


        if (transform.position.x < 0)
        {
            transform.localScale = new Vector3(1,1,1);
            
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }
    }

    
    void Update()
    {
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            cham = true;
            StartCoroutine(BanDan());
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            cham = false;
            ani.SetTrigger("idie");
        }
        
    }
    IEnumerator BanDan()
    {
        
        while (cham == true) 
        {          
            ani.SetTrigger("atk");
            yield return new WaitForSeconds(0.5f);
            Instantiate(Dan, viTriDan.position, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
