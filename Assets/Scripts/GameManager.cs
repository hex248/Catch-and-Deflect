using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public float rotationSpeed = 5.0f;
    public int ChangeScore(int amount)
    {
        score.score += amount;
        if (score.score < 0) score.score = 0;
        return score.score;
    }
}
