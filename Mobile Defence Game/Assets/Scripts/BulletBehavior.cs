using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

  
    public GameObject character;
    public BulletStat bulletStat { get; set; }

    public float activeTime = 3.0f;

    public BulletBehavior()
    {
        bulletStat = new BulletStat(0, 0);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }
    //오브젝트 풀링 기법과 함께 쓰면 효율적. 
    private void OnEnable()
    {
        StartCoroutine(BulletInactive(activeTime));
    }

    IEnumerator BulletInactive(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }

    void Start () {
        Spawn();
	}
	
	void Update () {
            transform.Translate(Vector2.right * bulletStat.speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Monster")
        {
            gameObject.SetActive(false);
            other.GetComponent<MonsterStat>().attacked(bulletStat.damage);
        }   
    }
}
