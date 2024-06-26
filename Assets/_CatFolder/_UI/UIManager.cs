﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cysharp.Threading.Tasks;

public class UIManager : Singleton<UIManager>
{
    private Dictionary<System.Type, UICanvas> uiCanvasPrefab = new Dictionary<System.Type, UICanvas>();
    private UICanvas[] uiResources;
    private Dictionary<System.Type, UICanvas> uiCanvas = new Dictionary<System.Type, UICanvas>();
    public Transform CanvasParentTF;

    #region Canvas

    public async UniTask<T> OpenUI<T>() where T : UICanvas
    {
        UICanvas canvas = GetUI<T>();
        canvas.Setup();
        canvas.Open();
        await UniTask.DelayFrame(1);
        return canvas as T;
    }

    public async UniTask<T> OpenUI_Delay<T>(float delayTime) where T : UICanvas
    {
        await UniTask.Delay((int)(delayTime * 1000));

        UICanvas canvas = GetUI<T>();
        canvas.Setup();
        canvas.Open();
        await UniTask.DelayFrame(1);
        return canvas as T;
    }

    public async UniTask CloseUI<T>() where T : UICanvas
    {
        if (IsOpened<T>())
        {
            GetUI<T>().CloseDirectly();
            await UniTask.DelayFrame(1);
        }
    }

    public async UniTask CloseUI_Delay<T>(float delayTime) where T : UICanvas
    {
        await UniTask.Delay((int)(delayTime * 1000));

        if (IsOpened<T>())
        {
            GetUI<T>().CloseDirectly();
            await UniTask.DelayFrame(1);
        }
    }

    public async UniTask WaitForScreenToOpen<T>() where T : UICanvas
    {
        await UniTask.WaitUntil(() => IsOpened<T>());
    }

    public async UniTask WaitForScreenToClose<T>() where T : UICanvas
    {
        await UniTask.WaitUntil(() => !IsOpened<T>());
    }

    public bool IsOpened<T>() where T : UICanvas
    {
        return IsLoaded<T>() && uiCanvas[typeof(T)].gameObject.activeInHierarchy;
    }

    public bool IsLoaded<T>() where T : UICanvas
    {
        System.Type type = typeof(T);
        return uiCanvas.ContainsKey(type) && uiCanvas[type] != null;
    }

    public T GetUI<T>() where T : UICanvas
    {
        if (!IsLoaded<T>())
        {
            UICanvas canvas = Instantiate(GetUIPrefab<T>(), CanvasParentTF);
            uiCanvas[typeof(T)] = canvas;
        }
        return uiCanvas[typeof(T)] as T;
    }

    public void CloseAll()
    {
        foreach (var item in uiCanvas)
        {
            if (item.Value != null && item.Value.gameObject.activeInHierarchy)
            {
                item.Value.CloseDirectly();
            }
        }
    }

    private T GetUIPrefab<T>() where T : UICanvas
    {
        if (!uiCanvasPrefab.ContainsKey(typeof(T)))
        {
            if (uiResources == null)
            {
                uiResources = Resources.LoadAll<UICanvas>("UI/");
            }

            for (int i = 0; i < uiResources.Length; i++)
            {
                if (uiResources[i] is T)
                {
                    uiCanvasPrefab[typeof(T)] = uiResources[i];
                    break;
                }
            }
        }

        return uiCanvasPrefab[typeof(T)] as T;
    }

    #endregion

    #region Back Button

    private Dictionary<UICanvas, UnityAction> BackActionEvents = new Dictionary<UICanvas, UnityAction>();
    private List<UICanvas> backCanvas = new List<UICanvas>();
    
    private UICanvas BackTopUI 
    {
        get
        {
            UICanvas canvas = null;
            if (backCanvas.Count > 0)
            {
                canvas = backCanvas[backCanvas.Count - 1];
            }
            return canvas;
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Escape) && BackTopUI != null)
        {
            BackActionEvents[BackTopUI]?.Invoke();
        }
    }

    public void PushBackAction(UICanvas canvas, UnityAction action)
    {
        if (!BackActionEvents.ContainsKey(canvas))
        {
            BackActionEvents.Add(canvas, action);
        }
    }

    public void AddBackUI(UICanvas canvas)
    {
        if (!backCanvas.Contains(canvas))
        {
            backCanvas.Add(canvas);
        }
    }

    public void RemoveBackUI(UICanvas canvas)
    {
        backCanvas.Remove(canvas);
    }

    public void ClearBackKey()
    {
        backCanvas.Clear();
    }

    #endregion
}
