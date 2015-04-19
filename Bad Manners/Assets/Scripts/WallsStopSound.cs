using UnityEngine;
using System.Collections;

public class WallsStopSound : MonoBehaviour {

    private AudioSource audioSource;
    private GameObject playerContainer;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        playerContainer = GameObject.FindGameObjectWithTag( "Player" );
	}
	
	// Update is called once per frame
	void Update () {
        //float distance = ( ( Vector2 )( playerContainer.transform.position - transform.position ) ).magnitude;
        //if ( distance < audioSource.maxDistance ) {
			Vector2 dist = (Vector2)(playerContainer.transform.position - this.transform.position);
			RaycastHit2D hit = Physics2D.Raycast(
				(Vector2) this.transform.position + dist*0.5f,
				dist,
				dist.magnitude,
				1 << LayerMask.NameToLayer("Furniture")
			);
            //if ( hit && hit.collider.tag == "Player" ) {
                audioSource.Stop();
            //} else {
                if ( !audioSource.isPlaying ) {
                    audioSource.Play();
                }
            //}
        //}
	}
}
