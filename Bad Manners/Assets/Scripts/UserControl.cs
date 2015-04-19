using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	public float velocityMultiplier = 5.0f;
	public float angle = 0f;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
 		rb = transform.GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
		rb.velocity = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * velocityMultiplier;
		float atan2 = Mathf.Atan2(rb.velocity.y, rb.velocity.x) *  Mathf.Rad2Deg;
		atan2 += angle;
		transform.rotation = Quaternion.AngleAxis(atan2, Vector3.forward);
	}
}
