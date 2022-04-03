using UnityEngine;

public class DirtNode : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject tower;
    private Renderer rend;
    private Color startColor;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseDown(){
        if (tower != null){
            Debug.Log("Can't build here. TO DO : Display to user");
            return;
        }
        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        tower = (GameObject) Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);
    }

    void OnMouseEnter(){
        rend.material.color = hoverColor;
    }

    void OnMouseExit(){
        rend.material.color = startColor;
    }



}
