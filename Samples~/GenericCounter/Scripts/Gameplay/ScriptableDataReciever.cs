using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScriptableDataReciever : MonoBehaviour
{
    // instead of action maybe reference scriptable object to access funks
    public static Action<int> OnScoreChange;
    [SerializeField] ScriptableData data;
    [SerializeField] TMPro.TMP_Text _score;

    private void OnEnable()
    {
        SetScore(data.score);
        ScriptableData.OnScoreChange += SetScore;
    }
    private void OnDisable()
    {
        ScriptableData.OnScoreChange -= SetScore;
    }

    public void SetScore(int value)
    {
        _score.SetText(value.ToString());
    }
}