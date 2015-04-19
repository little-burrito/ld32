using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

    public bool isSelected;
    public ParticleSystem hoverParticleSystem;
    private Mobile mobile;

	// Use this for initialization
	void Start () {
        if ( GetComponent<Collider2D>() == null ) {
            Debug.LogError( gameObject.name + " har ingen collider och kan därför inte klickas på" );
        }
		GameObject mobileObject = GameObject.FindGameObjectWithTag ("Mobile");
		if ( mobileObject != null) {
			Mobile mobileComponent = mobileObject.GetComponent<Mobile>();
			if ( mobileComponent != null ) {
				mobile = mobileComponent;
			}
		}
	}

	// Update is called once per frame
	void Update () {
        if ( isSelected ) {
			if (mobile != null) {
	            if ( mobile.isActive ) {
	                isSelected = false;
	                UpdateHoverEffect();
	            }
			} else {
				isSelected = false;
				UpdateHoverEffect();
			}
        }
        if ( Input.GetMouseButtonDown( 0 ) ) { // Om man vänsterklickar
            if ( isSelected ) {
                Action();
            }
        }
	}

    void OnMouseOver() {
		if (mobile != null) {
			if (!mobile.isActive) {
				isSelected = true;
				UpdateHoverEffect ();
			}
		} else {
			isSelected = true;
			UpdateHoverEffect ();
		}
    }
    void OnMouseExit() {
        isSelected = false;
        UpdateHoverEffect();
    }

    public void Disable() {
        isSelected = false;
        GetComponent<Collider2D>().enabled = false;
        UpdateHoverEffect();
    }
    public void Enable() {
        GetComponent<Collider2D>().enabled = true;
    }

    public void UpdateHoverEffect() {
        if ( hoverParticleSystem != null ) {
            if ( isSelected ) {
                hoverParticleSystem.Play();
            } else {
                hoverParticleSystem.Stop();
                hoverParticleSystem.Clear();
            }
        }
    }

    protected virtual void Action() {
        Debug.Log( gameObject.name + " was clicked" );
    }
}
