using UnityEngine;
using System.Collections;

public class fixCamerea : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// 3:4 aspect ratio
		if ( (Screen.width == 240 && Screen.height == 320) || (Screen.width == 768 && Screen.height == 1024) || (Screen.width == 480 && Screen.height == 640) || (Screen.width == 1152 && Screen.height == 1536) || (Screen.width == 1536 && Screen.height == 2048) || ( System.Math.Round((double) Screen.width/Screen.height, 3) == System.Math.Round((double)3/4, 3) ) ){
			camera.orthographicSize = 6.8f;
		}
		// 3:5 aspect ratio
		if ( (Screen.width == 240 && Screen.height == 400) || (Screen.width == 480  && Screen.height == 800) || (Screen.width == 768 && Screen.height == 1280) || (Screen.width == 1152 && Screen.height == 1920) || (Screen.width == 1536 && Screen.height == 2560) || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)3/5, 3) ) ){
			camera.orthographicSize = 8.5f;
		}
		// 5:9 aspect ratio
		if ( (Screen.width == 240 && Screen.height == 432) || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)5/9, 3) ) ) {
			camera.orthographicSize = 9.2f;
		}
		// 240:427 aspect ratio
		if ( (Screen.width == 480 && Screen.height == 854) || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)240/427, 3) )  ) {
			camera.orthographicSize = 9.1f;
		}
		// 75:128 aspect ratio
		if ( (Screen.width == 600 && Screen.height == 1024) || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)75/128, 3) )  ) {
			camera.orthographicSize = 8.75f;
		}
		// 2:3 aspect ratio
		if ( (Screen.width == 320 && Screen.height == 480) || (Screen.width == 640 && Screen.height == 960) || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)2/3, 3) )  ) {
			camera.orthographicSize = 7.7f;
		}
		// 5:8 aspect ratio
		if ( (Screen.width == 800 && Screen.height == 1280) || (Screen.width == 1200 && Screen.height == 1920) || (Screen.width == 1600 && Screen.height == 2560) || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)5/8, 3) )  ) {
			camera.orthographicSize = 8.2f;
		}
		// 9:16 aspect ratio
		if ( (Screen.width == 1080 && Screen.height == 1920)  || ( System.Math.Round((double)Screen.width/Screen.height, 3) == System.Math.Round((double)9/16, 3) ) ) {
			camera.orthographicSize = 9.1f;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
