using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Tables;

public class FYLocaleText : MonoBehaviour
{
    [SerializeField] LocalizeStringEvent _localizeStringEvent;
    [SerializeField] string _table;
    [SerializeField] string _key;
    private void Awake()
    {
        TryGetComponent(out _localizeStringEvent);
        SetLocalizeStringTable();
    }

    public void SetLocalizeStringKey(string key)
    {
        _localizeStringEvent.StringReference.TableEntryReference = key;
    }
    public void SetLocalizeStringTable(string table)
    {
        _localizeStringEvent.StringReference.SetReference((TableReference)table, (TableEntryReference)_key);
    }

    public void SetLocalizeStringTable()
    {
        _localizeStringEvent.StringReference.SetReference((TableReference)_table, (TableEntryReference)_key);
    }
}