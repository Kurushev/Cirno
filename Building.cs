using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {
	public Camera gameCamera;
	public Terrain gameTerrain;
	public Material[] gameMaterials;
	private Collider terrainCollider;
	private float buildingHalfSize;
	private Renderer objectRanderer;
	
	GameObject prefab;
	
	private float gridSize = 5f;
	private float croppedX;
	private float croppedZ;
	
	int anotherObject;
	
	// Use this for initialization
	void Start () {
		gameCamera = GameObject.Find("GameCamera").GetComponent<Camera>();
		gameTerrain = GameObject.Find("WorldTerrain").GetComponent<Terrain>();
		terrainCollider = gameTerrain.GetComponent<Collider>();
		objectRanderer = GetComponent<Renderer>();
		buildingHalfSize = transform.localScale.y/2;
		prefab = GameObject.Find ("PlacedBuilding");
		anotherObject = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		
		//Vector3 mousePos = Input.mousePosition;
		Ray mRay = gameCamera.ScreenPointToRay (Input.mousePosition);
		RaycastHit[] mHit;
		mHit = Physics.RaycastAll(mRay);
			for (int i = 0; i < mHit.Length; i++) {
			
			if (mHit[i].collider == terrainCollider) {
				croppedX = Mathf.Round (mHit[i].point.x / gridSize) * gridSize;
				croppedZ = Mathf.Round (mHit[i].point.z / gridSize) * gridSize;
				
				transform.position = new Vector3 (croppedX, buildingHalfSize, croppedZ);
			}
			
			
			if (anotherObject > 0) {
				objectRanderer.material = gameMaterials[1];
			} else {
				objectRanderer.material = gameMaterials[0];
			}
		}	
	
		if (Input.GetKey(KeyCode.Escape)) {
			Destroy (gameObject);
		}
		
		if (Input.GetMouseButtonDown (0) && anotherObject == 0) {
			Instantiate(prefab, transform.position, Quaternion.identity);
		}
	
	}
	
	
	
	void OnTriggerEnter(Collider otherCollider) {
		if (otherCollider != terrainCollider) {
		anotherObject++;
		Debug.Log ("Trigger occurs!");
		}
	}
	
	void OnTriggerExit(Collider otherCollider) {
		if (otherCollider != terrainCollider) {
		anotherObject--;
		Debug.Log ("Triggers end!");
		}
	}
	
	
}
