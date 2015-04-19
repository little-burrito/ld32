using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	private Rigidbody2D rb;
	public float velocityMultiplier = 5.0f;

	// Use this for initialization
	void Start () {
 		rb = transform.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
		rb.velocity = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * velocityMultiplier;
	}
}
