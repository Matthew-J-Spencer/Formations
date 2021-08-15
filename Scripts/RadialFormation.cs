using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadialFormation : FormationBase {
    [SerializeField] private int _amount = 10;
    [SerializeField] private float _radius = 1;
    [SerializeField] private float _radiusGrowthMultiplier = 0;
    [SerializeField] private float _rotations = 1;
    [SerializeField] private int _rings = 1;
    [SerializeField] private float _ringOffset = 1;
    [SerializeField] private float _nthOffset = 0;

    public override IEnumerable<Vector3> EvaluatePoints() {
        var amountPerRing = _amount / _rings;
        var ringOffset = 0f;
        for (var i = 0; i < _rings; i++) {
            for (var j = 0; j < amountPerRing; j++) {
                var angle = j * Mathf.PI * (2 * _rotations) / amountPerRing + (i % 2 != 0 ? _nthOffset : 0);

                var radius = _radius + ringOffset + j * _radiusGrowthMultiplier;
                var x = Mathf.Cos(angle) * radius;
                var z = Mathf.Sin(angle) * radius;

                var pos = new Vector3(x, 0, z);

                pos += GetNoise(pos);

                pos *= Spread;

                yield return pos;
            }

            ringOffset += _ringOffset;
        }
    }
}