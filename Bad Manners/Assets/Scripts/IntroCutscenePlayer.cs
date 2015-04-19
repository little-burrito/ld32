using UnityEngine;
using System.Collections;

public class IntroCutscenePlayer : MonoBehaviour {

    private Animator anim;
    private AudioSource sound;
    public GameObject[] objectsToDisableAfterCutscene;
    public GameObject[] objectsToEnableAfterCutscene;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        foreach ( GameObject obj in objectsToEnableAfterCutscene ) {
            obj.SetActive( false );
        }
	}

    void PlaySound() {
        sound.Play();
    }

    void CutsceneFinished() {
        foreach ( GameObject obj in objectsToDisableAfterCutscene ) {
            obj.SetActive( false );
        }
        foreach ( GameObject obj in objectsToEnableAfterCutscene ) {
            obj.SetActive( true );
        }
    }
}
