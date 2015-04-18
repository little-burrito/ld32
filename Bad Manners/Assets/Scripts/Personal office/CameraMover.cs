using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

    public CameraPoint cameraPoint;
    private Camera camera;
    private float previousOrthographicSize;
    private float previousX;
    private float previousY;
    private float previousZ;

    public float animationDuration;
    private float newWaypointTime;
    private bool arrived;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
        if ( cameraPoint != null ) {
            transform.position = cameraPoint.transform.position;
            camera.orthographicSize = cameraPoint.orthographicSize;
        }
        arrived = true;
        newWaypointTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if ( !arrived ) {
            float animationProgress = Mathf.Min( ( Time.time - newWaypointTime ) / animationDuration, 1 ); // % av animationen från 0 till 1
            if ( animationProgress < 1 ) {
                transform.position = new Vector3(
                    animationEasing( animationProgress, previousX, cameraPoint.transform.position.x - previousX ),
                    animationEasing( animationProgress, previousY, cameraPoint.transform.position.y - previousY ),
                    animationEasing( animationProgress, previousZ, cameraPoint.transform.position.z - previousZ ) );
                camera.orthographicSize = animationEasing( animationProgress, previousOrthographicSize, cameraPoint.orthographicSize - previousOrthographicSize );
            } else {
                arrived = true;
            }
        }
        if ( arrived ) {
            transform.position = cameraPoint.transform.position;
            camera.orthographicSize = cameraPoint.orthographicSize;
        }
	}

    private float animationEasing( float animationProgress, float previous, float change ) {
        float multiplier = 0.5f * ( 1 - Mathf.Cos( Mathf.PI * animationProgress ) );
        return previous + change * multiplier;
    }

    public void SetCameraPoint( CameraPoint cameraPoint ) {
        newWaypointTime = Time.time;
        previousOrthographicSize = camera.orthographicSize;
        previousX = transform.position.x;
        previousY = transform.position.y;
        previousZ = transform.position.z;
        this.cameraPoint = cameraPoint;
        arrived = false;
    }
}
