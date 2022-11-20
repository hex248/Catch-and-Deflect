using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class ColourManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] mainSprites;
    [SerializeField] Color mainColour;
    [SerializeField] SpriteRenderer[] accentSprites;
    [SerializeField] Color accentColour;
    [SerializeField] Image[] mainImages;
    [SerializeField] Image[] accentImages;

    void Update()
    {
        for (int i = 0; i < mainSprites.Length; i++)
        {
            mainSprites[i].color = mainColour;
        }
        for (int i = 0; i < mainImages.Length; i++)
        {
            mainImages[i].color = mainColour;
        }
        for (int i = 0; i < accentSprites.Length; i++)
        {
            accentSprites[i].color = accentColour;
        }
        for (int i = 0; i < accentImages.Length; i++)
        {
            accentImages[i].color = mainColour;
        }
    }
}
