using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float slotmoveSpeed = 5.0f;

    protected float slotWidth;

    Transform[] backSlot;

    protected SpriteRenderer[] spriteRenderers;

    protected float maginotLineX;

    protected virtual void Awake()
    {
        backSlot = new Transform[transform.childCount];
        for(int i = 0; i < backSlot.Length; i++)
        {
            backSlot[i] = transform.GetChild(i);
        }

        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        if(spriteRenderers.Length > 0)
        {
            Sprite sprite = spriteRenderers[0].sprite;
            slotWidth = sprite.textureRect.width / sprite.pixelsPerUnit;
        }

    }

    private void Update()
    {
        for(int i = 0;i < backSlot.Length; i++)
        {
            backSlot[i].Translate(Time.deltaTime * slotmoveSpeed * -transform.right);
            if (backSlot[i].position.x < maginotLineX)
            {
                MoveEnd(i);
            }
        }
    }

    void MoveEnd(int index)
    {
        backSlot[index].Translate(slotWidth * backSlot.Length * transform.right);
        OnMoveEnd(index);
    }

    protected virtual void OnMoveEnd(int index)
    {

    }


}
