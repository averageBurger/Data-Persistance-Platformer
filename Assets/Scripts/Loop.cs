using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private float startPos;
    private float endPos;

    private void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -40.4f)
        {
            transform.position = new Vector3(startPos, transform.position.y, transform.position.z);
        }
    }
}
