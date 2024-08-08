using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Load_Data_DEF;

public class Load_DEF : MonoBehaviour
{
    public List<Data_Phong_Thu> list_Data_DEF = new List<Data_Phong_Thu>();
    public Load_Data_DEF data_DEF;
    private void Start()
    {
        LoadTextAset("Quai_DEF");
    }

    public void LoadTextAset(string path)
    {
        TextAsset loadText = Resources.Load<TextAsset>(path);
        string[] lines = loadText.text.Split('\n');

        for (int i = 1; i < lines.Length; i++)
        {
            string[] cols = lines[i].Split('\t');
            Data_Phong_Thu dt = new Data_Phong_Thu();
            dt.id = Convert.ToInt32(cols[0]);
            dt.name = cols[1];
            dt.hp = Convert.ToInt32(cols[2]);
            dt.dmg = Convert.ToInt32(cols[3]);
            list_Data_DEF.Add(dt);

            Plant plant = new Plant(dt.id, dt.name, dt.hp, dt.dmg);
            data_DEF.plants.Add(plant);
        }
    }


}
[System.Serializable]
public class Data_Phong_Thu
{
    public int id;
    public string name;
    public int hp;
    public int dmg;
}
