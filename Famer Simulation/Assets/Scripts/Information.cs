using Photon.Pun;
using UnityEngine.UI;
using UnityEngine;

public class Information : MonoBehaviourPunCallbacks
{
    private string roomTitle;

    [SerializeField] Text roomTitleText;

    public void OnConnectRoom()
    {
        PhotonNetwork.JoinRoom(roomTitle);
    }

    public void SetData(string name, int currentStaff, int maxStaff)
    {
        roomTitle = name;

        roomTitleText.text = roomTitle + " ( " + currentStaff + " / " + maxStaff + " )";
    }
}