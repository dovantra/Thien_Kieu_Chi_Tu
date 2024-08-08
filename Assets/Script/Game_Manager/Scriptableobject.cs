using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="phongthu",menuName =("Phongthu/quaivatretien"),order =1)]
public class Quaizat: ScriptableObject
{  
    public int cost;
    public Texture icon;
    public float cooldown;
}
