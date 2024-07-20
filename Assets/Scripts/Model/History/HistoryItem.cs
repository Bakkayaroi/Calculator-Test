using System;
using UnityEngine;

namespace Model.History
{
    [Serializable]
    public class HistoryItem
    {
        [SerializeField] public bool IsError;
        [SerializeField] public string Value;
    }
}