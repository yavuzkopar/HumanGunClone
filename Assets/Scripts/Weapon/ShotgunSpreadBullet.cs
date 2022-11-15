using UnityEngine;


public class ShotgunSpreadBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] bool _isGlobal;
    Vector2 _randomDirection;
    private void OnEnable()
    {
        _randomDirection = Random.insideUnitCircle.normalized;
    }
    private void OnDisable()
    {
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }
    void Update()
    {
        if (!_isGlobal)
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        else
            transform.Translate(_speed * Time.deltaTime * _randomDirection);
    }
}

