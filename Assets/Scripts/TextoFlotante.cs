using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoFlotante : MonoBehaviour
{
    private Transform mainCam;
    private Transform _unit;
    private Transform _worldSpaceCanvas;

    public Vector3 offset;
    
    void Awake()
    {
        mainCam = Camera.main.transform;
        _unit = transform.parent;
        _worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
        gameObject.name = transform.parent.name + "Text";
        transform.SetParent(_worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.position);
        transform.position = _unit.position + offset;
    }
}
