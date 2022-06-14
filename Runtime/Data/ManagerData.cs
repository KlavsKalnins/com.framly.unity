using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerData : MonoBehaviour
{
    // EXAMPLE of Data retrieve
    
    [System.Serializable]
    public class Lang
    {
        public string Actions;
        public string Anthem;
    }

    [System.Serializable]
    public class File
    {
        public string AudioName;
        public string SpriteName;
    }

    [System.Serializable]
    public class Root
    {
        public List<Lang> LV;
        public List<Lang> EN;
        public List<File> Files;
    }
    [SerializeField] private TextAsset _dataAsset;
    public Root data;

    private void OnEnable() => data = Framly.DataSet.CreateDataSet<Root>(_dataAsset);
}
