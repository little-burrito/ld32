using UnityEngine;
using System.Collections;

public class PushStoryScript : MonoBehaviour {

    private Player player;
    private int triggerTimer = 2;

    void Awake() {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag( "Player" );
        foreach ( GameObject obj in playerObjects ) {
            Player p = GameObject.FindObjectOfType<Player>();
            if ( p != null ) {
                player = p;
                break;
            }
        }
    }

    void Update() {
        if ( triggerTimer > 0 ) {
            triggerTimer--;
            if ( triggerTimer == 0 ) {
                player.pushStory();
            }
        }
    }
}
