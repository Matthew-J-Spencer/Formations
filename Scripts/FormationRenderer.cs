using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationRenderer : MonoBehaviour {
    private FormationBase _formation;
    public FormationBase Formation {
        get {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    [SerializeField] private Vector3 _unitGizmoSize;
    [SerializeField] private Color _gizmoColor;

    // Instead of just drawing gizmos, you could create an 'Army' script which would actually spawn the units in the positions
    // returned by Formation.EvaluatePoints
    private void OnDrawGizmos() {
        if (Formation == null || Application.isPlaying) return;
        Gizmos.color = _gizmoColor;

        foreach (var pos in Formation.EvaluatePoints()) {
            Gizmos.DrawCube(transform.position + pos + new Vector3(0, _unitGizmoSize.y * 0.5f, 0), _unitGizmoSize);
        }
    }
}