using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] private float angularVelocity = 300f;

    private void Update()
    {
        if(obj)
            obj.transform.Rotate(Vector3.forward * angularVelocity * Time.deltaTime);
    }
}
