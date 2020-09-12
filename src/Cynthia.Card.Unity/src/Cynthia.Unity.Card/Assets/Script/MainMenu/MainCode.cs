﻿using Cynthia.Card.Client;
using UnityEngine;
using Autofac;
using Cynthia.Card.Common.Models;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCode : MonoBehaviour
{
    private GlobalUIService _globalUIService;
    private GwentClientService _client;
    private ITranslator _translator;
    public GameObject Context;
    public GameObject MatchUI;
    public EditorInfo EditorMenu;
    public Button MatchMenuButton;
    public Button DoMatchButton;

    //async Task AutoTest()
    //{
    //    var hub = DependencyResolver.Container.ResolveNamed<HubConnection>("game");
    //    while (true)
    //    {
    //        await Task.Delay(500);
    //        if (hub.State == HubConnectionState.Disconnected)
    //        {
    //            Debug.Log("MainCode检测到断线!");
    //            SceneManager.LoadScene("LoginSecen");
    //            _ = DependencyResolver.Container.Resolve<GlobalUIService>().YNMessageBox("断开连接", "请尝试重新登陆");
    //            return;
    //        }
    //    }
    //}
    void Start()
    {
        //_ = AutoTest();
        _globalUIService = DependencyResolver.Container.Resolve<GlobalUIService>();
        _client = DependencyResolver.Container.Resolve<GwentClientService>();
        if (_client.IsAutoPlay || ClientGlobalInfo.IsToMatch)
        {
            MatchMenuButton.onClick.Invoke();
            //DoMatchButton.onClick.Invoke();
        }
        _translator = DependencyResolver.Container.Resolve<ITranslator>();
    }
    public async void ExitGameClick()
    {
        // SceneManager.LoadScene("LoginSecen");
        if (await _globalUIService.YNMessageBox(_translator.GetText("PopupWindow_QuitTitle"), _translator.GetText("PopupWindow_QuitDesc")))
        {
            //进行一些处理
            Application.Quit();
            return;
        }
    }
}
