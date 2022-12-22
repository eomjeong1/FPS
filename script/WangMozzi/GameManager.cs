using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static Moving playerCharacter;
    public CubeEnemy[] enemys;
    public Text txt;
    public float LimitTime;
    public Text text_Timer;
    bool SetActive;
    public GameObject player;
    public Button Retry, Main, Next;
    // Start is called before the first frame update

    void Awake()
    {
        playerCharacter = player.GetComponent<Moving>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bool isClear = true;

        for (int i = 0; i < enemys.Length; i++)
        {
            if (enemys[i] != null)
            {
                isClear = false;
            }
        }

        if (isClear)
        {
            StageClear();
        }


        if (isClear == false && player != null)
        {
            LimitTime -= Time.deltaTime;
            text_Timer.text = "남은 시간 : " + Mathf.Round(LimitTime);
            if (LimitTime <= 0)
            {
                text_Timer.text = "남은 시간 : 0";

                Timeover();

            }
        }        
    }
    public void Timeover()
    {
        txt.gameObject.SetActive(true);
        txt.text = "Time Over";
        Destroy(player);
        Retry.gameObject.SetActive(true);
        Main.gameObject.SetActive(true);

    }
    public void Gameover()
    {
        txt.gameObject.SetActive(true);
        txt.text = "Game Over";
        Destroy(player);
        Retry.gameObject.SetActive(true);
        Main.gameObject.SetActive(true);

    }
    public void StageClear()
    {
        txt.gameObject.SetActive(true);
        txt.text = "Stage Clear";
        Destroy(player);
        Next.gameObject.SetActive(true);
        Main.gameObject.SetActive(true);

    }
    public void NextStage()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
