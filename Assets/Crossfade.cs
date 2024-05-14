using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossfade : MonoBehaviour
{
    [SerializeField] SpriteRenderer rnd0 = null;
    [SerializeField] SpriteRenderer rnd1 = null;


    Coroutine fadeRoutine = null;

    public void FadeToSprite(Sprite i_sprite, float i_time)
    {
        fadeRoutine = StartCoroutine(fade(i_sprite, i_time));
    }


    IEnumerator fade(Sprite i_sprite, float i_time)
    {
        rnd0.sprite = rnd1.sprite;
        rnd1.sprite = i_sprite;

        setAlpha(rnd1, 0f);

        float endTime = Time.time + i_time;
        float elapsed = 0f;
        while(Time.time < endTime) 
        {
            float newAlpha = Mathf.Lerp(0, 1, elapsed / i_time);

            setAlpha(rnd1, newAlpha);

            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    void setAlpha(SpriteRenderer i_rnd, float i_alpha)
    {
        Color col = i_rnd.color;
        col.a = i_alpha;
        i_rnd.color = col;
    }


}
