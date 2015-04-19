using UnityEngine;
using System.Collections;

public class CoworkerAttention : MonoBehaviour {

	public Busted busted;

	void Start() {
		busted = GameObject.Find("Main Camera").GetComponent<Busted>();
		if (!busted) {
			Debug.LogError("CoworkerAttention Busted not set.");
		}
	}

	void Bust() {
		transform.parent.FindChild("Alert").gameObject.SetActive(true);
		busted.StartBusted();
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "DeadCoworker" || col.tag == "Player") {
			Vector2 dist = (Vector2)(col.transform.position - this.transform.position);
			Vector2 start = (Vector2) this.transform.position + dist*0.1f;
			RaycastHit2D hit = Physics2D.Raycast(
				start,
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
				//Debug.DrawRay(start, dist, Color.green, 1f);
				Bust();
			} else if (
				hit &&
				hit.collider.tag == "DeadCoworker"
			) {
				//Debug.DrawRay(start, dist, Color.green, 1f);
				Bust();
			} else {
				//Debug.Log("vision blocked");
			}
		}
	}
}
