using UnityEngine;
using System.Collections;

public class SMSSingleton : MonoBehaviour {

    private static SMSSingleton instance = null; // Singleton
    public static SMSSingleton Instance { // Singleton
        get { return instance; } // Singleton
    } // Singleton

    void Awake() {
        if ( instance != null && instance != this ) { // Singleton
            Destroy( this.gameObject ); // Singleton
            return; // Singleton
        } else { // Singleton
            instance = this; // Singleton
        } // Singleton
        DontDestroyOnLoad( this.gameObject ); // Singleton
    }
}
