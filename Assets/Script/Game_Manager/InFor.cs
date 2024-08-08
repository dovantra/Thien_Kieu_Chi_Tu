using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Infor_DEF", menuName = "GameConfiguration/Quai", order = 1)]


public class InFor : ScriptableObject
{

    public List<TableObject> tableObjects = new List<TableObject>();
    [System.Serializable]
    public class TableObject
    {
        public int Id;
        public string Plant;
        public int Hp;
        public int Dmg;

        public TableObject(int id, string plant, int hp, int dmg)
        {
            Id = id;
            Plant = plant;
            Hp = hp;
            Dmg = dmg;
        }


    }

    public int HP(List<TableObject> tt, string plant)
    {
        var tim = tt.FirstOrDefault(s => s.Plant == plant);
        return tim.Hp;
    }


    public int DMG(List<TableObject> tt, string plant)
    {
        var tim = tt.FirstOrDefault(s => s.Plant == plant);
        return tim.Dmg;
    }

}

