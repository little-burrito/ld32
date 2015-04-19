using UnityEngine;
using System.Collections;

public class Busted : MonoBehaviour {

	private bool started = false;

	public void StartBusted() {
		if (!started) {
			GetComponent<Animator>().SetBool("Busted", true);
			Debug.Log("StartBusted");
			started = true;
		}
	}

	void TriggerBusted() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
