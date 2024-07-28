using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverManager : MonoBehaviour
{
    public static LeverManager main;

    public Transform StartPoint;
    //public Transform[] path; //sau lafm casc diem radom quai

    private void Awake()
    {
        main = this;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
