using UnityEngine;

public class ExclusiveFullscreenMode : MonoBehaviour
{
    void Start() => Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.ExclusiveFullScreen);
}