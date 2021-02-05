using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.position;
    }

    public void ResetPos()
    {
        gameObject.transform.position = originalPos;
    }
}
