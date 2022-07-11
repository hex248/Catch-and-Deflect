using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    string scoreStr;
    [SerializeField] SpriteRenderer[] numberSpriteRenderers;
    [SerializeField] Sprite[] numberSprites;

    void Start()
    {
        
    }

    void Update()
    {
        scoreStr = score.ToString("D3");

        for (int i = 0; i < 3; i++)
        {
            SpriteRenderer sr = numberSpriteRenderers[i];
            int num = scoreStr[i] - '0';
            sr.sprite = numberSprites[num];
        }
    }
}
