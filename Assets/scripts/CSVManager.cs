using UnityEngine;
using System.Collections;
using CSV;
using System.Collections.Generic;

public class CSVManager : MonoBehaviour {

    // Use this for initialization
    struct CNormalData
    {
        public int id;
        public string strDesc;
    }
    class CNormalRes : Csv<CNormalData>
    {
        public override bool LoadLine(Dictionary<string, string> lineInfo, ref CNormalData data)
        {
            data.id = int.Parse(lineInfo["ID"]);
            data.strDesc = lineInfo["Name"];
            return true;
        }
    }
    CNormalRes data;
    void Start () {
        data = new CNormalRes();
        string filePath = Application.streamingAssetsPath + "/CSVInfo.csv";
        data.LoadCsvFile(filePath);
    }
	
	// Update is called once per frame
	void Update () {
        CNormalData value = data.FindData(4);
        if (value.id == 0)
            Debug.Log("Fail Value");
        else
            Debug.Log(value.strDesc);
    }
}
