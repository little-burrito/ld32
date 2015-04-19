using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CashMeter : MonoBehaviour {

    public Image fillBar;
    public Text cashGoalDisplayText;
    public Text currentCashDisplayText;
    public float cashGoal;
    public float currentCash;

    void Update() {
        UpdateCashBar();
    }

    public void setCashGoalText( string goal ) {
        cashGoalDisplayText.text = goal;
    }
    public void setCurrentCashText( string cash ) {
        currentCashDisplayText.text = cash;
    }

    public void UpdateCashBar() {
		if (currentCash < (cashGoal / 2)) {
			fillBar.color = Color.red;
		}else if (currentCash < cashGoal) {
			fillBar.color = Color.yellow;
		} else {
			fillBar.color = Color.green;
		}
		fillBar.fillAmount = Mathf.Min( 1.0f, ( float )( ( float )currentCash / ( float )cashGoal * 0.734f ) );
    }
}
