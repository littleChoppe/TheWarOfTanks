using UnityEngine;
using System.Collections;

public class tankWeapon : MonoBehaviour {

	public GameObject shell;	//生成炮弹
	public float shootPower = 10;	//炮弹发射的力
	public Transform shootPoint; //炮弹发射的位置
	public float shootCoolDown = 1;

	private bool isWeaponReady = true;
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
		if (!isWeaponReady)
			return;
		GameObject newShell = Instantiate (shell, shootPoint.position, shootPoint.rotation) as GameObject;
		newShell.GetComponent<shell> ().Init (enemyLayer);	//获取新创建的对象中的脚本中的初始化
		Rigidbody r = newShell.GetComponent<Rigidbody> ();
		r.velocity = shootPoint.forward * shootPower;
		audioSorce.Play ();
		isWeaponReady = false;	//刚发完一炮，休息一下
		StartCoroutine (WeaponCoolDown ());		//这个Shoot这个函数挂起一段时间
	}

	IEnumerator WeaponCoolDown()	//这是一个协程
	{
		yield return new WaitForSeconds (shootCoolDown);	//挂起一段时间后回到shoot()函数
		isWeaponReady = true;
	}
}
