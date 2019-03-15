using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

  
    public GameObject character;
    public BulletStat bulletStat { get; set; }

    public BulletBehavior()
    {
        bulletStat = new BulletStat(0, 0);
    }

	void Start () {
        Destroy(gameObject, 3.0f);
	}
	
	void Update () {
        transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
            other.GetComponent<MonsterStat>().attacked(bulletStat.damage);
        }   
    }
}
