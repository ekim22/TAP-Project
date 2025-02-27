﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyButton : Button
{
    public EventSystem eventSystem;

    protected override void Awake()
    {
        base.Awake();
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        // Selection tracking
        if (IsInteractable() && navigation.mode != Navigation.Mode.None)
            eventSystem.SetSelectedGameObject(gameObject, eventData);

        base.OnPointerDown(eventData);
    }

    public override void Select()
    {
        if (eventSystem.alreadySelecting)
            return;

        eventSystem.SetSelectedGameObject(gameObject);
    }
}
