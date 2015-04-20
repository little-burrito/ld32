using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

    public enum Mode {
        nextLevel,
        doubleNextLevel,
        previousLevel,
        specificLevel
    }

    public Mode mode;
    public string specificLevelName;

    public virtual void Trigger() {
        switch ( mode ) {
            case Mode.nextLevel: {
                Application.LoadLevel( Application.loadedLevel + 1 );
                break;
                }
            case Mode.doubleNextLevel: {
                Application.LoadLevel( Application.loadedLevel + 2 );
                break;
                }
            case Mode.previousLevel: {
                Application.LoadLevel( Application.loadedLevel - 1 );
                break;
                }
            case Mode.specificLevel: {
                Application.LoadLevel( specificLevelName );
                break;
                }
        }
    }
}
