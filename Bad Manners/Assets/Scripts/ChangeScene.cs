﻿using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public enum Mode {
        nextLevel,
        previousLevel,
        specificLevel
    }

    public Mode mode;
    public string specificLevelName;

    public void Trigger() {
        switch ( mode ) {
            case Mode.nextLevel: {
                Application.LoadLevelAdditive( 1 );
                break;
                }
            case Mode.previousLevel: {
                Application.LoadLevelAdditive( -1 );
                break;
                }
            case Mode.specificLevel: {
                Application.LoadLevel( specificLevelName );
                break;
                }
        }
    }
}