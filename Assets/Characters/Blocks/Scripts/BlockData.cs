using UnityEngine;

[CreateAssetMenu(fileName = "BlockData", menuName = "GameData/CreateBlockData")]
public class BlockData : ScriptableObject
{
    public Block Prefab => _prefab;
    
    [SerializeField] private Block _prefab;
}
