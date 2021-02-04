using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = this.GetComponent<Transform>();
        this.gameObject.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
    }
}
