using System;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class HistoryItem
    {
        [SerializeField] public bool IsError;
        [SerializeField] public string Value;
    }
}