using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeviceCamera : MonoBehaviour
{
    private bool camAvaliable;
    private WebCamTexture backcam;
    private Texture defaultBackground;

    public RawImage background;
    public AspectRatioFitter fit;

    private void Start()
    {
        StartCameraMode();
    }

    void StartCameraMode()
    {
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;

        if(devices.Length == 0)
        {
            Debug.Log("No camera detected");
            camAvaliable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            if(!devices[i].isFrontFacing)
            {
                backcam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if(backcam == null)
        {
            Debug.Log("Unable to find back camera");
            return;
        }

        backcam.Play();
        background.texture = backcam;

        camAvaliable = true;
    }

    private void Update()
    {
        if (!camAvaliable)
            return;

        float ratio = (float)backcam.width / (float)backcam.height;
        fit.aspectRatio = ratio;

        float scaleY = backcam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -backcam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
}
