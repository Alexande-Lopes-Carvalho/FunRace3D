using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedPosition : CameraState {
    public override Quaternion Rotation(Transform player){
        return transform.rotation;
    }
    public override Vector3 Position(Transform player){
        return transform.position;
    }
}
