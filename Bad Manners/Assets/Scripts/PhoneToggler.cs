using UnityEngine;
using System.Collections;

public class PhoneToggler : Clickable {

	protected override void Action () {
		Player player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		player.ReadLastMessage ();
	}
}
