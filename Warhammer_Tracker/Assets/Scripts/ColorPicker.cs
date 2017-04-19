using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vexpot.Integration;

public class ColorPicker : MonoBehaviour
{

    private WebCamTexture _texture;
    public VideoCaptureRenderer videoRenderer;
    public ColorTrackerPanel ctp;

    // Use this for initialization
    void Start()
    {
        _texture = videoRenderer.getWebCamTexture();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_texture)
        {
            _texture = videoRenderer.getWebCamTexture();
            Debug.Log(_texture.width);
        }
        if (Input.GetMouseButtonDown(1))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            MeshCollider collie = videoRenderer.gameObject.GetComponentInChildren<MeshCollider>();

            if (!collie.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 2000f))
                return;

            Debug.DrawRay(ray.origin, ray.direction * 5000000, Color.green);
            //Debug.LogError("Stop!");

            Renderer rend = hit.transform.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;

            if (rend == null || meshCollider == null)
                return;

            Vector2 pixelUV = hit.textureCoord;
            Debug.Log(pixelUV);
            pixelUV.x *= 1280f;
            pixelUV.y *= 720f;

            Color32 color = (Color32)_texture.GetPixel((int)pixelUV.x, (int)pixelUV.y);
            ctp.colorTargets.Add(new Vexpot.ColorTarget(color, 20f));
            ctp.StopColorTracker();
            ctp.UpdateColorTargets();
            ctp.StartColorTracker();
            return;
        }
    }
}