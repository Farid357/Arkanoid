using UnityEngine;

public sealed class GameState : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }        
}