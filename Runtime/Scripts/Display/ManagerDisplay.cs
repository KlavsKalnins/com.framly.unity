using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDisplay : MonoBehaviour
{
    [System.Serializable]
    public struct DisplayScreen
    {
        public string name;
        public Camera camera;
        public Canvas canvas;
        public Vector2 resolution;
    }

    public DisplayScreen[] displays;

    void Start()
    {
        StartCoroutine(SetupDisplaysCouroutine());
    }
    public void SetupDisplays()
    {
        StartCoroutine(SetupDisplaysCouroutine());
    }

    // should remake this more scructured
    private IEnumerator SetupDisplaysCouroutine()
    {
        while (Display.displays.Length < displays.Length - 1)
        {
            Debug.Log($"Waiting for display setup");
            yield return new WaitForSeconds(2f);
        }

        for (int i = 0; i < Display.displays.Length; i++)
        {
            for (int j = 0; j < displays.Length; j++)
            {
                if (Display.displays[i].systemHeight == displays[j].resolution.y)
                {
                    if (i != 0)
                        Display.displays[i].Activate();

                    displays[j].camera.targetDisplay = i;
                    if (displays[j].canvas != null)
                    {
                        displays[j].canvas.targetDisplay = i;
                    }

                    displays[j].camera.stereoTargetEye = StereoTargetEyeMask.None;
                    yield return new WaitForSeconds(2);
                    if (i != 0)
                        displays[j].camera.gameObject.SetActive(true);
                }
            }
        }
    }
}