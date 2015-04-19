using UnityEngine;
using System.Collections;

public class UserControl : MonoBehaviour {

	public float velocityMultiplier = 5.0f;
	public float angle = 0f;
	public bool bloody = false;

	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Start () {
 		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		if (bloody) {
			anim.SetBool("Bloody", true);
		}
	}
	
	void FixedUpdate() {
		rb.velocity = new Vector2(
			Input.GetAxis("Horizontal"),
			Input.GetAxis("Vertical")
		).normalized * velocityMultiplier;
		float atan2 = Mathf.Atan2(rb.velocity.y, rb.velocity.x) *  Mathf.Rad2Deg;
		atan2 += angle;
		if (rb.velocity.magnitude > 0.01f) {
			transform.rotation = Quaternion.AngleAxis(atan2, Vector3.forward);
			anim.SetBool("Walking", true);
		} else {
			anim.SetBool("Walking", false);
		}
	}
}
