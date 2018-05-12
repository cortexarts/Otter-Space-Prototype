using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class ULog : MonoBehaviour
    {
        public enum Severity
        {
            Error = 0,
            Warning = 1,
            Log = 2
        }
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void Log(Severity severity, string name, string message)
        {
            switch(severity)
            {
                case Severity.Error:
                    Debug.LogError(name + " @" + System.DateTime.Now + ": " + message);
                    break;
                case Severity.Warning:
                    Debug.LogWarning(name + " @" + System.DateTime.Now + ": " + message);
                    break;
                case Severity.Log:
                    Debug.Log(name + " @" + System.DateTime.Now + ": " + message);
                    break;
                default:
                    break;
            }
        }
    }
}
