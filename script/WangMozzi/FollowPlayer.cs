using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 7, -8);
        }
  
    }
}
