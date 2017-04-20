using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vexpot.Integration;

public class GameController : MonoBehaviour
{

    private WebCamTexture _texture;
    public VideoCaptureRenderer videoRenderer;
    public ColorTrackerPanel ctp;
    private UnitFactory _factory;

    // Use this for initialization
    void Start()
    {
        _texture = videoRenderer.getWebCamTexture();
        _factory = Hierarchy.GetComponentWithTag<UnitFactory>("UnitManager"); 
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
            RaycastHit hit;
            MeshCollider collie = videoRenderer.gameObject.GetComponentInChildren<MeshCollider>();

            if (!collie.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 2000f))
                return;

            Renderer rend = hit.transform.GetComponent<Renderer>();
            MeshCollider meshCollider = hit.collider as MeshCollider;

            if (rend == null || meshCollider == null)
                return;

            Vector2 pixelUV = hit.textureCoord;
            pixelUV.x *= 1280f;
            pixelUV.y *= 720f;

            Color32 color = (Color32)_texture.GetPixel((int)pixelUV.x, (int)pixelUV.y);
            ctp.colorTargets.Add(new Vexpot.ColorTarget(color, 10f));
            ctp.StopColorTracker();
            ctp.UpdateColorTargets();
            ctp.StartColorTracker();

            _factory.CreateUnit(color);
        }
    }
}