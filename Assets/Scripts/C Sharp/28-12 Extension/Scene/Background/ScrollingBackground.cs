using UnityEngine;

namespace Extended2D.WorldSpace.Background
{
    public class ScrollingBackground : ExtendedChildScript
    {
        [HideInInspector]
        public Sprite backgroundSprite;

        [HideInInspector]
        public Vector2 initialPos;

        [HideInInspector]
        public float spriteWidth;
        [HideInInspector]
        public float scrollSpeed;
        [HideInInspector]
        public float backgroundInitialOffset;

        [HideInInspector]
        public bool guidingToPlayer;

        void Start()
        {
            initialPos = transform.position;

            backgroundSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

            BackgroundManager.instance.ScrollingBackgrounds.Add(this);

            if (ExtendedGameController.instance != null && ExtendedGameController.instance.playerEGO != null)
                guidingToPlayer = true;

            if (BackgroundManager.instance.ScrollingBackgrounds.Count <= 2)
                BackgroundManager.instance.SpawnMovingBackground();
        }

        void FixedUpdate()
        {
                Vector2 guidingPos;
                if (guidingToPlayer)
                    guidingPos = ExtendedGameController.instance.playerEGO.transform.position;
                else
                    guidingPos = transform.parent.position;

                Vector2 tempParser = new Vector2((transform.position.x - 1), guidingPos.y);
                transform.position = Vector2.MoveTowards(transform.position, tempParser, scrollSpeed * Time.deltaTime);

                if (transform.position.x <= (guidingPos.x + (backgroundInitialOffset - spriteWidth) * 2))
                    transform.position = new Vector2(guidingPos.x + (backgroundInitialOffset + (backgroundInitialOffset + spriteWidth)), guidingPos.y);

                else if (transform.position.x >= (guidingPos.x + (backgroundInitialOffset + spriteWidth) * 2))
                    transform.position = new Vector2(guidingPos.x + (backgroundInitialOffset - (backgroundInitialOffset + spriteWidth)), guidingPos.y);           
        }
    }
}