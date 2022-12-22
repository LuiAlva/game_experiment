using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    /* Need to finish Character to create and save 4 prefabs.
     * Each character Prefab needs a differently set Cinemachine.
     * Need a Camera Method to setup the size of Cameras depending on the number of players.*/

    Player Player1 = new Player();
    Player Player2 = new Player();
    Player Player3 = new Player();
    Player Player4 = new Player();
    int activePlayerCount;

    // Prefabs
    [SerializeField] // Player Character GameObjects
    GameObject P1_Character = null, P2_Character = null, P3_Character = null, P4_Character = null;
    [SerializeField] // Player Cameras
    GameObject P1_Camera = null, P2_Camera = null, P3_Camera = null, P4_Camera = null;
    // Prefab packs
    PlayerSlot[] PlayerSlots;

    // Character Location GameObject 
    [SerializeField]
    GameObject characterLocation;
    [SerializeField]
    GameObject cameraLocation;
    [SerializeField]
    GameObject DefaultSprite;

    void Awake()
    {
        PlayerSlots = new PlayerSlot[]
        {
            new PlayerSlot(0, Player1, P1_Character, P1_Camera),
            new PlayerSlot(1, Player2, P2_Character, P2_Camera),
            new PlayerSlot(2, Player3, P3_Character, P3_Camera),
            new PlayerSlot(3, Player4, P4_Character, P4_Camera)
        };
    }

    void CountActivePlayers()
    {
        int count = 0;
        foreach(PlayerSlot slot in PlayerSlots)
        {
            if (slot.Active == true)
                count++;
        }
        activePlayerCount = count;
    }

    int FindInactiveSlot()
    {
        CountActivePlayers();
        if(activePlayerCount == 4) { return -1; }
        for(int i = 0; i < 4; i++ )
        {
            if (PlayerSlots[i].Active == false)
                return i;
        }
        return -1;
    }

    public void ActivatePlayer()
    {
        int Slot = FindInactiveSlot();
        if (Slot == -1) { Debug.Log($"There is already {activePlayerCount}. Can't create new players."); return; }
        SetPlayerName(PlayerSlots[Slot], "Default");
        SetCharacterToPlayer(PlayerSlots[Slot]);
        SetCameraToPlayer(PlayerSlots[Slot]);
        SetSpriteToCharacter(PlayerSlots[Slot], DefaultSprite);
    }

    void SetPlayerName(PlayerSlot slot, string playerName)
    {
        slot.GetPlayer.Name = playerName; 
    }

    void SetCharacterToPlayer(PlayerSlot slot)
    {
        GameObject character = GameObject.Instantiate(slot.GetCharacterPrefab, characterLocation.transform);
        character.name = $"P{slot.ID+1}_Character";
        slot.GetPlayer.Character = character;
        slot.GetPlayer.Brain = character.GetComponent<PC_Main>();
    }

    void SetCameraToPlayer(PlayerSlot slot)
    {
        if(slot.ID == 0) { slot.GetCameraPrefab.transform.parent = cameraLocation.transform; return; }
        else
        {
            GameObject camera = GameObject.Instantiate(slot.GetCameraPrefab);
            camera.name = $"P{slot.ID + 1}_Camera";
            camera.transform.parent = cameraLocation.transform;
        }
    }

    public void SetSpriteToCharacter(PlayerSlot slot, GameObject newSprite)
    {
        RemoveSprite(slot.GetPlayer);
        GameObject sprite = GameObject.Instantiate(newSprite, slot.GetPlayer.Character.transform);
        slot.GetPlayer.Brain.RefreshGameObjectVariables();
    }

    void RemoveSprite(Player player)
    {
        if(player.Sprite == null) return;
        Destroy(player.Sprite);
    }
}

public class PlayerSlot
{
    Player Player;
    GameObject CharacterPrefab, CameraPrefab;
    public bool Active = false;
    public int ID;

    public PlayerSlot(int slotID, Player player, GameObject charPrefab, GameObject camPrefab)
    {
        ID = slotID;
        Player = player;
        CharacterPrefab = charPrefab;
        CameraPrefab = camPrefab;
        Active = false;
    }

    public Player GetPlayer => Player;
    public GameObject GetCharacterPrefab => CharacterPrefab;
    public GameObject GetCameraPrefab => CameraPrefab;
}
