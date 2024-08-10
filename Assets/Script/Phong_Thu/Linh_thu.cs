using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linh_thu : MonoBehaviour
{
    [SerializeField] Animator anim;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        StartCoroutine(SpawnLinhLuc()); 
    }
    private void Update()
    {
        
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
}
