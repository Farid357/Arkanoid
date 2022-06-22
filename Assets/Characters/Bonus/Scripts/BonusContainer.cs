using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level bonus", menuName = "GameData/Create level bonuses")]
public sealed class BonusContainer : ScriptableObject
{
    public List<LevelBonuses> LevelBonuses => _bonuses;
    [SerializeField] private List<LevelBonuses> _bonuses = new();
}

[System.Serializable]
public class LevelBonuses
{
    public Bonus BonusPrefab;
    public uint DropChance;
}
