using UnityEngine;
using System.Collections;

public class CoworkerPhoneCall : MonoBehaviour {

	public float probability = 0.1f;
	public Path path;

	private int time;
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void StopCall() {
		anim.SetBool("MakeCall", false);
		path.StartWalk();
	}

	void FixedUpdate() {
		int newTime = (int)Time.fixedTime;
		if (
			newTime != time &&
			Random.value < probability &&
			!anim.GetBool("MakeCall")
		) {
			Debug.Log("Should make call");
			anim.SetBool("MakeCall", true);
			path.StopWalk();
		}
		time = newTime;
	}
}
