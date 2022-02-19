using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLevel : Level {
    [SerializeField] private GameObject start;
    
    public override void Awake() {
        levelComponents = new Queue<LevelComponent>();
        Vector3 spawn = transform.position;
        spawn = SpawnLevelComponent(start, spawn);
        for(int i = 0; i < 4; ++i){
            int f = (int)Random.Range(0, 100f);
            GameObject k = levelComponentsPrefab[f%levelComponentsPrefab.Count];
            spawn = SpawnLevelComponent(k, spawn);
        }
        character.transform.position = transform.position;
        character.Provider = this;
        closerTo = new FCloserTo(0, 1, 0);
    }

}
