using UnityEngine;
using System.Collections;

public class ObjectsManager : MonoBehaviour {

public GameObject buildingPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void createBuilding() {
		Instantiate(buildingPrefab);
	
	}
	

	
}
