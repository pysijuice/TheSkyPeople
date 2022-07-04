using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour
{
    [SerializeField] float speedY;
    [SerializeField] float frequency;
    [SerializeField] float magnitude;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }
    void Update()
    {
        transform.Rotate(0, speedY * Time.deltaTime, 0);
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency)*magnitude;
    }
}
