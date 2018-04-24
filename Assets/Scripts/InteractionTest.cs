using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate() 
	{
		
	}

	public Collider checkColision(){
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		RaycastHit hit;

		if (Physics.Raycast(transform.position, fwd,out hit, 50)) {
			return hit.collider;
		}
		return null;
	}
}
