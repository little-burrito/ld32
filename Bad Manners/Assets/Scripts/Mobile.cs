using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Mobile : MonoBehaviour {

    public Text visibleMessage;
    private float previousX;
    private float previousY;
    private float previousZ;
    private float newX;
    private float newY;
    public float animationDuration;
    private float newWaypointTime;
    public bool isActive;
    public AudioSource newMessageSound;
    private Animator anim;

	// Use this for initialization
	void Start () {
        isActive = false;
        anim = GetComponent<Animator>();
        SetText( "Hej på dig!" );
	}

    public void SetText( string text ) {
        visibleMessage.text = text;
        newMessageSound.Play();
    }

    public void Toggle() {
        if ( isActive ) {
            Deactivate();
        } else {
            Activate();
        }
    }

    private void UpdateAnimator() {
        anim.SetBool( "isActive", isActive );
    }

    public void Activate() {
        isActive = true;
        UpdateAnimator();
    }

    public void Deactivate() {
        isActive = false;
        UpdateAnimator();
    }
}
