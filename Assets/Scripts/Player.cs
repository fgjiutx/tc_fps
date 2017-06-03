using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson {
    public class Player : MonoBehaviour {
        CharacterController playerCollider;
        FirstPersonController fps;

        // Use this for initialization
        void Start() {
            playerCollider = GetComponent<CharacterController>();
            fps = GetComponent<FirstPersonController>();
        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Squat();
            }
            if (Input.GetKeyUp(KeyCode.C))
            {
                WasSquat();
            }
        }

        void Squat()
        {
            fps.m_WalkSpeed = 1.0f;
            fps.m_RunstepLenghten = .1f;
            playerCollider.height = .2f;

        }

        void WasSquat()
        {
            fps.m_WalkSpeed = 5.0f;
            fps.m_RunstepLenghten = .7f;
            StartCoroutine(Up(transform.position));
        }
        private IEnumerator Up(Vector3 startVec)
        {
            Vector3 goalVec = startVec + Vector3.up * .7f;
            float t = 0.0f;
            print(t);
            while (t < .9f)
            {
                transform.position= Vector3.Lerp(transform.position, goalVec, t*2);
                playerCollider.height = Mathf.Lerp(playerCollider.height, 1.8f, t);
                t += Time.deltaTime * 2;
                yield return null;
            }
        }
    }
}
