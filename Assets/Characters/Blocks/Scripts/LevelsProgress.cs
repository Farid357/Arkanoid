using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelsProgress
{
    public List<Progress> Progresses => _progresses;
    [SerializeField] private List<Progress> _progresses = new();
}


[System.Serializable]
public class Progress
{
    public bool IsOpened { get; set; }
    public int StarsCount { get; set; }

}

