using UnityEngine;
using System.Collections;

public class ClickToChangeScene : Clickable {

    public ChangeScene changeSceneScript;

    protected override void Action() {
        changeSceneScript.Trigger();
    }
}
