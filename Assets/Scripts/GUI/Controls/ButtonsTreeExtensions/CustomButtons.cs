using System;
using System.Collections.Generic;
using UnityEngine;

public class ButtonElement
{
    public IconElement MainIcon;
    public ViewElementButton MainButton;
    public List<InfoElement> AdditionalInfo;
    public List<InfoElement> AdditionalInfoBottom;
    public EndIcon EndIcon;

    public ButtonElement(IconElement mainIcon, ViewElementButton mainButton, List<InfoElement> additionalInfo, EndIcon endIcon = null)
    {
        MainIcon = mainIcon;
        MainButton = mainButton;
        AdditionalInfo = additionalInfo;
        AdditionalInfoBottom = null;
        EndIcon = endIcon;
    }

    public ButtonElement(IconElement mainIcon, ViewElementButton mainButton, List<InfoElement> additionalInfo, List<InfoElement> additionalInfoBottom, EndIcon endIcon = null)
    {
        MainIcon = mainIcon;
        MainButton = mainButton;
        AdditionalInfo = additionalInfo;
        AdditionalInfoBottom = additionalInfoBottom;
        EndIcon = endIcon;
    }
}

public class ViewElementButton
{
    public Action Callback;
    public Action<int> CallbackInt;
    public int CallbackParam;
    public string ButtonText;
    public GUIStyle Style;
    public bool Active;

    public ViewElementButton(string buttonText, Action callback, GUIStyle style, bool active, int callbackParam = -1)
    {
        ButtonText = buttonText;
        Style = style;
        Callback = callback;
        Active = active;
        CallbackParam = callbackParam;
    }

    public ViewElementButton(string buttonText, Action<int> callbackInt, int callbackParam, GUIStyle style, bool active)
    {
        ButtonText = buttonText;
        Style = style;
        CallbackInt = callbackInt;
        CallbackParam = callbackParam;
        Active = active;
    }

    public void Invoke()
    {
        Callback?.Invoke();
        CallbackInt?.Invoke(CallbackParam);
    }
}

public class IconElement
{
    public GUIContent Content;
    public GUIStyle GUIStyle;

    public IconElement(GUIContent content, GUIStyle gUIStyle)
    {
        Content = content;
        GUIStyle = gUIStyle;
    }
}

public class InfoElement
{
    public GUIContent Content;
    public GUIStyle GUIStyle;

    public InfoElement(GUIContent content, GUIStyle gUIStyle)
    {
        Content = content;
        GUIStyle = gUIStyle;
    }
}

public class EndIcon
{
    public GUIContent Content;
    public GUIStyle GUIStyle;

    public EndIcon(int kdTime, GUIStyle gUIStyle)
    {
        Content = new GUIContent($"{kdTime}\nOD");
        GUIStyle = gUIStyle;
    }
}