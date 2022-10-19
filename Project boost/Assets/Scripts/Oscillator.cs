using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 StartingPosition;
    [SerializeField]Vector3 MovementVector;
    float MovementFactor;
    [SerializeField] float Period = 8f;

    // Start is called before the first frame update
    void Start()
    {
       StartingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Period <= Mathf.Epsilon) { return; }
        const float tau = Mathf.PI * 2;             //constant Value of 6.283...
        float cycles = Time.time / Period;          //Grows over time
        float RawSinWave = Mathf.Sin(cycles * tau); //-1 to 1
        MovementFactor = (RawSinWave + 1f) /2f;     //Recalculates so it goes from 0 to 1 instead
        Vector3 offset = MovementVector * MovementFactor;
        transform.position = StartingPosition + offset;
    }
}
