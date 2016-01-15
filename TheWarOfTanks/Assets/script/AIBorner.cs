using UnityEngine;
using System.Collections;

public class AIBorner : MonoBehaviour {

	public GameObject AItank;
	public float bornCoolDown;

	void Start()
	{
		StartCoroutine (Born());
	}

	IEnumerator Born()
	{
		while (enabled) {
			Instantiate(AItank, transform.position, transform.rotation);
			yield return new WaitForSeconds(bornCoolDown);
		}
	}
}
