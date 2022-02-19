using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCloserTo {
    private static double CONST = (((System.Math.Tanh((375+86)*0.006)-System.Math.Tanh(86*0.006))/(1-System.Math.Tanh(86*0.006))));
    private float timeCount, duration, objective, toAdd;
    public FCloserTo(float _duration, float _objective, float _toAdd){
        duration = _duration;
        objective = _objective;
        toAdd = _toAdd;
    }

    public float GetValue(float deltaTimeMs){
        timeCount += deltaTimeMs;
        double value = ( (System.Math.Tanh( ( (timeCount/ (duration) )*375+86)*0.006 ) -System.Math.Tanh(86*0.006) ) / (1-System.Math.Tanh(86*0.006)) ) / CONST;
        //double value = (timeCount/duration);
        //Debug.Log(value + " " + timeCount + " " + duration);
        return (float)(value*objective+toAdd);
    }
}
