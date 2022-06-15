using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScriptableData", menuName = "Framly/ScriptableData", order = 1)]
public class ScriptableData : ScriptableObject
{
    // TODO: generate variable name based on script name prefix
    public static Action<int> OnScoreChange;
    public int score;
    private void OnEnable()
    {
       
    }
    private void Awake()
    {
        LoadVariables();
    }

    private void OnDisable()
    {
        SaveVariables();
    }

    public void SetValue(int value)
    {
        if (!CheckIsValueValid(value))
            return;
        score = value;
        OnScoreChange?.Invoke(score);
    }
    public void AddValue(int value)
    {
        if (!CheckIsValueValid(value))
            return;
        score += value;
        OnScoreChange?.Invoke(score);
    }
    public bool CheckIsValueValid(int value)
    {
        int tempScore = score + value;
        if (tempScore < -5)
            return false;
        if (tempScore < 100)
            return true;
        return false;
    }
    public void SaveVariables()
    {
        PlayerPrefs.SetInt("score", score);
    }
    public void LoadVariables()
    {
        score = PlayerPrefs.GetInt("score", score);
    }
}