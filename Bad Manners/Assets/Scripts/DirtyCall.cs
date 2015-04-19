using UnityEngine;
using System.Collections;

public class DirtyCall : Clickable {

	protected override void Action () {
		Player player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		player.MakeDirtyCall ();
	}
}
