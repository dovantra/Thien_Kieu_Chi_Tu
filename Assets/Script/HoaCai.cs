using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HoaCai : MonoBehaviour
{
    public Animator ani;
    public BoxCollider2D box;
    public Transform viTriDan;
    public GameObject Dan;
    public int huong;
    public UnityEngine.UI.Slider health;
    public int hp = 15;
    void Start()
    {
        health.maxValue = hp;
        health.value = hp;

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
       
        if (health.value <= 0)
        {
            Destroy(gameObject);
        }
    }
    void TanCong()
    {
        if (box.IsTouchingLayers(LayerMask.GetMask("ATK")))
        {
            
            StartCoroutine(BanDan());
            
            return;
        }
        else if(!box.IsTouchingLayers(LayerMask.GetMask("ATK")))
        {
            
            StopCoroutine(BanDan());
            ani.SetTrigger("idie");
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            StartCoroutine(BanDan());
        }
        if (collision.gameObject.CompareTag("ATK_Gau"))
        {
            health.value = health.value - 5;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ATK"))
        {
            StopCoroutine(BanDan());
            ani.SetTrigger("idie");
        }
    }
    IEnumerator BanDan()
    {
        ani.SetTrigger("atk");
        yield return new WaitForSeconds(0.5f);
        Instantiate(Dan, viTriDan.position, transform.rotation);
        yield return new WaitForSeconds(1);
        StartCoroutine(BanDan());
    }
}
