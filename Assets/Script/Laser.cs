﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    [SerializeField] private int _shootSpeed = 8;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.up * _shootSpeed * Time.deltaTime);  

      if (transform.position.y >= 8f)
      {
        Destroy(gameObject);
      }
    }
}
