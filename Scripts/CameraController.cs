using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera gameCamera;
	public Terrain gameTerrain;
	float cameraSize = 30;
	float cameraSizeMax = 50;
	float cameraSizeMin = 20;
	public int cameraZoomMultiplier = 1;
	float cameraMinXCoordinates;
	float cameraMaxXCoordinates;
	float cameraMinZCoordinates;
	float cameraMaxZCoordinates;
	float cameraMouseControlDelta = 10;

	float deltaX;
	float deltaZ;

	float cameraMovementSpeed = 2;

	// Use this for initialization
	void Start () {
		cameraMinXCoordinates = -50;
		cameraMaxXCoordinates = gameTerrain.terrainData.size.x - 50;
		cameraMinZCoordinates = -50;
		cameraMaxZCoordinates = gameTerrain.terrainData.size.z - 50;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") > 0 || Input.mousePosition.x > (Screen.width - cameraMouseControlDelta)) {
			//gameCamera.transform.Translate(Input.GetAxis ("Horizontal"), 0f, 0f);
			if (gameCamera.transform.position.x < cameraMaxXCoordinates && gameCamera.transform.position.z > cameraMinZCoordinates) {
				deltaX = gameCamera.transform.position.x + cameraMovementSpeed;
				deltaZ = gameCamera.transform.position.z - cameraMovementSpeed;
				gameCamera.transform.position = new Vector3 (deltaX, gameCamera.transform.position.y, deltaZ);
			}
		} else if (Input.GetAxis ("Horizontal") < 0 || Input.mousePosition.x < cameraMouseControlDelta) {
			if (gameCamera.transform.position.x > cameraMinXCoordinates && gameCamera.transform.position.z < cameraMaxZCoordinates) {
				deltaX = gameCamera.transform.position.x - cameraMovementSpeed;
				deltaZ = gameCamera.transform.position.z + cameraMovementSpeed;
				gameCamera.transform.position = new Vector3 (deltaX, gameCamera.transform.position.y, deltaZ);
			}
		}

		if (Input.GetAxis ("Vertical") > 0 || Input.mousePosition.y > (Screen.height - cameraMouseControlDelta)) {
			if (gameCamera.transform.position.x < cameraMaxXCoordinates && gameCamera.transform.position.z < cameraMaxZCoordinates) {
				deltaX = gameCamera.transform.position.x + cameraMovementSpeed;
				deltaZ = gameCamera.transform.position.z + cameraMovementSpeed;
				gameCamera.transform.position = new Vector3 (deltaX, gameCamera.transform.position.y, deltaZ);
			}
		} else if (Input.GetAxis ("Vertical") < 0 || Input.mousePosition.y < cameraMouseControlDelta) {
			if (gameCamera.transform.position.x > cameraMinXCoordinates && gameCamera.transform.position.z > cameraMinZCoordinates) {
				deltaX = gameCamera.transform.position.x - cameraMovementSpeed;
				deltaZ = gameCamera.transform.position.z - cameraMovementSpeed;
				gameCamera.transform.position = new Vector3 (deltaX, gameCamera.transform.position.y, deltaZ);
			}
		}


		if 		(Input.GetAxis ("Mouse ScrollWheel") < 0 && cameraSize >= cameraSizeMin) {cameraSize -= cameraZoomMultiplier;}
		else if	(Input.GetAxis ("Mouse ScrollWheel") > 0 && cameraSize <= cameraSizeMax) {cameraSize += cameraZoomMultiplier;}
		gameCamera.orthographicSize = cameraSize;





	}
}
