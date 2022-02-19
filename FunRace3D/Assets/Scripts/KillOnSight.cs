using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnSight : MonoBehaviour {
    [SerializeField] private float angleOfViewDegree;
    public float AngleOfViewDegree{get => angleOfViewDegree;}
    private float angleOfViewRadians;
    [SerializeField] private float distOfView;
    public float DistOfView{get => distOfView;}
    private float sqrDistOfView;
    [SerializeField] private Vector3 offset;
    public Vector3 Offset{get => offset;}
    // Start is called before the first frame update
    void Start() {
        sqrDistOfView = distOfView*distOfView; 
        angleOfViewRadians = Mathf.Deg2Rad*angleOfViewDegree;
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log("pass " + LevelManager.Instance.Players.Count);
        foreach(Character k in LevelManager.Instance.Players){
            //Debug.Log("passa");
            Vector3 v = k.transform.position-transform.position;
            if(v.sqrMagnitude > sqrDistOfView ){
                continue;
            }
            //Debug.Log("passb");
            if(Mathf.Acos(Mathf.Min(Mathf.Max(Vector3.Dot(v.normalized, transform.forward), -1), 1)) > angleOfViewRadians){
                continue;
            }
            //Debug.Log("passc");
            RaycastHit hit;
            if(Physics.Raycast(transform.position+offset, v, out hit, distOfView) && hit.transform == k.transform){
                Debug.Log("Saw ! ");
                Debug.Log(v.sqrMagnitude + " " + sqrDistOfView + " " + v.normalized + " " + transform.forward + " " + angleOfViewRadians + " " + angleOfViewDegree + " " + Vector3.Dot(v.normalized, transform.forward));
                LevelManager.Instance.EndLevel(false);
            }
            //Debug.Log("passd");
        }
    }
}
