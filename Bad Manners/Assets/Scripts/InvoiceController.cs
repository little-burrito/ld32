using UnityEngine;
using System.Collections;

public class InvoiceController : Clickable {

	protected override void Action () {
		Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		player.PayInvoice ();
	}
}
