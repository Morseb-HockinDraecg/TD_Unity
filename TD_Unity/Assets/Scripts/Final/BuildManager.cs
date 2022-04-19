using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake(){
        if (instance != null){
            Debug.LogError("BuildManager already instantiated.");
            return ;
        }
        instance = this;
    }

    public GameObject standardTowerPrefab;

    void Start(){
        towerToBuild = standardTowerPrefab;
    }


    private GameObject towerToBuild;

    public GameObject GetTowerToBuild (){
        return towerToBuild;
    }

}
