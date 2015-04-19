using UnityEngine;
using System.Collections;

public class Dator : MonoBehaviour {

    public TextMesh screenText;
	public TextMesh screenTextInvoice;

    public void setScreenText( string text ) {
        screenText.text = text;
    }
	public void setScreenTextInvoice( string text ) {
		screenTextInvoice.text = text;
	}
}
