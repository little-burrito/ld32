using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

    private bool isSelected;
    public ParticleSystem hoverParticleSystem;

	// Use this for initialization
	void Start () {
        if ( GetComponent<Collider2D>() == null ) {
            Debug.LogError( gameObject.name + " har ingen collider och kan därför inte klickas på" );
        }
	}

	// Update is called once per frame
	void Update () {
        if ( Input.GetMouseButtonDown( 0 ) ) { // Om man vänsterklickar
            if ( isSelected ) {
                Action();
            }
        }
	}

    void OnMouseEnter() {
        isSelected = true;
        UpdateHoverEffect();
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
