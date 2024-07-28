using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chameleon : MonoBehaviour
{

    [SerializeField] Rigidbody2D rig;
    [SerializeField] float TocDoChay = 30;
    [SerializeField] float TocDo;

    [SerializeField] Animator ani;
    [SerializeField] UnityEngine.UI.Slider health;

    [SerializeField] int huong = -1;
    [SerializeField] bool cham = false;

    [SerializeField] Transform viTri;
    [SerializeField] GameObject atk;


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
        rig.velocity = new Vector2(TocDo, 0f);
    }


    void Update()
    {
         
        if (health.value <= 0)
        {
            TocDo = 0;
            ani.SetTrigger("hit");
            Destroy(gameObject,0.3f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("DEF"))
        {
            cham = true;
            rig.velocity = Vector2.zero;
            StartCoroutine(ATK());
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DEF"))
        {
            cham = false;
            ani.SetTrigger("run");
            rig.velocity = new Vector2(TocDo, 0f);
            //TocDo = transform.localScale.x * TocDoChay * huong * Time.deltaTime;

        }
    }


    IEnumerator ATK()
    {
        do
        {
            ani.SetTrigger("atk");
            yield return new WaitForSeconds(0.4f);
            Instantiate(atk, viTri.position, transform.rotation);
            yield return new WaitForSeconds(1);

        } while (cham == true);
    }
}
