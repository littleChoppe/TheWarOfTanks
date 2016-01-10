using UnityEngine;
using System.Collections;

public class tankWeapon : MonoBehaviour {

	public GameObject shell;	//生成炮弹
	public float shootPower = 30;	//炮弹发射的力
	public Transform shootPoint; //炮弹发射的位置

	private AudioSource audioSorce;
	private LayerMask enemyLayer;

	void Start()
	{
		audioSorce = GetComponent<AudioSource> ();
	}

	public void Init(Team team)
	{
		enemyLayer = layerManager.getEnemyLayer (team);	//判断是否为敌人
	}

	public void shoot()
	{
		GameObject newShell = Instantiate (shell, shootPoint.position, shootPoint.rotation) as GameObject;
		newShell.GetComponent<shell> ().Init (enemyLayer);	//获取新创建的对象中的脚本中的初始化
		Rigidbody r = newShell.GetComponent<Rigidbody> ();
		r.velocity = shootPoint.forward * shootPower;
		audioSorce.Play ();
	}
}
