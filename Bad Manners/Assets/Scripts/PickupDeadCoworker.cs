using UnityEngine;
using System.Collections;

public class PickupDeadCoworker : MonoBehaviour {

	public Vector2 dropDistance = new Vector2(0, -2.5f);
	public float carryVelocity = 0.65f;

	private bool carrying = false;
	private GameObject deadCoworker;
	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void carry() {
		deadCoworker.SetActive(false);
		carrying = true;
		anim.SetBool("Carry Body", true);
		anim.SetBool("Bloody", true);
		gameObject.GetComponent<UserControl>().velocityMultiplier *= carryVelocity;
		gameObject.GetComponent<Rigidbody2D>().mass += deadCoworker.GetComponent<Rigidbody2D>().mass;
	}

	void drop() {
		deadCoworker.transform.position = transform.position;
		deadCoworker.transform.Translate(dropDistance);
		deadCoworker.SetActive(true);
		carrying = false;
		anim.SetBool("Carry Body", false);
		gameObject.GetComponent<UserControl>().velocityMultiplier /= carryVelocity;
		gameObject.GetComponent<Rigidbody2D>().mass -= deadCoworker.GetComponent<Rigidbody2D>().mass;
		transform.FindChild("Player Body").FindChild("Dead Body").gameObject.SetActive(false);
	}

	public bool isCarrying() {
		return carrying;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (!carrying && col.collider.tag == "DeadCoworker") {
			deadCoworker = col.collider.gameObject;
			carry();
		}
	}

	void Update() {
		if (carrying && Input.GetButtonDown("Submit")) {
			drop();
		}
	}
}
