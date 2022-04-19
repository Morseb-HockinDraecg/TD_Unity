using UnityEngine;

[RequireComponent(typeof(ElementalType))]
public class Attack : MonoBehaviour, IAttackBehavior{
    [SerializeField] protected double _attackDamage;
    [SerializeField] protected ElementalType _damageType;
    // [SerializeField] protected double _range;

    public void setDamage(double damage){
        _attackDamage = damage;
    }

    public void setDamageType(ElementalType elemType){
        _damageType.setElementalType(elemType.getElementalType());
    }

    public void DealDamages(Transform target){
        if (target == null)
            return;
        Debug.Log("Deals " + _attackDamage + " ");
        _damageType.getElementalType();
        if (_attackDamage > 1)
            Debug.Log(" damages.");
        else
            Debug.Log(" damage.");
    }

    public void Missed(Transform target){
        Debug.Log("missed target");
    }

}