using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public sealed class GameCleaner : MonoBehaviour
{

    private void Start()
    {
        SetClear(true);
        try
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            Destroy(FindObjectOfType<BallMovement>().gameObject);
        }
        catch (NullReferenceException) {}
    }

    public void Clear()
    {
        SetClear(false);
    }
    private void SetClear(bool clear)
    {
        var blocks = FindObjectsOfType<Block>();
        var bonuses = FindObjectsOfType<Bonus>();
        foreach (var block in blocks)
        {
            block.gameObject.SetActive(clear);
        }
        foreach (var bonus in bonuses)
        {
            bonus.gameObject.SetActive(clear);
        }
    }
}
