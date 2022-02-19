using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollide : MonoBehaviour {
    // Start is called before the first frame update
    void Start(){
        foreach(Transform child in transform){
            child.gameObject.AddComponent(typeof(KillOnCollide));
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player"){
            LevelManager.Instance.EndLevel();
        }
    }
}
