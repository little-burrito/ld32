using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private int invoicesPaid = 0;
	private float cash = 0;
	private int salesCalls = 0;
	private int dirtyCalls = 0;
	public float[] Invoices = { 1000, 1500, 3000, 10000, 50000 };
	public Colleague[] Colleagues;
	public SMS[] SMSList;
	private Mobile mobile;

	public int InvoicesPaid {
		get { return invoicesPaid; }
	}

	public float Cash
	{
		get { return cash; }
	}
	void Awake () {
		GameObject mobileObject = GameObject.FindGameObjectWithTag ("Mobile");
		if ( mobileObject != null) {
			Mobile mobileComponent = mobileObject.GetComponent<Mobile>();
			if ( mobileComponent != null ) {
				mobile = mobileComponent;
			}
		}
	}
	void Start () {
		GameObject mobileObject = GameObject.FindGameObjectWithTag ("Mobile");
		if ( mobileObject != null) {
			Mobile mobileComponent = mobileObject.GetComponent<Mobile>();
			if ( mobileComponent != null ) {
				mobile = mobileComponent;
				pushStory();
			}
		}
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
		// Enough money?
		if (cash >= Invoices[invoicesPaid]) {
			removeCash (Invoices [invoicesPaid]);
			invoicesPaid++;
			pushStory();
			Debug.Log ("Invoice paid: " + invoicesPaid.ToString () + " - New balance $" + this.cash.ToString());
		} else {
			Debug.Log ("Not enough money - Current balance $" + this.cash.ToString());
		}
	}

	public void MakeSalesCall() {
		this.addCash (10);
		salesCalls++;
		pushStory ();
	}

	public void MakeDirtyCall() {
		this.removeCash (15);
		dirtyCalls++;
		pushStory ();
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

	public void ReadLastMessage () {
		SMS lastMessage = SMSList[0];
		for (int i = 0; i < SMSList.Length; i++) {
			SMS message = SMSList [i];
			if (message.Seen &&
				message.Priority > lastMessage.Priority) {
				lastMessage = message;
			}
		}
		this.showMessage(lastMessage);
	}
	private void pushStory() {
		SMS lastMessage = SMSList[0];
		for (int i = 0; i < SMSList.Length; i++) {
			SMS message = SMSList[i];
			if (!message.Seen &&
			    message.MinimumInvoices <= invoicesPaid &&
			    message.MinimumDirtyCalls <= dirtyCalls &&
			    message.MinimumSalesCalls <= salesCalls) {
				message.Seen = true;
				this.showMessage(message);
				break;
			}
		}
		
	}

	private void showMessage(SMS message) {
		mobile.SetText (message.Content);
		mobile.Activate ();
		cash = cash + message.Transaction;
	}
}
