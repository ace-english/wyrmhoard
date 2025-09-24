using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//don't lock pause/play

//basically a big foldout menu - button enqueues to sim that opened the menu

public class BuildMenu : MonoBehaviour
{
    protected VisualElement ui;
    public Button addRoomButton, addThreatButton, addLockButton, addKeyButton, addLootButton, redecorateRoomButton, deleteRoomButton, playButton, saveButton, exitButton;

    private DungeonRoot dungeon;

    public void Awake()
    {
        dungeon = GameObject.Find("DungeonRoot").GetComponent<DungeonRoot>();
        
        ui = GetComponent<UIDocument>().rootVisualElement;
        addRoomButton = ui.Q<Button>("add-room-button");
        addThreatButton = ui.Q<Button>("add-threat-button");
        addLockButton = ui.Q<Button>("add-lock-button");
        addKeyButton = ui.Q<Button>("add-key-button");
        addLootButton = ui.Q<Button>("add-loot-button");
        redecorateRoomButton = ui.Q<Button>("redecorate-room-button");
        deleteRoomButton = ui.Q<Button>("delete-room-button");
        playButton = ui.Q<Button>("play-button");
        saveButton = ui.Q<Button>("save-button");
        exitButton = ui.Q<Button>("exit-button");
        
        addRoomButton.clicked += dungeon.EnableBuildMode;
        addThreatButton.clicked += EnterAddThreatMode;
        addLockButton.clicked += EnterLockDoorMode;
        addKeyButton.clicked += EnterPlaceKeyMode;
        addLootButton.clicked += EnterPlaceLootMode;
        redecorateRoomButton.clicked += dungeon.EnableRedecorateMode;
        deleteRoomButton.clicked += dungeon.EnableDeleteMode;
        playButton.clicked += EnterPlayDemoMode;
        saveButton.clicked += SaveDungeon;
        exitButton.clicked += ExitBuildMode;
    }

    public void EnterAddRoomMode()
    {
        print("Enter add room mode");
    }

    public void EnterAddThreatMode()
    {
        
    }

    public void EnterLockDoorMode()
    {
        
    }

    public void EnterPlaceLootMode()
    {
        
    }
    
    public void EnterPlaceKeyMode()
    {

    }

    public void RedecorateMode()
    {
        
    }

    public void DeleteRoomMode()
    {
        
    }

    public void EnterPlayDemoMode()
    {
        
    }

    public void SaveDungeon()
    {
        
    }

    public void ExitBuildMode()
    {
        
    }


}