using System;
using System.Collections;
using UnityEngine;

public sealed class BulletsGenerator : MonoBehaviour
{

    [SerializeField, Range(2, 30)] private int _count = 10;
    [SerializeField] private BulletMovement _bulletPrefab;
    [SerializeField] private float _waitTime = 0.4f;
    private ObjectsPool<BulletMovement> _pool = new();
    private WaitForSeconds _wait;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(_waitTime);
        BulletBonus.OnGot += StartGenerate;
    }
    private void OnDisable()
    {
        BulletBonus.OnGot -= StartGenerate;
    }
    private void StartGenerate()
    {
        _pool.Add(_count, _bulletPrefab, transform.position, Quaternion.identity, transform.parent);
        StartCoroutine(Generate());      
    }
    private IEnumerator Generate()
    {
        for (int i = 0; i < _count; i++)
        {
            var bullet = _pool.Get(_bulletPrefab);
            bullet.transform.SetParent(transform.parent, true);
            bullet.gameObject.SetActive(true);
            yield return _wait;
        }
    }
}
