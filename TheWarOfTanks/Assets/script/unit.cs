using UnityEngine;
using System.Collections;

public enum Team {
	Green, Blue
}

public class unit : MonoBehaviour {

	public int health = 100;
	public Team team;
	public GameObject deadEffect;

	public void applyDamage(int damage)
	{
		if (damage < health)
			health -= damage;
		else
			destruct ();
	}

	public void destruct()
	{
		if (deadEffect)
			Instantiate (deadEffect, transform.position, transform.rotation);

		Destroy (gameObject);
	}
}
