using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _timeToSpawn = 5.0f;
    [SerializeField] private GameObject _enemyContainer;

    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 positionToSpawn = new Vector3(Random.Range(-8f, 8f), 8f, 0);

            GameObject newEnemy = Instantiate(_enemyPrefab, positionToSpawn, Quaternion.identity);

            //O.parent serve pra colocar um objeto dentro de outro criando uma hierarquia.
            newEnemy.transform.parent = _enemyContainer.transform;

            yield return new WaitForSeconds(_timeToSpawn);
        }

        ///pio destroi tudo se perder
        //if (_stopSpawning == true)
        //{
            //Destroy(this.gameObject);
        //}
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
