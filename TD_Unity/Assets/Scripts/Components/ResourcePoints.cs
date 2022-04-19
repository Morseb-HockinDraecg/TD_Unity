using UnityEngine;
using UnityEngine.Events;


// Can be hp, mana, energie ...
// can varies from 0 to _maxResoursePoints
public class ResourcePoints : MonoBehaviour
{
    [SerializeField]    protected double _maxResoursePoints;
    private double _currentResourcePoint;
    public UnityEvent ResourcePointReachZero;

    private void Start(){
        _currentResourcePoint = _maxResoursePoints;
    }

    public void Increase(double amount){
        if (amount + _currentResourcePoint > _maxResoursePoints)
            _currentResourcePoint = _maxResoursePoints;
        else
            _currentResourcePoint += amount;
    }

    public void Decrease(double amount){
        if (amount > _currentResourcePoint)
            _currentResourcePoint = 0;
        else
            _currentResourcePoint -= amount;
        
        if (_currentResourcePoint < 0)
            ResourcePointReachZero.Invoke();
    }

    public void IncreaseMax(double amount){
        _maxResoursePoints += amount;
    }

    public void DecreaseMax(double amount){
        if (amount < _maxResoursePoints)
            _maxResoursePoints -= amount;
        else
            _maxResoursePoints = 0;
    }
}
