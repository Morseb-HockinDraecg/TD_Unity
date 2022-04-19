using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    protected GameObject _target;

    // protected GameObject NearestInRange(Tower tower){
        // var targets = FindObjectsOfType<Enemy>();
        // GameObject nearestTarget = null;
        // double shortestDistance = Mathf.Infinity;
        
        // foreach (GameObject target in targets){
        //     double distanceToTarget = Vector3.Distance( tower.transform.position, target.transform.position);
        //     if (distanceToTarget < shortestDistance){
        //         shortestDistance = distanceToTarget;
        //         nearestTarget = target;
        //     }
        // }



        // _target = nearestTarget;

        // if (nearestTarget != null && shortestDistance <= range){
        //     _target = nearestTarget.transform;
        // } else {
        //     _target = null;
        // }

        // return nearestTarget;
    // }
}
