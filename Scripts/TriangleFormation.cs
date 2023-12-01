using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleFormation : FormationBase {
    
    [SerializeField] private int _unitDepth = 5;
    [SerializeField] private bool _hollow = false;
    [SerializeField] private float _nthOffset = 0;

    public override IEnumerable<Vector3> EvaluatePoints() {
        var middleOffset = new Vector3(0, 0, _unitDepth * 0.5f);

        for (int z = 0; z < _unitDepth; z++){
            for (var x = z * -1; x <= z; x++){
                if (_hollow && z < _unitDepth - 1 && x > z * -1 && x < z) continue;  
                
                    var pos = new Vector3(x + (z % 2 == 0 ? 0 : _nthOffset) , 0, z);

                    pos -= middleOffset;

                    pos += GetNoise(pos);

                    pos *= Spread;

                    yield return pos;
                
            }
        }
    }
}