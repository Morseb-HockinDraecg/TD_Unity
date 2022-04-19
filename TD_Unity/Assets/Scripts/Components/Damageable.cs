using UnityEngine;

[RequireComponent(typeof(ResourcePoints))]
public class Damageable : MonoBehaviour, IDamageable<int>{
    private ResourcePoints _health;

    private void Awake(){
        _health = GetComponent<ResourcePoints>();
    }

    public void TakeDamage(int damageAmount){
        _health.Decrease(damageAmount);
    }
}