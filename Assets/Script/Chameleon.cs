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

    [SerializeField] Slider health;
    [SerializeField] int hp = 20;

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

        health.maxValue = hp;
        health.value = hp;
    }


    void Update()
    {
        rig.velocity = new Vector2(TocDo, 0f);
        if (health.value <= 0)
        {
            TocDo = 0f;
            ani.SetTrigger("hit");
            Destroy(gameObject,0.3f);
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
            cham = true;
            TocDo = 0;
            StartCoroutine(ATK());
        }
        if (collision.gameObject.CompareTag("Home"))
        {
            Destroy(gameObject);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DEF"))
        {
            //cham = false;
            ani.SetTrigger("run");
            TocDo = transform.localScale.x * TocDoChay * huong * Time.deltaTime;

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
