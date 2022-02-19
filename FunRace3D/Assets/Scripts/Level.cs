using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour, IPointProvider {
    [SerializeField] private PathFollower character;
    [SerializeField] private List<GameObject> levelComponentsPrefab;
    private List<LevelComponent> levelComponents;

    // Start is called before the first frame update
    void Awake() {
        levelComponents = new List<LevelComponent>();
        Vector3 spawn = transform.position;
        foreach(GameObject k in levelComponentsPrefab){
            GameObject g = Instantiate(k);
            LevelComponent l = g.GetComponent<LevelComponent>();
            g.transform.position = spawn-l.GetStart();
            levelComponents.Add(l);
            spawn = g.transform.position+(l.GetEnd()-l.GetStart());
        }
        character.transform.position = transform.position;
        character.Provider = this;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
