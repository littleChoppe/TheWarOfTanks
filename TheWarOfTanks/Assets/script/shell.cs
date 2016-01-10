using UnityEngine;
using System.Collections;

public class shell : MonoBehaviour {

	public GameObject explosionEffect;
	public float explosionTimeOff;
	public float explosionRadius;
	public float explosionForce;
	public int damage;

	private LayerMask enemy;

	public void Init(LayerMask enemyLayer){
		enemy = enemyLayer; //让武器类调用此函数初始化，从武器类处获得敌人的层级，武器类获得坦克的队伍计算敌人
	}

	void OnCollisionEnter()
	{
		//爆炸效果
		GameObject obj = Instantiate (explosionEffect, transform.position, transform.rotation) as GameObject;
		Destroy (gameObject);
		Destroy (obj, explosionTimeOff);	//一段时间后把obj销毁

		//爆炸力场

		//子弹碰撞捉到的碰撞器，第一个参数是碰撞位置，第二个参数是捉碰撞器的半径,这个函数返回碰撞器数组
		Collider[] colls = Physics.OverlapSphere (transform.position, explosionRadius, enemy);	//最后一个参数获得层级，即只获取敌人的碰撞器
		Debug.Log (colls.Length);
		if (colls.Length > 0) {
			for(int i=0; i<colls.Length; i++)
			{
				Rigidbody r = colls[i].GetComponent<Rigidbody>();

				//如果获取到地板或者场景里没有刚体的物体其刚体的值为NULL 则不发生爆炸力场
				if (r)
					//AddExplosionForce(爆炸力， 爆炸位置， 爆炸半径);
					r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
				unit u = colls[i].GetComponent<unit>();
				if (u)
					u.applyDamage(damage);
			}
		}

	}
}
