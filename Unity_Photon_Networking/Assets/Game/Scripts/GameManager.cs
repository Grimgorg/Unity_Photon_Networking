using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Com.GrimGames.Agility
{
    /// <summary>
    /// This class manages the switching between scenes.
    /// </summary>
    public class GameManager : Photon.PunBehaviour
    {
        #region Photon Messages
        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public override void OnPhotonPlayerConnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerConnected() " + other.NickName);

            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient);

                LoadArena();
            }
        }

        public override void OnPhotonPlayerDisconnected(PhotonPlayer other)
        {
            Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName);
        
            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("OnPhotonPlayerDisonnected isMasterClient " + PhotonNetwork.isMasterClient);
        
                LoadArena();
            }
        }
        #endregion



        #region Private Methods
        void LoadArena()
        {
            if (!PhotonNetwork.isMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
            }

            Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);
            PhotonNetwork.LoadLevel("Room for " + PhotonNetwork.room.PlayerCount);
        }
        #endregion




        #region Public Methods
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        #endregion
    }
}