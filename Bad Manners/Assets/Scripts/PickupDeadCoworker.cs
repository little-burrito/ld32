using UnityEngine;
using System.Collections;

public class PickupDeadCoworker : MonoBehaviour {

	public Vector2 dropDistance = new Vector2(0, -2.0f);
	public float carryVelocity = 0.75f;

	private bool carrying = false;
	private GameObject deadCoworker;

	void carry() {
		deadCoworker.SetActive(false);
		carrying = true;
		this.gameObject.transform.FindChild("Carry").gameObject.SetActive(true);
		this.gameObject.transform.FindChild("Normal").gameObject.SetActive(false);
		gameObject.GetComponent<UserControl>().velocityMultiplier *= carryVelocity;
		gameObject.GetComponent<Rigidbody2D>().mass += deadCoworker.GetComponent<Rigidbody2D>().mass;
	}

	void drop() {
		deadCoworker.transform.position = transform.position;
		deadCoworker.transform.Translate(dropDistance);
		deadCoworker.SetActive(true);
		carrying = false;
		this.gameObject.transform.FindChild("Carry").gameObject.SetActive(false);
		this.gameObject.transform.FindChild("Normal").gameObject.SetActive(true);
		gameObject.GetComponent<UserControl>().velocityMultiplier /= carryVelocity;
		gameObject.GetComponent<Rigidbody2D>().mass += deadCoworker.GetComponent<Rigidbody2D>().mass;
	}

	public bool isCarrying() {
		return carrying;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.tag == "DeadCoworker") {
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
