using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Scroll
{
    protected override void Awake()
    {
        base.Awake();

        maginotLineX = transform.position.x - slotWidth;
    }

    protected override void OnMoveEnd(int index)
    {
        float rand = Random.value;
        spriteRenderers[index * 2].flipX = rand < 0.1f;
        rand = Random.value;
        spriteRenderers[index * 2 + 1].flipX = rand < 0.1f;
    }
}
