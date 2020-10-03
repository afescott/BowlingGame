﻿using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> Class to control the drag and drop UI <summary> 
public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    public static bool ISEnabled = true;
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        ISEnabled = false;
      
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ISEnabled = true;

        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}