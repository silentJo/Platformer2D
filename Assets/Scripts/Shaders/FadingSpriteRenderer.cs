using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingSpriteRenderer : MonoBehaviour
{
    [SerializeField] Sprite RevivedSprite;

    Material myMaterial;

    private void Start()
    {
        myMaterial = GetComponent<SpriteRenderer>().material;
        myMaterial.SetTexture("_SecondaryTex", RevivedSprite.texture);
    }
}
