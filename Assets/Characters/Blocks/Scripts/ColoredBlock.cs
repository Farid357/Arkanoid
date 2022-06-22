using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ColoredData", menuName = "GameData/CreateColoredBlockData")]
public sealed class ColoredBlock : BlockData
{
    public int Score => _score;
    public List<Sprite> Sprites => _sprites;
    public Color Color => _color;

    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private Color _color;
    [SerializeField, Range(0, 1000)] private int _score;
}
