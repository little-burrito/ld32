using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int invoicesPaid = 0;
	private float cash = 0;
	private int salesCalls = 0;
	private int dirtyCalls = 0;
	public float[] Invoices = { 1000, 1500, 3000, 10000, 50000 };
	public Colleague[] Colleagues;

	public int InvoicesPaid {
		get { return invoicesPaid; }
	}

	public float Cash
	{
		get { return cash; }
	}

	void Start () {
	}

	void Update () {
		
	}

	private void addCash(float amount) {
		cash += amount;
	}

	private void removeCash(float amount) {
		cash -= amount;
	}

	public void PayInvoice() {
		Debug.Log ("Invoice amount: " + Invoices [invoicesPaid].ToString () + " - Current balance $" + this.cash.ToString ());
		// Enogugh money?
		if (cash >= Invoices[invoicesPaid]) {
			removeCash (Invoices [invoicesPaid]);
			invoicesPaid++;
			Debug.Log ("Invoice paid: " + invoicesPaid.ToString () + " - New balance $" + this.cash.ToString());
		} else {
			Debug.Log ("Not enough money - Current balance $" + this.cash.ToString());
		}
	}

	public void MakeSalesCall() {
		this.addCash (10);
		salesCalls++;
	}

	public void MakeDirtyCall() {
		this.removeCash (15);
		dirtyCalls++;
	}

	public void Kill() {
		if (invoicesPaid > 0) {
			bool killMade = false;
			foreach (Colleague colleague in Colleagues) {
				Debug.Log ("Checking if colleague is alive: " + colleague.name + ", dead:" + colleague.Dead);
				if (!colleague.Dead) {
					colleague.Dead = true;
					this.addCash (colleague.cash);
					killMade = true;
					Debug.Log ("You've killed: " + colleague.name);
					break;
				}
			}
			if (!killMade) {
				Debug.Log ("They are all dead! Pay your invoices");
			}
		} else {
			Debug.Log ("You need to pay an invoice. Come back later!");
		}
	}
}
