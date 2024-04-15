using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_SKY : MonoBehaviour
{
    [SerializeField] Sprite morningSprite;
    [SerializeField] Sprite afternoonSprite;
    [SerializeField] Sprite nightSprite;
    
    private SpriteRenderer spriteRenderer;
    private Sprite[] backgrounds;
    private int currentIndex = 0;
    private float timer = 0f;
    private float toggleInterval = 5f;
    private float transitionSpeed = 1f;
    private bool isTransitioning = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Store the sprites in an array
        backgrounds = new Sprite[] { morningSprite, afternoonSprite, nightSprite };

        // Set the initial sprite
        spriteRenderer.sprite = morningSprite;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= toggleInterval)
        {
            SwitchBackground();
            timer = 0f;
        }
    }

    void SwitchBackground()
    {
        // Increment the index and wrap around if needed
        currentIndex = (currentIndex + 1) % backgrounds.Length;

        // Set the sprite to the next one in the array
        spriteRenderer.sprite = backgrounds[currentIndex];
    }

    // void SwitchBackground()
    // {
    //     // Increment the index and wrap around if needed
    //     currentIndex = (currentIndex + 1) % backgrounds.Length;

    //     // Start transitioning to the next sprite
    //     StartCoroutine(TransitionToNextSprite(backgrounds[currentIndex]));
    // }

    //   IEnumerator TransitionToNextSprite(Sprite nextSprite)
    // {
    //     isTransitioning = true;

    //     // Smoothly transition between the current sprite and the next sprite
    //     while (spriteRenderer.color.a < 1)
    //     {
    //         // Increase the alpha value gradually
    //         spriteRenderer.color += new Color(0, 0, 0, Time.deltaTime * transitionSpeed);
    //         yield return null;
    //     }

    //     // Set the new sprite
    //     spriteRenderer.sprite = nextSprite;

    //     // Reset alpha to 0 for the new sprite
    //     spriteRenderer.color = new Color(1, 1, 1, 0);

    //     // Smoothly fade in the new sprite
    //     while (spriteRenderer.color.a < 1)
    //     {
    //         // Increase the alpha value gradually
    //         spriteRenderer.color += new Color(0, 0, 0, Time.deltaTime * transitionSpeed);
    //         yield return null;
    //     }

    //     isTransitioning = false;
    // }
}