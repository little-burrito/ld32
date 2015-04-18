using UnityEngine;
using System.Collections;

public class ComputerController : Clickable {

	protected override void Action() {
		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

		// TODO: Uppdatera topplistan med kollegors stats

		// Kill next colleague
		player.Kill();
		
		// TODO: Leave computer and hide body

	}

}
