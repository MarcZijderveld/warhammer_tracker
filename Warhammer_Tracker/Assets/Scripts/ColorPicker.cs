using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vexpot.Integration;

public class ColorPicker : MonoBehaviour {

	private WebCamTexture _texture;
	public 	VideoCaptureRenderer videoRenderer;
	public 	ColorTrackerPanel ctp;

	// Use this for initialization
	void Start () {
		_texture = videoRenderer.getWebCamTexture ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_texture) {
			_texture = videoRenderer.getWebCamTexture ();
			Debug.Log (_texture.width);
		}
		if(Input.GetMouseButtonDown(1))
		{
			RaycastHit hit;
			if (!Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
				return;

			Renderer rend = hit.transform.GetComponent<Renderer>();
			MeshCollider meshCollider = hit.collider as MeshCollider;

			if (rend == null || meshCollider == null)
				return;

			Vector2 pixelUV = hit.textureCoord;
			pixelUV.x *= _texture.width;
			pixelUV.y *= _texture.height;

			Color32 color = (Color32)_texture.GetPixel ((int)pixelUV.x, (int)pixelUV.y);
			ctp.colorTargets.Add (new Vexpot.ColorTarget (color));
			ctp.UpdateColorTargets ();
		 	return;
		}
	}
}
