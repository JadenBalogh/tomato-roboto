using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] private bool startInteractable = true;
    [SerializeField] private float baseAlpha = 0.6f;
    [SerializeField] private float flashRate = 1f;
    [SerializeField] private float flashAmp = 0.2f;

    public bool IsHovering { get; set; }

    private bool isInteractable;
    private Color spriteColor;
    private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
    }

    protected virtual void Start()
    {
        isInteractable = startInteractable;
    }

    protected virtual void Update()
    {
        if (!isInteractable) return;

        if (IsHovering)
        {
            SetAlpha(1f);
            IsHovering = false;
            return;
        }

        SetAlpha(baseAlpha + Mathf.Sin(Time.time * Mathf.PI * 2 * flashRate) * flashAmp);
    }

    protected void Disable(float duration = 0f)
    {
        isInteractable = false;
        SetAlpha(1f);
        if (duration > 0f)
        {
            StartCoroutine(ReEnableWait(duration));
        }
    }

    private IEnumerator ReEnableWait(float duration)
    {
        yield return new WaitForSeconds(duration);
        isInteractable = true;
    }

    private void SetAlpha(float alpha)
    {
        spriteColor.a = alpha;
        spriteRenderer.color = spriteColor;
    }

    public abstract void Interact();
}
