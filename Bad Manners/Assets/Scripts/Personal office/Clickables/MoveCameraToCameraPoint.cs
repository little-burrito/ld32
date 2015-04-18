using UnityEngine;
using System.Collections;

public class MoveCameraToCameraPoint : Clickable {

    public CameraPoint cameraPoint;
    public GameObject interfaceToEnable;
    public GameObject interfaceToDisable;
    public Clickable clickableToDisable;
    public Clickable clickableToEnable;

    protected override void Action() {
        CameraMover cameraMover = Camera.main.GetComponent<CameraMover>();
        cameraMover.SetCameraPoint( cameraPoint );

        if ( interfaceToEnable != null ) {
            interfaceToEnable.SetActive( true );
        }
        if ( interfaceToDisable != null ) {
            interfaceToDisable.SetActive( false );
        }
        if ( clickableToEnable != null ) {
            clickableToEnable.enabled = true;
            clickableToEnable.Enable();
        }
        if ( clickableToDisable != null ) {
            clickableToDisable.Disable();
            clickableToDisable.enabled = false;
        }
    }

}