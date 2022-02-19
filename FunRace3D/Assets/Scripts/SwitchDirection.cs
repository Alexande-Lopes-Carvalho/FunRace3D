using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDirection : MonoBehaviour {
    // Update is called once per frame
    private void OnTriggerEnter(Collider collision) {
        MoveTo m = collision.gameObject.GetComponent<MoveTo>();
        if(m != null){
            m.Direction = m.Direction*-1;
        }
    }
}
