using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    bool flipX = false;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        if (GetComponent<Movement>() != null && GetComponent<Movement>().speed < 0)
        {
            flipX = false;
        }
        else
        {
            flipX = true;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetFlipX(flipX);
        
    }
    
    public void SetFlipX(bool flip)
    {
        flipX = flip;
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = flipX;
        }
    }
}
