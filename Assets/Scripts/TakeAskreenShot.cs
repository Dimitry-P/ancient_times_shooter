using System.Collections;
using System.Collections.Generic;

using UnityEditor;
using UnityEngine;

public class TakeAskreenShot : MonoBehaviour
{
    [SerializeField] Camera _camera;
    string[] path = { @"D:\", "unity", "Unity_proj", "SF", "ancient_times_shooter", "Assets", "Images", "Sprites", "asd.png" };

    // Start is called before the first frame update
    void Start()
    {
        string pathCombined = System.IO.Path.Combine(path);
        TakeScreenShot(pathCombined);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void TakeScreenShot(string fullPath)
    {
        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
        }
        RenderTexture rt = new RenderTexture(128, 128, 24); //128*128
        _camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(128, 128, TextureFormat.RGBA32, false);
        _camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, 128, 128), 0, 0);
        _camera.targetTexture = null;
        RenderTexture.active = null;
        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }
        byte[] data = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes(fullPath, data);
#if UNITY_EDITOR
        AssetDatabase.Refresh();
#endif
    }
}