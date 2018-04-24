using UnityEngine;
using System.Collections;

public class Marker : MonoBehaviour {

	public GameObject enviroment;
	private Camera camera;
	private EnviromentManager enviromentManager= new EnviromentManager();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collision) {
		print("Collide");
		activateEnviroment();
	}

	public void activateEnviroment(){
		enviromentManager=EnviromentManager.getInstance();
		enviromentManager.changeCurrentEnviroment(enviroment);
	}
}
