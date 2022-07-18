using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

namespace TheLastSymphony
{
    public class TLS_UIManager : MonoBehaviour
    {
        [SerializeField] private TLS_GameManager gameManager;
        [SerializeField] private CinemachineVirtualCamera CMCam_Transition;
        [SerializeField] public ParticleSystem portal;

        public Text skullCountText;
        public Slider playerhealthBar;

        public GameObject levelStartMessagePopUp;
        public GameObject levelEndMessagePopUp;

        public int skullCount = 0;
        public int totalSkullCount;

        public bool level01Completed = false;

        private void Awake()
        {
            skullCountText.text = skullCount.ToString() + " / " + totalSkullCount;
        }

        public void ModifyPlayerHealth(int currentCount, int totalCount)
        {
            float percentage = ((float)currentCount / (float)totalCount) * 100f;
            playerhealthBar.value = percentage / 100f;
        }

        public void SkullCounter()
        {
            if(!level01Completed)
            {
                skullCount++;
                skullCountText.text = skullCount.ToString() + " / " + (skullCount > totalSkullCount ? totalSkullCount : skullCount);

                if(skullCount >= totalSkullCount && !level01Completed)
                {
                    level01Completed = true;
                    Invoke(nameof(ActivatePortal),0);
                }
            }
        }

        private void ActivatePortal()
        {
            GameObject.Find("EnemySpawner").GetComponent<TLS_EnemySpawner>().StopDeploying();
            portal.gameObject.SetActive(true);
            portal.transform.parent.gameObject.SetActive(true);
            //portal.transform.position = gameManager.characterController.gameObject.transform.position + new Vector3(3, 0, 0);
            portal.transform.parent.transform.position = gameManager.characterController.gameObject.transform.position + new Vector3(5, 0, 0);
            portal.Play();
            level01Completed = false;
        }

        public void ActivateMessagePopUp(GameObject obj)
        {
            CMCam_Transition.Priority = 15;
            gameManager.levelManager.PauseGame();
            obj.SetActive(true);
        }

        public void DeactivateMessgePopUp(GameObject obj)
        {
            CMCam_Transition.Priority = 1;
            gameManager.levelManager.ResumeGame();
            obj.SetActive(false);
        }

    }
}