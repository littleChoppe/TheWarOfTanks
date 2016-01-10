using UnityEngine;
using System.Collections;

public class tank : unit {

	public float moveSpeed = 7;
	public float rotateSpeed = 150;
	private tankWeapon tw;

	void Start()
	{
		tw = GetComponent<tankWeapon> ();
		tw.Init (team); //判断是否为敌人
	}

	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis ("Horizontal1"); 	//这个输入函数会根据按键返回一个【1，-1】之间的值
		float vertical = Input.GetAxis ("Vertical1");

		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime * vertical);
		transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime * horizontal);

		if (Input.GetKeyDown (KeyCode.Space))
			tw.shoot ();

//		if (Input.GetKey (KeyCode.UpArrow)) {
//			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
//		}
//
//		if (Input.GetKey (KeyCode.DownArrow)) {
//			transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
//		}
//	
//		if (Input.GetKey (KeyCode.LeftArrow)) {
//			transform.Rotate (Vector3.down * rotateSpeed * Time.deltaTime);
//		}
//
//		if (Input.GetKey (KeyCode.RightArrow)) {
//			transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
//		}
	}
}
