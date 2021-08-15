using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FormationBase : MonoBehaviour {
    [SerializeField] [Range(0, 1)] protected float _noise = 0;
    [SerializeField] protected float Spread = 1;
    public abstract IEnumerable<Vector3> EvaluatePoints();

    public Vector3 GetNoise(Vector3 pos) {
        var noise = Mathf.PerlinNoise(pos.x * _noise, pos.z * _noise);

        return new Vector3(noise, 0, noise);
    }
}