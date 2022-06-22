using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EditorData", menuName = "Editor Data/Create Editor Block Data")]
public sealed class EditorData : ScriptableObject
{
    public List<EditorBlockData> BlockDatas => _blockDatas;
    [SerializeField] private List<EditorBlockData> _blockDatas = new();
}

[System.Serializable]
public class EditorBlockData
{
    public Texture2D Texture2D;
    public BlockData BlockData;
}
