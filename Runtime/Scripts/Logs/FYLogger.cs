using System;
using UnityEngine;

public class FYLogger : MonoBehaviour
{
    System.IO.StreamWriter logFile;
    [Header("Configuration")]
    [SerializeField] bool isLogToFileEnabled = true;
    [SerializeField] string path = "C:\\Overly\\log.txt";
    [SerializeField] string[] stringsToIgnore = { "Atlas", "SDF" };

    private void OnEnable()
    {
        if (!isLogToFileEnabled)
            return;
        logFile = new System.IO.StreamWriter(path);
        Application.logMessageReceived += Log;
    }

    private void OnApplicationQuit()
    {
        logFile.Dispose();
        logFile = null;
    }

    private void Log(string logString, string stackTrace, LogType type)
    {
        foreach (var str in stringsToIgnore)
        {
            if (logString.Contains(str))
                return;
        }

        try
        {
            switch (type)
            {
                case LogType.Error:
                    logFile.WriteLine($"[{DateTime.Now}] - {logString} -- {stackTrace}");
                    break;
                case LogType.Log:
                    logFile.WriteLine($"[{DateTime.Now}] - {logString}");
                    break;
                case LogType.Warning:
                    logFile.WriteLine($"[{DateTime.Now}] - {logString}");
                    break;
                default:
                    logFile.WriteLine($"[{DateTime.Now}] - {logString} -- {stackTrace}");
                    break;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("##logError:" + e);
        }
    }
}