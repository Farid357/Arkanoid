using UnityEngine;
using System.Collections.Generic;

public sealed class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _additionPlatform;
    [SerializeField] private BonusContainer _container;
    [SerializeField] private PlayerHealth _playerHealth;
    private ObjectsPool<Bonus> _pool;

    private List<uint> _bonusChances = new();
    private uint _maxChance;
    private Vector3 _position;

    private void OnEnable()
    {
        _pool = new();
        Block.OnDestroyed += TryGenerate;
    }
    private void OnDisable() => Block.OnDestroyed -= TryGenerate;

    private void TryGenerate(Vector3 position)
    {
        _position = position;
        for (int i = 0; i < _container.LevelBonuses.Count - 1; i++)
        {
            _maxChance += _container.LevelBonuses[i].DropChance;
            _bonusChances.Add(_maxChance);
        }
        _bonusChances.Add(_maxChance * 3);
        TryGetChance();
    }
    private void TryGetChance()
    {
        uint min = 0;
        float chance = Random.Range(0, _bonusChances[_bonusChances.Count - 1]);

        if(chance < _maxChance)
        {
            for (int i = 0; i < _bonusChances.Count - 2; i++)
            {
                if (chance >= min && chance < _bonusChances[i])
                {
                    Generate(_container.LevelBonuses[i].BonusPrefab);
                    break;
                }
                min = _bonusChances[i];
            }
        }
    }
    private void Generate(Bonus bonusPrefab)
    {
        _pool.Add(2, bonusPrefab, _position, Quaternion.identity);
        var bonus = _pool.Get(bonusPrefab);
        bonus.gameObject.SetActive(true);

        if (bonus is PlatformBonus)
        {
            var platformBonus = bonus as PlatformBonus;
            platformBonus.SetPlatform(_additionPlatform);
        }
        if (bonus is RandomBonus)
        {
            var randomBonus = bonus as RandomBonus;
            randomBonus.Init(_playerHealth);
        }
    }
}
