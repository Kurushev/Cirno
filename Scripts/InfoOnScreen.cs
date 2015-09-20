using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoOnScreen : MonoBehaviour {

	public Camera gameCamera;
	public Terrain gameTerrain;
	public Text infoText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		infoText.text = "Mouse position X(pixels): " + Input.mousePosition.x + "\n" +
						"Mouse position Y(pixels): " + Input.mousePosition.y + "\n" +
						"Camera position X(units): " + gameCamera.transform.position.x + "\n" +
						"Camera position Y(units): " + gameCamera.transform.position.y + "\n" +
						"Camera position Z(units): " + gameCamera.transform.position.z;
	}
}
