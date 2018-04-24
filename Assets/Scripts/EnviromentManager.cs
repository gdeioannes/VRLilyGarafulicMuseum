using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnviromentManager : MonoBehaviour {

	public static EnviromentManager _instance;
	public GameObject currentEnviroment;
	public GameObject enviromentContainer;
	public GameObject cameraContainer;
	public GameObject fadePanelSamsung;
	public GameObject fadePanelGoogle;
	private GameObject currentFadePanel;
	public bool thunderTriggerFlag=false;


	// Use this for initialization
	void Start () {
		if(_instance==null){
			_instance=this;
		}
		hideEnviromentsOnStart(currentEnviroment);
		if(fadePanelSamsung.transform.parent.transform.parent.gameObject.active){
			fadePanelSamsung.SetActive(true);
			currentFadePanel=fadePanelSamsung;
			print("Samsung Panel");
		}else{
			fadePanelGoogle.SetActive(true);
			currentFadePanel=fadePanelGoogle;
			print("Google Panel");
		}
		StartCoroutine(doFadeOutPanel(currentEnviroment));
	}

	// Update is called once per frame
	void Update () {
		if(currentEnviroment.GetComponent<Enviroment>().thunderFlag && !thunderTriggerFlag){
			StartCoroutine(tunderEffect(currentEnviroment));
		}
	}

	IEnumerator doFadeOutPanel(GameObject newCurrectEnviroment){
		float seconds=0.75f;
		gameObject.GetComponents<AudioSource>()[0].Play();
		currentFadePanel.GetComponent<Image>().CrossFadeAlpha(1,seconds,false);
		yield return new WaitForSeconds(seconds);

		currentEnviroment.SetActive(false);
		currentEnviroment=newCurrectEnviroment;
		changeCameraPosition(newCurrectEnviroment);

		currentFadePanel.GetComponent<Image>().CrossFadeAlpha(0,seconds,false);
		yield return null;
	}

	public void hideEnviromentsOnStart(GameObject cEnviroment){
		foreach (Transform child in enviromentContainer.transform) {
			child.transform.gameObject.SetActive(false);
		}
		cEnviroment.SetActive(true);
		changeCameraPosition(cEnviroment);
	}

	public void changeCurrentEnviroment(GameObject newCurrectEnviroment){
		
		StartCoroutine(doFadeOutPanel(newCurrectEnviroment));

	}

	IEnumerator tunderEffect(GameObject newCurrectEnviroment){
		thunderTriggerFlag=true;
		float thunderChance=35;
		if(Random.Range(0,100)<thunderChance ){
			int counter=0;
			int counterMax=20;
			float waitMin=0.1f;
			float waitMax=0.3f;
			float wait=0.3f;
			float exposureMin=1f;
			float exposureMax=1.5f;
			float exposure=0.3f;
			yield return new WaitForSeconds(2);
			gameObject.GetComponents<AudioSource>()[1].Play();
			while(counter<counterMax){
				wait=Random.Range(waitMin,waitMax);
				exposure=Random.Range(exposureMin,exposureMax);
				newCurrectEnviroment.GetComponent<Renderer>().material.SetFloat("_Exposure",exposure);
				yield return new WaitForSeconds(wait);
				counter++;
			}

			newCurrectEnviroment.GetComponent<Renderer>().material.SetFloat("_Exposure",1);
		}
		yield return new WaitForSeconds(5);
		thunderTriggerFlag=false;
		yield return null;
	}

	public static EnviromentManager getInstance(){
		return _instance;
	}

	public void changeCameraPosition(GameObject envi){
		print("Change Enviroment");
		Vector3 enviPos=envi.gameObject.transform.position;
		cameraContainer.transform.position=new Vector3(enviPos.x,enviPos.y,enviPos.z);
		envi.SetActive(true);
	}
}
