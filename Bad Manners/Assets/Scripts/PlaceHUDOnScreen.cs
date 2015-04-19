using UnityEngine;
using System.Collections;

public class PlaceHUDOnScreen : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        RectTransform rect = GetComponent<RectTransform>();
        rect.offsetMin = rect.offsetMax = new Vector2( 0, 0 );
	}
}
