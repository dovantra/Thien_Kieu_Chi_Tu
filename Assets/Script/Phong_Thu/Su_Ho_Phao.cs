using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Su_Ho_Phao : MonoBehaviour
{
    public Animator AniCanon;
    public Animator Pig;
    public bool phamVi = false;
    public bool dangBan = false;

    public GameObject ball;
    public Transform viTriBall;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    #region 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            phamVi = true;         
        }
        if (phamVi)
        {
            if(!dangBan) 
            StartCoroutine(BanBall());
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
        }
    }
    #endregion

    IEnumerator BanBall()
    {
        do
        {
            dangBan = true;
            AniCanon.SetTrigger("On");
            Pig.SetTrigger("On");
            yield return new WaitForSeconds(0.1f);
            Instantiate(ball, viTriBall.position, transform.rotation);           
            yield return new WaitForSeconds(5f);
            dangBan = false;
        } while (phamVi == true);


    }
}
