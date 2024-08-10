using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_thu : MonoBehaviour
{
    [SerializeField] Animator anim;
    public float detectionRange = 10f;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        StartCoroutine(SpawnLinhLuc()); 
    }
    
    private IEnumerator SpawnLinhLuc()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            anim.SetTrigger("Spawn");
            yield return new WaitForSeconds(1f);
            anim.SetTrigger("Idle");
        }
    }
    private void Tang_Linh_Luc()
    {
        //Tang_Linh_Luc += detectionRange;
    }
}
