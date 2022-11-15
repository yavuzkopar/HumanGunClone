using UnityEngine;
using DG.Tweening;

public class DollarUI : MonoBehaviour
{
    Transform _playerTransform;
    Vector3 scaleTarget;
    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        scaleTarget = Vector3.one * 2f;
    }
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        transform.position = Camera.main.WorldToScreenPoint(_playerTransform.position);

        transform.DOScale(scaleTarget, 0.5f).OnComplete(() => Move());
    }
    void Move()
    {
        transform.DOScale(Vector3.one, 0.5f);
        transform.DOMove(GameManager.Instance.DollarTargetPoint.position, 0.5f).OnComplete(
            () => gameObject.SetActive(false));
        GameEconomy.Instance.Money += 50;
        GameEconomy.Instance.DollarUpdate();

    }
}
