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
        #region public Variables
        [Tooltip("PlayerListing Prefab")]
        public GameObject playerListingPrefab;
        [Tooltip("Content of PlayerList")]
        public GameObject playerListContent;
        #endregion



        #region MonoBehaviour CallBacks
        void Start()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                GameObject startButton = GameObject.Find("Start Game Button");
                startButton.SetActive(false);
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



        #region Public Methods
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