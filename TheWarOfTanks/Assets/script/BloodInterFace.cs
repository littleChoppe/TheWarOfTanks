using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BloodInterFace : MonoBehaviour {

	public unit player;
	public Image healthBar;
	public Text healthLabel;
	
	void Update () {
		healthBar.fillAmount = (float)player.getCurHealth() / (float)player.health;
		healthLabel.text = player.getCurHealth ().ToString ();
	}
}
