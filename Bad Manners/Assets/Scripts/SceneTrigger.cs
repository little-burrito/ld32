using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneTrigger : MonoBehaviour {
	public string triggerTag = "Player";

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == triggerTag) {
			GetComponent<ChangeScene>().Trigger();
		}
	}
}
