using UnityEngine;

public interface IAttackBehavior{
    public void DealDamages(Transform target);
    public void Missed(Transform target);
}