using UnityEngine;
using System.Collections;

public class ClickableHighlight : MonoBehaviour {

	public bool hover = true;

	void Start() {
		for (int i = 0; i < 4; i++){
			GameObject child = new GameObject("Outline");
			SpriteRenderer sr = child.AddComponent<SpriteRenderer>();
			sr.sprite = this.GetComponent<SpriteRenderer>().sprite;
			sr.color = Color.black;
			child.transform.parent = this.transform;
			child.transform.position = this.transform.position;
			child.transform.localScale = Vector3.one;
			float dist = 0.05f;
			switch(i) {
			case 0:
				child.transform.Translate(-dist, -dist, dist);
				break;
			case 1:
				child.transform.Translate(dist, -dist, dist);
				break;
			case 2:
				child.transform.Translate(-dist, dist, dist);
				break;
			case 3:
				child.transform.Translate(dist, dist, dist);
				break;
			}
		}
	}

	void OnMouseEnter() {
		if (hover) {
			transform.FindChild("Particle System").gameObject.SetActive(true);
		}
	}

	void OnMouseExit() {
		if (hover) {
			transform.FindChild("Particle System").gameObject.SetActive(false);
		}
	}
}
