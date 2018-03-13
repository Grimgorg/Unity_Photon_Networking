using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Com.GrimGames.Agility
{
    /// <summary>
    /// This class manages the switching between scenes/maps.
    /// </summary>
    public class Lobby : Photon.PunBehaviour
    {
        #region MonoBehaviour CallBacks
        void Start()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                Button _button = this.GetComponent<Button>();

                if (_button.name == "Start Game Button")
                {
                    _button.gameObject.SetActive(false);
                }
            }
        }
        #endregion



        #region Photon Messages
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerConnected() " + other.NickName);
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName);
        }
        #endregion



        #region public Methods
        public void LoadArena()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                Debug.Log("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }
            else
            {
                Debug.Log("Loading Arena map for " + PhotonNetwork.room.PlayerCount + " Player");

                PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.room.PlayerCount);
            }
        }

        public void LeaveLobby()
        {
            PhotonNetwork.LeaveRoom();
        }
        #endregion
    }
}