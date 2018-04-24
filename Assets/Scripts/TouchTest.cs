using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using VRStandardAssets.Utils;


	public class TouchTest : MonoBehaviour {


		[SerializeField] private VRInput m_VRInput;

		public GameObject camera;



		// Use this for initialization
		void Start () {
			//m_VRInput.OnSwipe += HandleSwipe;
		}

		private void OnEnable()
		{
			m_VRInput.OnSwipe += HandleSwipe;
			m_VRInput.OnClick += HandleClick;
			m_VRInput.OnDoubleClick += HandleDoubleClick;
			//Cardboard.SDK.OnTrigger += HandleClick;

		
		}
		
		// Update is called once per frame
		void Update () {

		}

		void HandleSwipe(VRInput.SwipeDirection swipeDirection)
		{
			switch (swipeDirection)
			{
			case VRInput.SwipeDirection.NONE:

				break;
			case VRInput.SwipeDirection.UP:

				break;
			case VRInput.SwipeDirection.DOWN:


				break;
			case VRInput.SwipeDirection.LEFT:

			case VRInput.SwipeDirection.RIGHT:

				break;
			}

		}

		void HandleClick(){

			camera.GetComponent<RayCamera>().cameraShoot();
		}

		void HandleDoubleClick(){

		}


			
	}
