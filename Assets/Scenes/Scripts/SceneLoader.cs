using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public sealed class SceneLoader : MonoBehaviour
{

    [SerializeField] private LoadMode _loadMode;
    [SerializeField] private ScreenFade _screen;

    public void Load(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }
    private IEnumerator LoadScene(int sceneIndex)
    {
        if (_loadMode == LoadMode.Simple)
        {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
        if (_loadMode == LoadMode.Fade)
        {
            _screen.StartFade();
            while (!_screen.IsDarkened)
            {
                yield return null;
            }
            yield return new WaitForSeconds(1.2f);
            SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
            _screen.StartFadeOut();
        }
        if (_loadMode == LoadMode.WithLoaderScreen)
        {
            AsyncOperation loaderSceneOperation = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            while (!loaderSceneOperation.isDone)
            {
                yield return null;
            }
            StartCoroutine(LoadAsync(sceneIndex));
        }
    }
    private IEnumerator LoadAsync(int sceneIndex)
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
    }
    private void LoadFade(int sceneIndex)
    {
        if (_screen.IsDarkened)
        {
            StartCoroutine(LoadAsync(sceneIndex));
            _screen.StartFadeOut();
        }
    }
}
public enum LoadMode
{
    Simple,
    Fade,
    WithLoaderScreen
}