using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EnemyRival();
    }

    // Update is called once per frame
    public void EnemyRival()
    {
        Object enemy = Resources.Load("CubeEnemy");

        Random.Range(0, 10);


        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-10, 10.0f);
            float z = Random.Range(-10, 10.0f);

            Instantiate(enemy, new Vector3(x, 0.2f, z), Quaternion.identity);

        }
    }

}
