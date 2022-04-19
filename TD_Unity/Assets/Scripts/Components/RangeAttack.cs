using UnityEngine;

public class RangeAttack : Attack{
    [SerializeField]    protected GameObject _bulletPrefab;
    [SerializeField]    protected Transform _firepoint;
    protected float _range;

    public void Shoot(Transform target){
        if (target == null)
            return;

        GameObject bulletGO = (GameObject)Instantiate(_bulletPrefab, _firepoint.position, _firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
            bullet.Seek(target);
    }
}
