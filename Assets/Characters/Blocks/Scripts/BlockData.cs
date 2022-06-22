using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "GameData/CreateBlockData")]
public class BlockData : ScriptableObject
{
    public Block Prefub => _prefub;
    [SerializeField] private Block _prefub;
}
