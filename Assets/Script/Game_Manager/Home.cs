using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using static InFor;


public class Home : MonoBehaviour
{
    public List<ThongTin> listTT = new List<ThongTin>();    
    public InFor in4;
    private void Start()
    {
        LoadTextAset("Quai_ATK");
    }

    public void LoadTextAset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');  

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');
            ThongTin tt = new ThongTin();
            tt.id = Convert.ToInt32(cols[0]);
            tt.plant = cols[1];
            tt.hp = Convert.ToInt32(cols[2]);
            tt.dmg = Convert.ToInt32(cols[3]);
            listTT.Add(tt);  
            
            TableObject list = new TableObject(tt.id, tt.plant, tt.hp, tt.dmg);
            in4.tableObjects.Add(list);
        }
    }
    

}
[System.Serializable]
public class ThongTin
{
    public int id;
    public string plant;
    public int hp;
    public int dmg;
}






