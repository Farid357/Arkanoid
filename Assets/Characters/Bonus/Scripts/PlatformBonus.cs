using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

[RequireComponent(typeof(BoxCollider2D))]
public sealed class PlatformBonus : Bonus
{
    private GameObject _additionPlatform;
    private WaitForSeconds _wait;

    private void OnEnable()
    {
        _wait = new WaitForSeconds(WaitTime);
    }
    public void SetPlatform(GameObject platform) => _additionPlatform = platform;

    protected override void Apply()
    {
        Enable();
    }
    private async void Enable()
    {
        _additionPlatform.SetActive(true);
        await Task.Delay((int)(WaitTime * 1000f));
        _additionPlatform.SetActive(false);
    }

}
