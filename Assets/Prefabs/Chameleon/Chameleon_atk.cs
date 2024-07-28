using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon_atk : MonoBehaviour
{
    [SerializeField] Rigidbody2D rig;
    [SerializeField] float TocDoChay = 3;
    [SerializeField] float TocDo;
    [SerializeField] int huong = -1;
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

        //Destroy(gameObject,1);
    }

    
    void Update()
    {
        rig.velocity = new Vector2(TocDo, 0f);
        
    }
}
