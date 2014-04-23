using UnityEngine;
using System.Collections;

public class musicManager : MonoBehaviour {

	void Update() {
        audio.volume = 0.1f; //Volymen

		if (PlayerPrefs.GetInt ("musicOff") == 1 ) {
			audio.mute = true;
		}
		if (PlayerPrefs.GetInt ("musicOff") == 0 ) {
			audio.mute = false;
		}

	}
}
