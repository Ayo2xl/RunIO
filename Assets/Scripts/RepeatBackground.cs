using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider2D>().size.x / 2; // Set the repeat width to half the background's width
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < - repeatWidth) // Check if the background has moved past half its width
        {
            transform.position = startPos; // Reset the background to its starting position
        }
    }
}
