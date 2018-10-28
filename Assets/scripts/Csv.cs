using System;
using System.IO;
using System.Collections.Generic;

namespace CSV
{
    public class Csv<T> where T : new()
    {
        public bool LoadCsvFile(string filePath)
        {
            dic = new Dictionary<int, T>();
            string[] fileData = File.ReadAllLines(filePath);
            string[] keys = fileData[0].Split(',');
            for (int i = 1; i < fileData.Length; i++)
            {
                string[] line = fileData[i].Split(',');
                int ID = int.Parse(line[0]);
                Dictionary<string, string> result = new Dictionary<string, string>();
                for (int j = 0; j < line.Length; j++)
                    result[keys[j]] = line[j];
                T value = new T();
                if (!LoadLine(result, ref value))
                    return false;
                dic.Add(ID, value);
            }
            return true;
        }
        public virtual bool LoadLine(Dictionary<string, string> lineInfo, ref T data){ return true; }
        public bool Find(int ID, ref T value)
        {
            if (!dic.ContainsKey(ID))
                return false;

            value = dic[ID];
            return true;
        }

        public T FindData(int ID)
        {
            if (!dic.ContainsKey(ID))
                return default(T);

            return dic[ID];
        }
        Dictionary<int, T> dic;
    }
}
