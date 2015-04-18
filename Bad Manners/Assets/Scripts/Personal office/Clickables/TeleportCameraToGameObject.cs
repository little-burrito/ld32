using UnityEngine;
using System.Collections;

public class TeleportCameraToGameObject : Clickable {

    public GameObject objectToTeleportTo;

    protected override void Action() {
        Camera.main.transform.position = new Vector3( objectToTeleportTo.transform.position.x, objectToTeleportTo.transform.position.y, Camera.main.transform.position.z );
    }

}
