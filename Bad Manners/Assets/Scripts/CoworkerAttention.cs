using UnityEngine;
using System.Collections;

public class CoworkerAttention : MonoBehaviour {
	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "DeadCoworker" || col.tag == "Player") {
			Vector2 dist = (Vector2)(col.transform.position - this.transform.position);
			RaycastHit2D hit = Physics2D.Raycast(
				(Vector2) this.transform.position + dist*0.5f,
				dist,
				dist.magnitude,
				1 << LayerMask.NameToLayer("Characters") |
				1 << LayerMask.NameToLayer("Furniture")
			);
			if (
				hit &&
				hit.collider.tag == "Player" &&
				hit.collider.GetComponent<PickupDeadCoworker>().isCarrying()
			) {
				//Debug.Log("PLAYER WITH BODY HAS BEEN DETECTED!!!");
			} else if (
				hit &&
				hit.collider.tag == "DeadCoworker"
			) {
				//Debug.Log("BODY HAS BEEN DETECTED!!!");
			} else {
				//Debug.Log("vision blocked");
			}
		}
	}
}
