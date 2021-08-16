using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomNameText;
    private RoomInfo _roomInfo;
    
    public void SetUp(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        roomNameText.text = roomInfo.Name;
    }

    public void JoinToRoom() => Launcher.Instance.JoinRoom(_roomInfo);
}
