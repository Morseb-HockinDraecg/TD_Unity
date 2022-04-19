using UnityEngine;

public class RangeTower : MonoBehaviour {

    [Header("Unity Setup field")]
    [SerializeField]    protected Transform _target;
    // [SerializeField]    protected GameObject _bulletPrefab;
    // [SerializeField]    protected Transform _firepoint;

    [Header("Attributes")]
    [SerializeField]    protected RangeAttack _attack;
    protected float _range;
    protected float _turnSpeed;
    protected float _fireRate;
    // protected Bullet _bullet;
    // protected string _damageType;
    protected double _attackSpeed;
    protected double _fireCountdown;

    protected int _targetNumber;

    private string enemyTag = "Enemy";


    protected virtual void Start(){
        _fireCountdown = 3;
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
    }

    protected virtual void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;
        
        foreach(GameObject enemy in enemies){
            float distanceToEnemy = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance){
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        
        if (nearestEnemy != null && shortestDistance <= _range){
            _target = nearestEnemy.transform;
        } else {
            _target = null;
        }
    }

    void Update(){
        _fireCountdown -= Time.deltaTime;

        if (_target == null)
            return ;

        UpdateRotation();
        Shoot();
    }

    protected void Shoot(){
        if (_fireCountdown <= 0f){
            _fireCountdown = 1f/ _fireRate;
            _attack.Shoot(_target);
            _attack.DealDamages(_target);
        }
    }

    protected void UpdateRotation(){
        Vector3 dir = _target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    protected void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
        if (_target)
            Gizmos.DrawLine(transform.position, _target.position);
    }



}
