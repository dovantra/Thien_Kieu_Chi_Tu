using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gau : MonoBehaviour
{
    public Rigidbody2D rig;
    public float TocDoChay = 3;
    public float TocDo;
    public Animator ani;
    public BoxCollider2D box;
    public Slider health;
    public int hp= 20;
    public int huong = -1;
    public bool cham=false;

    public Transform viTriATK;
    public GameObject atk;
    void Start()
    {

        if (transform.localPosition.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);

        }

        TocDo = transform.localScale.x * TocDoChay * huong * Time.deltaTime;
        
        health.maxValue = hp;
        health.value = hp;
    }

    
    void Update()
    {
        rig.velocity = new Vector2(TocDo, 0f);
        if (health.value <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dan_Hoa_Cai"))
        {
            health.value = health.value - 3;
        } 
        
        if (collision.gameObject.CompareTag("DEF"))
        {
            TocDo = 0;
            StartCoroutine(ATK());
        }

        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DEF"))
        {
            StopCoroutine(ATK());
            ani.SetTrigger("run");
            TocDo = transform.localScale.x * TocDoChay * huong * Time.deltaTime;
            
        }
    }

    void TanCong()
    {
        if (box.IsTouchingLayers(LayerMask.GetMask("DEF")))
        {
            TocDoChay = 0;
            cham = true;
            StartCoroutine(ATK());
    
            return;
        }
        else if (!box.IsTouchingLayers(LayerMask.GetMask("DEF")))
        {
            cham= false;
            StopCoroutine(ATK());
            ani.SetTrigger("run");
            return;
        }
    }

    IEnumerator ATK()
    {
        ani.SetTrigger("atk");
        yield return new WaitForSeconds(0.4f);
        Instantiate(atk, viTriATK.position, transform.rotation);
        yield return new WaitForSeconds(1);
        StartCoroutine(ATK());
    }


}
