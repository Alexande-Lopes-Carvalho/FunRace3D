using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTo : MonoBehaviour {
    [SerializeField] private Vector3 v;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider collision) {
        Debug.Log("pass " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Enemy"){
            collision.transform.position += v;
        }
    }
}
