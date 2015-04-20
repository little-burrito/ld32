using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int invoicesPaid = 0;
	public float cash = 0;
	public int salesCalls = 0;
	public int dirtyCalls = 0;
	public int kills = 0;
	public int textsRead = 0;
	public float[] Invoices;
	public float cashToCome = 0;
	public Colleague[] Colleagues;
	public Gem[] Clippers;
	public SMS[] SMSList;
	private Mobile mobile;
	private CashMeter cashMeter;
	private Dator dator;

	public GameObject clipperWrapper;

	public int InvoicesPaid {
		get { return invoicesPaid; }
	}

	public float Cash
	{
		get { return cash; }
	}

	void Awake () {
		if (mobile == null) {
			GameObject mobileObject = GameObject.FindGameObjectWithTag ("Mobile");
			if (mobileObject != null) {
				Mobile mobileComponent = mobileObject.GetComponent<Mobile> ();
				if (mobileComponent != null) {
					mobile = mobileComponent;
					//pushStory ();
				}
			}
		}
		if (cashMeter == null) {

			GameObject cashMeterObject = GameObject.FindGameObjectWithTag ("CashMeter");
			if (cashMeterObject != null) {
				CashMeter cashMeterComponent = cashMeterObject.GetComponent<CashMeter> ();
				if (cashMeterComponent != null) {
					cashMeter = cashMeterComponent;
				}
			}
		}
		if (dator == null) {
			GameObject datorObject = GameObject.FindGameObjectWithTag ("ComputerText");
			if (datorObject != null) {
				Dator datorComponent = datorObject.GetComponent<Dator> ();
				if (datorComponent != null) {
					dator = datorComponent;
					PushClipper ();
				}
			}
		}
	}
	void Start () {
		GameObject mobileObject = GameObject.FindGameObjectWithTag ("Mobile");
		if ( mobileObject != null) {
			Mobile mobileComponent = mobileObject.GetComponent<Mobile>();
			if ( mobileComponent != null ) {
				mobile = mobileComponent;
				//pushStory();
			}
		}
		GameObject cashMeterObject = GameObject.FindGameObjectWithTag ("CashMeter");
		if ( cashMeterObject != null) {
			CashMeter cashMeterComponent = cashMeterObject.GetComponent<CashMeter>();
			if ( cashMeterComponent != null ) {
				cashMeter = cashMeterComponent;
			}
		}
		GameObject datorObject = GameObject.FindGameObjectWithTag ("ComputerText");
		if ( datorObject != null) {
			Dator datorComponent = datorObject.GetComponent<Dator>();
			if ( datorComponent != null ) {
				dator = datorComponent;
				PushClipper ();
			}
		}

	}

	void Update () {
		pushStory();
	}

	private void addCash(float amount) {
		cash += amount;
		cashMeter.currentCash = cash;
		cashMeter.cashGoal = Invoices[invoicesPaid];
		cashMeter.setCurrentCashText ("$" + cash.ToString());
		PlayerPrefs.SetFloat ("cash", cash);
		cashMeter.setCashGoalText ("$" + Invoices[invoicesPaid]);
		PushClipper ();
	}

	private void removeCash(float amount) {
		cash -= amount;
		Debug.Log ("Current balance: " + cash);
		cashMeter.currentCash = cash;
		cashMeter.cashGoal = Invoices[invoicesPaid];
		cashMeter.setCurrentCashText ("$" + cash.ToString());
		PlayerPrefs.SetFloat ("cash", cash);
		cashMeter.setCashGoalText ("$" + Invoices[invoicesPaid]);
		PushClipper ();
	}

	public void PayInvoice() {
		Debug.Log ("Invoice amount: " + Invoices [invoicesPaid].ToString () + " - Current balance $" + this.cash.ToString ());
		// Enough money?
		if (cash >= Invoices[invoicesPaid]) {
			removeCash (Invoices [invoicesPaid]);
			invoicesPaid++;
			cashMeter.currentCash = cash;
			PlayerPrefs.SetInt ("invoicesPaid", invoicesPaid);
			cashMeter.cashGoal = Invoices[invoicesPaid];
			cashMeter.setCurrentCashText ("$" + cash.ToString());
			cashMeter.setCashGoalText ("$" + Invoices[invoicesPaid]);
			pushStory();
			Debug.Log ("Invoice paid: " + invoicesPaid.ToString () + " - New balance $" + this.cash.ToString());

		} else {
			dator.setScreenTextInvoice ("Your check bounced");
		}
	}

	public void MakeSalesCall() {
		this.addCash (12);
		salesCalls++;
		pushStory ();
		resetInvoiceText ();
	}

	public void MakeDirtyCall() {
		this.removeCash (4);
		dirtyCalls++;
		pushStory ();
		resetInvoiceText ();
	}

	public void Kill() {
		if (invoicesPaid > 0) {
			bool killMade = false;
			Colleague colleague = Colleagues[invoicesPaid-1];
			if (!colleague.Dead) {
				colleague.Dead = true;
				cashToCome = (cashToCome + colleague.cash);
				killMade = true;
				kills++;
				PlayerPrefs.SetInt ("kills", kills);
				// TODO: trigger new scene
				Debug.Log ("You've killed: " + colleague.name);
                Application.LoadLevel( Application.loadedLevel + 1 );
			}
			/*foreach (Colleague colleague in Colleagues) {
				Debug.Log ("Checking if colleague is alive: " + colleague.name + ", dead:" + colleague.Dead);
				if (!colleague.Dead) {
					colleague.Dead = true;
					cashToCome = (cashToCome + colleague.cash);
					killMade = true;
					kills++;
					// TODO: trigger new scene
					Debug.Log ("You've killed: " + colleague.name);
					pushStory();
					break;
				}
			}*/
			if (!killMade) {
				Debug.Log ("They are all dead! Pay your invoices");
			}
		} else {
			Debug.Log ("Make some cash");
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
	private void resetInvoiceText () {
		dator.setScreenTextInvoice("Pay your invoices");
	}
	private void showMessage(SMS message) {
		mobile.SetText (message.Content);
		mobile.senderName.text = message.Sender;
		mobile.Activate ();
		cash = cash + message.Transaction;
	}
	public void PushClipper() {
		if (invoicesPaid > 0) {
			if (invoicesPaid == kills){
				clipperWrapper.SetActive(false);
			}else{
				clipperWrapper.SetActive(true);
			}
			if (invoicesPaid > 3) {
				//GameObject.FindGameObjectWithTag ("PayInvoice").SetActive(false);
				// you won!
			}
		}
		Gem lastShownClipper = Clippers[0];
		lastShownClipper.Seen = true;
		for (int i = 0; i < Clippers.Length; i++) {
			Gem clipper = Clippers[i];
			if (clipper.MinimumKills <= kills &&
			    clipper.MinimumInvoices <= invoicesPaid &&
			    clipper.MinimumDirtyCalls <= dirtyCalls &&
			    clipper.MinimumCash <= cash &&
			    clipper.MinimumSalesCalls <= salesCalls) {
				clipper.Seen = true;
				lastShownClipper = clipper;
			}
		}
		//Debug.Log ("update computer with text: " + lastShownClipper.Content);
		dator.setScreenText (lastShownClipper.Content);
	}
	public void pushStory() {
		for (int i = 0; i < SMSList.Length; i++) {
			SMS message = SMSList[i];
			if (message != null) {
				if (!message.Seen &&
				    message.MinimumKills <= kills &&
				    message.MinimumInvoices <= invoicesPaid &&
				    message.MinimumDirtyCalls <= dirtyCalls &&
				    message.MinimumSalesCalls <= salesCalls) {
					Debug.Log("message to be shown: " + message.Content);
					message.Seen = true;
					textsRead++;
					PlayerPrefs.SetInt ("textsRead", textsRead);
					showMessage(message);
					if (message.cashTrigger && (cashToCome > 0)) {
						this.addCash(cashToCome);
						cashToCome = 0;
					}
					break;
				}
			}
		}
		if (dator != null) {
			PushClipper ();
		}
		
	}
}
