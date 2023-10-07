using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected float _speed = 4.0f;
    [SerializeField] private Player _targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(Random.Range(-8f, 8f), 8f, 0);
    }


    // Update is called once per frame
    void Update()
    {
        EnemyMovemente();
        EnemyReSpawn();
        //Debug.DrawRay(transform.position, Vector3.up  * 10, Color.green);
    }

    void EnemyMovemente()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    void EnemyReSpawn()
    {
        if (transform.position.y <= -8f)
        {
            transform.position = new Vector3(Random.Range(-8f, 8f), 8f, 0);
            //transform.position = new Vector3(0,8f,0);
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("hit by" + other.transform.name);
        if (other.tag == "Player")
        {
            //other.transform.GetComponent<Player>().Damage();

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            //Debug.Log("hited");
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
