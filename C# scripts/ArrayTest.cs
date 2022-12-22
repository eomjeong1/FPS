using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ArrayTest : MonoBehaviour
{
    void Start()
    {
        string[] students = { "1번 학생", "2번 학생", "3번 학생", "4번 학생", "5번 학생", "6번 학생" };
        int[] koreaScores = { 50, 60, 75, 54, 80, 67 };
        int[] mathScores = { 90, 86, 60, 75, 70, 65 };
        int length = students.Length;

        int min = 0;
        int max = 0;

        for (int i = 0; i < 6; i++)
        {
            if (min > koreaScores[i])
            {
                min = koreaScores[i];

            }
            if (max < mathScores[i])
            {
                max = mathScores[i];

            }
        }
        Debug.Log($"수학 최고 점수 : {max}");
        Debug.Log($"국어 최하 점수 : {min}");

        for (int a = 0; a < koreaScores.Length; a++)
        {
            if (koreaScores[a] == min)
            {
                Debug.Log($"국어 최하 점수인 사람 : {students[a]}");
            }
        }
        for (int b = 0; b < mathScores.Length; b++)
        {
            if (mathScores[b] == max)
            {
                Debug.Log($"수학 최고 점수인 사람 : {students[b]}");
            }
        }
    }
}
