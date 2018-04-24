using UnityEngine;
using System.Collections;

public class ChangeLigthMap : MonoBehaviour {

	public GameObject sphere;
	public Texture secondTexture;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			Texture tx=sphere.GetComponent<Renderer>().material.GetTexture("_Tex");
			sphere.GetComponent<Renderer>().material.SetTexture("_Tex",secondTexture);
		}
	}
}
