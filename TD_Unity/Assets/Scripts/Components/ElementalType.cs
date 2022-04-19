using UnityEngine;

public class ElementalType : MonoBehaviour
{
    [HideInInspector] 
    public enum eType{
        E_None,
        E_Fire,
        E_Cold,
        E_Poison,
    };

    [SerializeField]
    private eType _elemType;

    private void Awake(){
        _elemType = eType.E_None;
    }

    public void setElementalType(eType elemType){
        _elemType = elemType;
    }

    public eType getElementalType(){
        // switch = tmp to display in debug log 
        // to delete when all set
        switch (_elemType){
            case eType.E_None:
                Debug.Log("normal");
                break;
            case eType.E_Fire:
                Debug.Log("fire");
                break;
            case eType.E_Cold:
                Debug.Log("cold");
                break;
            case eType.E_Poison:
                Debug.Log("poison");
                break;
            default:
                return _elemType;
        }
        // true return
        return _elemType;
    }

}