using UnityEngine;
using System.Collections;

public class GEMSingleton : MonoBehaviour {

    private static GEMSingleton instance = null; // Singleton
    public static GEMSingleton Instance { // Singleton
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
