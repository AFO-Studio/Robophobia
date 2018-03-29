using UnityEngine;

namespace Extended2D
{
    public class ExtendedSingleton<T> : ExtendedManagerBase where T : ExtendedManagerBase
    {
        public static bool applicationIsQuitting = false;
        public static T _instance;
        public static T instance
        {
            get
            {
                if (applicationIsQuitting)
                    return null;

                GameObject gameController = GameObject.Find("Game Controller");

                if (gameController == null)
                    gameController = new GameObject("Game Controller");

                if (_instance == null)
                {
                    var tempParser = (T[])FindObjectsOfType(typeof(T));

                    if (tempParser == null || tempParser.Length == 0)
                    {
                        _instance = gameController.AddComponent<T>();
                    }
                    else
                    {
                        for (int i = 1; i < tempParser.Length; ++i)
                            Destroy(tempParser[i]);

                        _instance = tempParser[0];

                        DontDestroyOnLoad(_instance);
                    }
                }

                _instance.managerName = (typeof(T)).Name;
                return _instance;
            }
        }

        void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
}