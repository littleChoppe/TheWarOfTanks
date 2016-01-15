using UnityEngine;
using System.Collections;

public enum Team {
	Green, Blue, Purple, Red
}

public class unit : MonoBehaviour {

	public int health = 100;
	public Team team;
	public GameObject deadEffect;

	private int curHealth;

	public void Start()
	{
		curHealth = health;
	}

	public int getCurHealth()
	{
		return curHealth;
	}

	public void applyDamage(int damage)
	{
		if (damage < curHealth)
			curHealth -= damage;
		else
			destruct ();
	}

	public void destruct()
	{
		curHealth = 0;
		if (deadEffect)
			Instantiate (deadEffect, transform.position, transform.rotation);

		Destroy (gameObject);
	}
}
