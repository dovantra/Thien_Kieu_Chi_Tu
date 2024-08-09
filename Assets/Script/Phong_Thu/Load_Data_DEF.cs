using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Infor_DEF", menuName = "GameConfiguration/Plant", order = 1)]

public class Load_Data_DEF : ScriptableObject
{
    public List<Plant> plants = new List<Plant>();

    [System.Serializable]
    public class Plant
    {
        public int Id;
        public string NamePlant;
        public int Hp;
        public int Dmg;

        public Plant(int id, string namePlant, int hp, int dmg)
        {
            Id = id;
            NamePlant = namePlant;
            Hp = hp;
            Dmg = dmg;
        }


    }

    public int HP(List<Plant> tt, string plant)
    {
        var tim = tt.FirstOrDefault(s => s.NamePlant == plant);
        return tim.Hp;
    }


    public int DMG(List<Plant> tt, string plant)
    {
        var tim = tt.FirstOrDefault(s => s.NamePlant == plant);
        return tim.Dmg;
    }
}
