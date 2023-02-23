using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace Utility
{
    public class HighScore
    {
        [Serializable]
        public struct Entry
        {
            public string name;
            public int value;
        }

        public struct HighScoreList
        {
            public bool could_load;
            public List<Entry> highscores;
        }

        public static IEnumerator UploadHighScore(Entry entry, string dbDomainText, string token)
        {
            Debug.Assert(!(entry.name.Length < 4 || entry.name.Length > 16));

            var form = new WWWForm();
            form.AddField("name", entry.name);
            form.AddField("value", entry.value);
            using var www = UnityWebRequest.Post(dbDomainText + token, form);

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
                throw new Exception(www.error);
        }

        public static IEnumerator RequestTop10(Action<HighScoreList> result, string dbDomainText)
        {
            var list = new HighScoreList
            {
                could_load = false,
                highscores = new List<Entry>()
            };

            using var webRequest = UnityWebRequest.Get(dbDomainText);

            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    var data = webRequest.downloadHandler.text;
                    Debug.Log("Received: " + data);
                    try
                    {
                        list.highscores = JsonHelper.FromJson<Entry>(data).ToList();
                        list.could_load = true;
                    }
                    catch (Exception e)
                    {
                        Debug.Log(e);
                    }
                    break;
                case UnityWebRequest.Result.InProgress:
                    Debug.Log("In progress");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            result(list);
        }

        private HighScore()
        {
        }
    }
}