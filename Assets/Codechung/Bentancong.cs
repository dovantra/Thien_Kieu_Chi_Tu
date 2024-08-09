using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BENTANCONG : MonoBehaviour
{
    [SerializeField] Rigidbody2D rig;
    [SerializeField] float TocDoChay = 3;
    [SerializeField] float TocDo;
    [SerializeField] Animator ani;
    [SerializeField] BoxCollider2D box;
    [SerializeField] Slider health;

    [SerializeField] int huong = -1;
    [SerializeField] bool cham = false;

    public Transform viTriATK;
    public GameObject atk;

    public InFor tt;
    public string ten;
    public int damge;
    public int hp;
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

        int currentLayer = gameObject.layer;
        string ten = LayerMask.LayerToName(currentLayer);

        // var tim = tt.tableObjects.FirstOrDefault(i => i.Plant == ten);
        // damge = tim.Dmg;
        // hp = tim.Hp;

        hp = tt.HP(tt.tableObjects, ten);
        damge = tt.DMG(tt.tableObjects, ten);

    }


    void Update()
    {


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
            cham = false;
            StopCoroutine(ATK());
            ani.SetTrigger("run");
            return;
        }
    }

    IEnumerator ATK()
    {
        do
        {
            ani.SetTrigger("atk");
            yield return new WaitForSeconds(0.4f);
            Instantiate(atk, viTriATK.position, transform.rotation);
            yield return new WaitForSeconds(1);

        } while (cham == true);
    }


}
