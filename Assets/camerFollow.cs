using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerFollow : MonoBehaviour
{
    [SerializeField] private GameObject theThingtoFollow;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = theThingtoFollow.transform.position + new Vector3(-3, 1, -10);
    }
}
