using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   //public or private reference
    //data type (int,float, bool, string)
    //every variable has a name
    //optional value assigned

    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private GameObject _LaserPrefab;
    [SerializeField] private float _FireRate = 0.25f;
    [SerializeField] private float _CanFire = 0.0f;
    [SerializeField] private int _Life = 3;

    private SpawnManager _spawnManager;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0,0,0);

        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("the spawn manager is null");

        }
    }

    // Update is called once per frame
    void Update()
    {
     CalculateMovemente();
     ScreenRestriction();
     LaserShoot();  
    }

    void CalculateMovemente()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");

       transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
       
       transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

    }
    
    void ScreenRestriction()

    {
       // verticalRestriction 

       if (transform.position.y >= 0)
       {
        transform.position = new Vector3(transform.position.x, 0,0);
       }
       else if(transform.position.y <= -3.8f)
       {
        transform.position = new Vector3(transform.position.x, -3.8f,0);
       }

       // horizontalRestriction 
       
       if (transform.position.x > 10.32f)
       {
        transform.position = new Vector3(-10.32f, transform.position.y, 0);
       }
       else if(transform.position.x < -10.32f)
       {
        transform.position = new Vector3(10.32f, transform.position.y, 0);
       }   
    }

    void LaserShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _CanFire)
        {

         _CanFire = Time.time + _FireRate; 

         //Instantiate(_LaserPrefab, transform.position, Quaternion.identity); 
         //Instantiate(_LaserPrefab, new Vector3(transform.position.x, transform.position.y + 0.8f, 0), Quaternion.identity); 
         Instantiate(_LaserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
    }

    public void Damage()
    {
        _Life--;
        //_Life -= 1;
        //_Life = _Life - 1;

        if (_Life < 1)
        {
            _spawnManager.onPlayerDeath();

            Destroy(this.gameObject);
        }
    }
   
}