using UnityEngine;
using System.Collections;

public class PushStory : ChangeScene {

    private Player player;

    void Awake() {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag( "Player" );
        foreach ( GameObject obj in playerObjects ) {
            Player p = GameObject.FindObjectOfType<Player>();
            if ( p != null ) {
                player = p;
                break;
            }
        }
        player.pushStory();
    }
}
