using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OWUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMozzi()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnParking()
    {
        SceneManager.LoadScene("Parking Main");
    }

    public void OnFPS()
    {
        SceneManager.LoadScene("Defense Main");

    }
}
