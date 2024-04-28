using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_SKY : MonoBehaviour
{
    [SerializeField] Sprite morningSprite;
    [SerializeField] Sprite afternoonSprite;
    [SerializeField] Sprite nightSprite;
    private DayNight_timer dayNightTimer;
    private SpriteRenderer spriteRenderer;
    private Sprite[] backgrounds;
    private int currentIndex = 0;
    private float transitionSpeed = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the sprites in an array
        backgrounds = new Sprite[] { morningSprite, afternoonSprite, nightSprite, afternoonSprite };

        // Set the initial sprite
        spriteRenderer.sprite = morningSprite;
        dayNightTimer = FindObjectOfType<DayNight_timer>();
        currentIndex = dayNightTimer.GetCurrentTime();
    }

    void Update()
    {

        int Index = dayNightTimer.GetCurrentTime();
        if (currentIndex != Index)
        {
            currentIndex = Index;
            StartCoroutine(TransitionToNextSprite(backgrounds[currentIndex]));
        }
    }

    IEnumerator TransitionToNextSprite(Sprite nextSprite)
    {

        // Smoothly transition between the current sprite and the next sprite
        while (spriteRenderer.color.a < 1)
        {
            // Increase the alpha value gradually
            spriteRenderer.color += new Color(0, 0, 0, Time.deltaTime * transitionSpeed);
            yield return null;
        }

        // Set the new sprite
        spriteRenderer.sprite = nextSprite;
        
        // Reset alpha to 0 for the new sprite
        spriteRenderer.color = new Color(1, 1, 1, 0);

        // Smoothly fade in the new sprite
        while (spriteRenderer.color.a < 1)
        {
            // Increase the alpha value gradually
            spriteRenderer.color += new Color(0, 0, 0, Time.deltaTime * transitionSpeed);
            yield return null;
        }

    }
}