using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Oscillator : MonoBehaviour
{
    
    [SerializeField]
    private float _oscillationMinFrequency = 2;
    
    [SerializeField]
    private float _oscillationMaxFrequency = 5;

    private float _oscillationFrequency = 3;

    [SerializeField] 
    private float _oscillationAmplitude = .2f;

    [SerializeField] 
    private Vector2 _oscillationVector = new Vector2(0f, 1f);
    

    [SerializeField] 
    private Vector2 _oscillationoffset = new Vector2(0, .5f);


    private void Awake()
    {
        _oscillationFrequency = Random.Range(_oscillationMinFrequency, _oscillationMaxFrequency);
    }

    void Update()
    {
        float oscillation = Mathf.Sin(Time.time * _oscillationFrequency) * _oscillationAmplitude;
        Vector2 currentOscillation = _oscillationVector * oscillation;
        transform.position = (Vector2)transform.parent.position + _oscillationoffset + currentOscillation;
    }
    
    #region UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
            
        Gizmos.DrawRay((Vector2)transform.parent.position + _oscillationoffset, _oscillationVector * _oscillationAmplitude);
        Gizmos.DrawRay((Vector2)transform.parent.position + _oscillationoffset, -_oscillationVector * _oscillationAmplitude);
    }

    #endregion
}
