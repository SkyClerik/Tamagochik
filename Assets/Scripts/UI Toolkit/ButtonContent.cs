using System;
using UnityEngine;

public class ButtonContent
{
    public string Title { get; set; }
    public Sprite Icon { get; set; }
    public Action Clicked { get; set; }

    public ButtonContent(string title, Sprite icon, Action clicked)
    {
        Title = title;
        Icon = icon;
        Clicked = clicked;
    }
}
