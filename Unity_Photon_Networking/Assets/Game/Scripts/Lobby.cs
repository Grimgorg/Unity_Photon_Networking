using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


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
        [Tooltip("PlayerListing Prefab Text")]
        public GameObject playerListingPrefabText;
        [Tooltip("Content of PlayerList")]
        public GameObject playerListContent;
        #endregion



        #region Private Variables
        List<GameObject> allPlayerListingPrefabs = new List<GameObject>();
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

        void Awake()
        {
                UpdatePlayerList();
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

            UpdatePlayerList();
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName);

            UpdatePlayerList();
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



        #region Private Methods
        private void UpdatePlayerList()
        {

            //GameObject[] _playerListings = GameObject.FindGameObjectsWithTag("PlayerListingPrefab");

            foreach (GameObject item in allPlayerListingPrefabs)
            {
                Destroy(item);
            }

            //foreach (GameObject item in _playerListings)
            //{
            //    Destroy(item);
            //}

            foreach (PhotonPlayer currentPlayer in PhotonNetwork.playerList)
            {
                playerListingPrefabText.GetComponent<Text>().text = currentPlayer.NickName;
                if (currentPlayer.IsMasterClient)
                {
                    playerListingPrefab.GetComponent<Image>().color = Color.yellow;
                }
                else
                {
                    playerListingPrefab.GetComponent<Image>().color = Color.white;
                }

                GameObject newPlayer = Instantiate(playerListingPrefab);
                newPlayer.transform.SetParent(playerListContent.transform, false);
                allPlayerListingPrefabs.Add(newPlayer);
            }
        }
        #endregion
    }
}