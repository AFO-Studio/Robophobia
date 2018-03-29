using System.Collections.Generic;
using UnityEngine;

namespace Extended2D.WorldSpace.Background
{
    public class BackgroundManager : ExtendedSingleton<BackgroundManager>
    {
        private BackgroundManager() { }

        public GameObject backgroundStorage;

        [HideInInspector]
        public List<ScrollingBackground> ScrollingBackgrounds;

        public Sprite[] ParallaxingBackgrounds;
        public Sprite[] ParallaxingForegrounds;

        private Sprite scrollingBackground;
        private Sprite staticBackground;

        [HideInInspector]
        private GameObject workingBackground;

        [HideInInspector]
        public float backgroundInitialOffset;
        public float backgroundScrollSpeed = 2;

		public float pBackgroundOffset = 8f;
        public float pForegroundOffset = 2f;
		public float pSmoothing = 1f;

        public float backgroundStorageYOffset;

        private float previousScrollSpeed;

        void Start()
        {
            backgroundStorage = new GameObject("Background Storage");
            backgroundStorage.transform.parent = Organizer.instance.organizedStorage.transform;
            backgroundStorageYOffset = backgroundStorage.transform.position.y - ExtendedGameController.instance.playerEGO.transform.position.y;

            ScrollingBackgrounds = new List<ScrollingBackground>();

            previousScrollSpeed = backgroundScrollSpeed;

            var tempParser1 = Resources.LoadAll<Sprite>("Managers/" + managerParent + "/" + managerName + "/Static Background/" + ExtendedGameController.instance.gameLevel);
            var tempParser2 = Resources.LoadAll<Sprite>("Managers/" + managerParent + "/" + managerName + "/Scrolling Background/" + ExtendedGameController.instance.gameLevel);
            ParallaxingBackgrounds = Resources.LoadAll<Sprite>("Managers/" + managerParent + "/" + managerName + "/Parallaxing Backgrounds/" + ExtendedGameController.instance.gameLevel);
            ParallaxingForegrounds = Resources.LoadAll<Sprite>("Managers/" + managerParent + "/" + managerName + "/Parallaxing Foregrounds/" + ExtendedGameController.instance.gameLevel);

            if (tempParser1.Length > 0)
                staticBackground = tempParser1[0];
            if (tempParser2.Length > 0)
                scrollingBackground = tempParser2[0];

            InitializeBackground();
        }

        void Update()
        {
            backgroundStorage.transform.position = new Vector3(transform.position.x, ExtendedGameController.instance.playerEGO.transform.position.y + backgroundStorageYOffset, transform.position.z);

            if (backgroundScrollSpeed != previousScrollSpeed)
            {
                foreach (ScrollingBackground BBG in ScrollingBackgrounds)
                    BBG.scrollSpeed = backgroundScrollSpeed;
            }

            previousScrollSpeed = backgroundScrollSpeed;
        }

        public void InitializeBackground()
        {
			if (ParallaxingBackgrounds != null & ParallaxingBackgrounds.Length > 0)
				SpawnParallaxer(false, ParallaxingBackgrounds);
            if (ParallaxingForegrounds != null & ParallaxingForegrounds.Length > 0)
                SpawnParallaxer(true, ParallaxingForegrounds);

            if (staticBackground != null)
                SpawnStaticBackground();

            if (scrollingBackground != null)
            {
                backgroundInitialOffset = (scrollingBackground.rect.width / 100) * 0.3f;
                SpawnMovingBackground();
            }
        }

        public void SpawnStaticBackground()
        {
            workingBackground = new GameObject("Static Background");

            if (ExtendedGameController.instance != null && ExtendedGameController.instance.playerEGO != null)
                workingBackground.transform.parent = ExtendedGameController.instance.playerEGO.transform;
            else
                workingBackground.transform.parent = gameObject.transform;

            SpriteRenderer SR = workingBackground.AddComponent<SpriteRenderer>();
            SR.sprite = staticBackground;
            SR.sortingOrder = -100;
			workingBackground.transform.position = new Vector3 (transform.position.x, transform.position.y, 200);

            workingBackground.transform.localScale = new Vector3(150, 150, 0);
        }

        public void SpawnMovingBackground()
        {
            Vector2 workingSpawnpoint;

            workingSpawnpoint = new Vector2((0 - backgroundInitialOffset), 0);

            if (ExtendedGameController.instance.playerEGO != null)
                workingSpawnpoint.y = ExtendedGameController.instance.playerEGO.transform.position.y;

            if (ScrollingBackgrounds.Count >= 1)
                workingSpawnpoint.x += (ScrollingBackgrounds[0].backgroundSprite.rect.width) / 100 * ScrollingBackgrounds.Count;

            GameObject newBackground = new GameObject();
            newBackground.transform.position = workingSpawnpoint;

            if (ExtendedGameController.instance != null && ExtendedGameController.instance.playerEGO != null)
                newBackground.transform.parent = ExtendedGameController.instance.playerEGO.transform;
            else
                newBackground.transform.parent = gameObject.transform;

            newBackground.name = "Scrolling Background " + ScrollingBackgrounds.Count;

            SpriteRenderer SR = newBackground.AddComponent<SpriteRenderer>();
            SR.sprite = scrollingBackground;
            SR.sortingOrder = -50;

            ScrollingBackground BBG = newBackground.AddComponent<ScrollingBackground>();
            BBG.childParent = managerName;
            BBG.scrollSpeed = backgroundScrollSpeed;
            BBG.spriteWidth = (SR.sprite.rect.width) / 100;
            BBG.backgroundInitialOffset = backgroundInitialOffset;
        }

		public void SpawnParallaxer(bool inFront, Sprite[] parallxingSprites)
		{
            GameObject backStore = new GameObject("Background Manager Storage");
            backStore.transform.parent = backgroundStorage.transform;

            float offset;
            float yOffset;

            if (inFront)
            {
                offset = -pForegroundOffset;
                yOffset = -1;
            }
            else
            {
                offset = pBackgroundOffset;
                yOffset = 1;
            }

			for (int i = 0; i < parallxingSprites.Length; ++i) 
			{
				offset *= (i+1);

                yOffset *= (i+1);

				var workingPB = new GameObject ("Parallaxer " + i);
				workingPB.transform.position = new Vector3 (0, yOffset/2, offset);
				workingPB.transform.parent = backStore.transform;

				SpriteRenderer SR = workingPB.AddComponent<SpriteRenderer> ();
				SR.sprite = parallxingSprites[i];
                SR.sortingOrder = -15;

				Parallax PB = workingPB.AddComponent<Parallax> ();
                PB.childParent = managerName;
				PB.smoothing = pSmoothing;

                ParallaxTiling PT = workingPB.AddComponent<ParallaxTiling>();
                PB.childParent = managerName;
			}
		}
    }
}
