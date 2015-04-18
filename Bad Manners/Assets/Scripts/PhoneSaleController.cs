using UnityEngine;
using System.Collections;

public class PhoneSaleController : Clickable {

	protected override void Action ()
	{
		Player player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		player.MakeSalesCall ();
	}
}
