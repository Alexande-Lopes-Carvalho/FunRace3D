using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : CameraState {
    [SerializeField] private Vector3 offset, lookOffset;
    public override Quaternion Rotation(Transform player){
        return Quaternion.LookRotation(player.position+lookOffset-(player.position+offset));
    }
    public override Vector3 Position(Transform player){
        return player.position+offset;
    }
}
