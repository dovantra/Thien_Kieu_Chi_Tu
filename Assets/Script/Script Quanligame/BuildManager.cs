using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager main;
 
 // public  ScriptableObjectgg [] Tower;

    [Header("Reference")]
  [SerializeField] private Tower[]towers;
    public int SelectedTower ; 
   // [SerializeField] private GameObject[] towerPrefabs;
    private void Awake()
    {
        main = this;           
    }
    public Tower  GetSelectedTower()
    {
        return towers[SelectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        SelectedTower = _selectedTower;
    }
}
