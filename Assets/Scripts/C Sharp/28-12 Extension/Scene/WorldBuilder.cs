using UnityEngine;
using Extended2D.WorldSpace.Background;

namespace Extended2D.WorldSpace
{
    public class WorldBuilder : ExtendedSingleton<WorldBuilder>
    {
        private WorldBuilder() { }

        [HideInInspector]
        public BackgroundManager backgroundManager;

        public bool generateBackgrounds = true;

        void Start()
        {
            if (generateBackgrounds)
            {
                backgroundManager = BackgroundManager.instance;
                backgroundManager.managerParent = managerName;
            }
        }
    }
}