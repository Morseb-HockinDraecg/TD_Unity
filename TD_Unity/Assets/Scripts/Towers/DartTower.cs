using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTower : RangeTower{
    private void Awake(){
        // _attack.setDamage(10);
        _range = 3;
        _turnSpeed = 10;
        // _fireCountdown = 0;
        _fireRate = 1;
    }
}
