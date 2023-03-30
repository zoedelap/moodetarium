using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataAcquisitionSpace {
[System.Serializable]
public class SpreadsheetData
{
    // TODO: make this a more flexible implementation
    public Dictionary<string, string[]> cols = new Dictionary<string, string[]>();

    public SpreadsheetData(string jsonString) {
        JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(jsonString);
        string[][] values = jsonResponse["values"].ToObject<string[][]>();
        foreach (string[] column in values) {
            cols.Add(column[0], column[1..]);
        }
    }

    public override string ToString() {
        string result = "";
        foreach (KeyValuePair<string, string[]> column in cols) {
            result += column.Key + ": " + String.Join(", ", column.Value) + "\n";
        }
        return result;
    }
}
}