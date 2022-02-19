using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {
    [SerializeField] private List<Vector3> rawPoints;
    public List<Vector3> RawPoints{get => rawPoints; set{ RefreshBezier(); 
                                                          rawPoints = value;}}

    private List<Vector3> points;
    public List<Vector3> Points{get => rawPoints;}

    [SerializeField] private float maxRadiusBezier = 1.0f;
    private int sample = 3;
    private void Awake(){
        for(int i = 0 ; i < rawPoints.Count; ++i){
            rawPoints[i] = rawPoints[i].x*transform.right + rawPoints[i].y*transform.up + rawPoints[i].z*transform.forward + transform.position;
        }
        RefreshBezier();
    }

    // Start is called before the first frame update
    private void Start() {
        
    }

    // Update is called once per frame
    private void Update() {
        
    }

    private List<Vector3> ComputeBezier(Vector3 a, Vector3 b, Vector3 c){
        Vector3 ab = b-a, bc = c-b;
        float radius = Mathf.Min(Mathf.Min(ab.magnitude, bc.magnitude), maxRadiusBezier);
        Vector3 start;
        ab = ab.normalized*radius;
        bc = bc.normalized*radius;
        start = b-ab;
        List<Vector3> res = new List<Vector3>();
        int total = sample+2;
        for(int i = 0; i < total; ++i){
            float coef = (i/(total-1.0f));
            Vector3 av = start+ab*coef;
            Vector3 bv = start+ab*1+bc*coef;
            Vector3 current = bv-av;
            res.Add(av+current*coef);
            //Debug.Log(coef + " " + i + " " + total + " " + (i/(total-1.0f)) + " " + av + " " + bv + " " + current);
        }
        return res;
    }

    public List<Vector3> ComputeBezier(List<Vector3> raw){
        List<Vector3> res = new List<Vector3>();
        int i = 0;
        for(i = 2; i < raw.Count; i+=2){
            res.Add(raw[i-2]);
            List<Vector3> p = ComputeBezier(raw[i-2], raw[i-1], raw[i]);
            foreach(Vector3 k in p){
                res.Add(k);
            }
            res.Add(raw[i]);
        }
        for(i = i-2; i < raw.Count; ++i){
            res.Add(raw[i]);
        }
        return res;
    }

    private void RefreshBezier(){
        points = ComputeBezier(rawPoints);
    }
}
