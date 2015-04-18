using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour {

    private Animator anim;
    private bool isSelected;
    private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
        if ( Input.GetMouseButtonDown( 0 ) ) { // Om man vänsterklickar
            if ( isSelected ) {
                Action();
            }
        }
        if ( !isSelected ) {
            GameObject controllerObject = GameObject.FindGameObjectWithTag( "Controller" );
            if ( controllerObject != null ) {
                Controller controller = controllerObject.GetComponent<Controller>();
                if ( controller != null ) {
                    if ( controller.cash > 500 ) {
                        sprite.color = new Color( 0.0f, 1.0f, 0.0f );
                    } else {
                        sprite.color = new Color( 1.0f, 1.0f, 1.0f );
                    }
                }
            }
        }
	}

    void OnMouseEnter() {
        isSelected = true;
        sprite.color = new Color( 1.0f, 0.0f, 0.0f );
        if ( anim != null ) {
            anim.SetBool( "isSelected", isSelected );
        }
    }
    void OnMouseExit() {
        isSelected = false;
        sprite.color = new Color( 1.0f, 1.0f, 1.0f );
        if ( anim != null ) {
            anim.SetBool( "isSelected", isSelected );
        }
    }

    protected virtual void Action() {
        Debug.Log( gameObject.name + " was clicked" );
    }
}
