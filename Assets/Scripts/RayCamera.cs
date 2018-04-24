using UnityEngine;
using System.Collections;

public class RayCamera : MonoBehaviour {

	public GameObject startingEnviroment;
	private EnviromentManager enviromentManager= new EnviromentManager();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void cameraShoot(){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		print("Shoot Ray");
		if (Physics.Raycast(ray, out hit)) {
			Transform objectHit = hit.transform;
			print(hit.collider.gameObject.name);
			hit.collider.gameObject.GetComponent<Marker>().activateEnviroment();
			// Do something with the object that was hit by the raycast.
		}
	}
}
