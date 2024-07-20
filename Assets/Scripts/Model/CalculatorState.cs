﻿using System;
using System.Collections.Generic;
using Model.History;
using UnityEngine;

namespace Model
{
    [Serializable]
    public class CalculatorState
    {
        [SerializeField] public string Input;
        [SerializeField] public List<HistoryItem> HistoryItems = new();
    }
}