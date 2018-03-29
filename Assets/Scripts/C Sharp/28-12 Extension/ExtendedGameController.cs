using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Extended2D.Animations;
using Extended2D.WorldSpace;

namespace Extended2D
{
    public class ExtendedGameController : ExtendedSingleton<ExtendedGameController>
    {
        private ExtendedGameController() { }

        [HideInInspector]
        public List<ExtendedGameObject> EGOCollection = new List<ExtendedGameObject>();

        [HideInInspector]
        public ExtendedGameObject playerEGO;

        [HideInInspector]
        public AnimationManager animationManager;
        [HideInInspector]
        public WorldBuilder worldBuilder;
        [HideInInspector]
        public Organizer organizer;

        [HideInInspector]
        public string gameLevel;

        public bool autoOrganizingHierarchy = true;
        public bool generatingWorldSpace = true;
        public bool handlingAnimations = true;

        void Awake()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            gameLevel = currentScene.name;

            if (autoOrganizingHierarchy)
            {
                organizer = Organizer.instance;
                AssignName(organizer);
            }

            if (handlingAnimations)
            {
                animationManager = AnimationManager.instance;
                AssignName(animationManager);
            }

            if (generatingWorldSpace)
            {
                worldBuilder = WorldBuilder.instance;
                AssignName(worldBuilder);
            }
        }

        public void AssignName(ExtendedManagerBase intake)
        {
            intake.managerParent = managerName;
        }

        public int CollectionUpdater(ExtendedGameObject parser)
        {
            EGOCollection.Add(parser);
            if (autoOrganizingHierarchy)
                Organizer.instance.ObjectChecker(parser.gameObject);
            return EGOCollection.Count - 1;
        }
    }
}