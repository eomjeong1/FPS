using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ArrayTest : MonoBehaviour
{
    void Start()
    {
        string[] students = { "1�� �л�", "2�� �л�", "3�� �л�", "4�� �л�", "5�� �л�", "6�� �л�" };
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
        Debug.Log($"���� �ְ� ���� : {max}");
        Debug.Log($"���� ���� ���� : {min}");

        for (int a = 0; a < koreaScores.Length; a++)
        {
            if (koreaScores[a] == min)
            {
                Debug.Log($"���� ���� ������ ��� : {students[a]}");
            }
        }
        for (int b = 0; b < mathScores.Length; b++)
        {
            if (mathScores[b] == max)
            {
                Debug.Log($"���� �ְ� ������ ��� : {students[b]}");
            }
        }
    }
}
