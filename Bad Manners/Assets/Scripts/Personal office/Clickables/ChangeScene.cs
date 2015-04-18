using UnityEngine;
using System.Collections;

public class ChangeScene : Clickable {
    enum Mode {
        nextLevel,
        previousLevel,
        specificLevel
    }
    public Mode mode;
    public string specificLevelName;
    protected override void Action() {
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
