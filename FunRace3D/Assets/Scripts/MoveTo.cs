using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;

    // Update is called once per frame
    void FixedUpdate(){
        transform.position += direction*speed*Time.deltaTime;
    }
}
