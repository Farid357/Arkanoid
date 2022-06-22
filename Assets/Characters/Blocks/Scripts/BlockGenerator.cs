using System.Collections.Generic;
using UnityEngine;

public sealed class BlockGenerator : MonoBehaviour
{
    [SerializeField] private List<ColoredBlock> _blocks = new();

    private void Start()
    {
        for (int i = 0; i < _blocks.Count; i++)
        {
            //var block = Instantiate(_blocks[i].Prefub, new Vector2(0 + i, 0), Quaternion.identity);

            //block.SetData(_blocks[i]);
        }
    }
}
