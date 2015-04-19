using UnityEngine;
using System.Collections;

public class Dator : MonoBehaviour {

    public TextMesh screenText;

    public void setScreenText( string text ) {
        screenText.text = text;
    }
}
