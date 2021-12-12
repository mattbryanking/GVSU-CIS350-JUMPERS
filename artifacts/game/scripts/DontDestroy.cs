using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    void Awake() {
        int scene;
        scene = SceneManager.GetActiveScene().buildIndex;

        // if music is havok, only keeps it alive for appropriate stages
        if (gameObject.name == "HHavokMusic") {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("hhavok");

            // prevents duplicates
            if(objs.Length > 1) {
                Destroy(this.gameObject);
            }
            if (scene == 7) {
                Destroy(this.gameObject);
            }

            // carries music between scenes
            DontDestroyOnLoad(this.gameObject);
        }

        // if music is come, only keeps it alive for appropriate stages
        if (gameObject.name == "ComeMusic") {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("come");

            // prevents duplicates
            if(objs.Length > 1) {
                Destroy(this.gameObject);
            }
            if (scene == 7) {
                Destroy(this.gameObject);
            }

            // carries music between scenes
            DontDestroyOnLoad(this.gameObject);
        }

        // if music is arpanauts, only keeps it alive for appropriate stages
        if (gameObject.name == "Arpanauts") {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("arp");

            // prevents duplicates
            if(objs.Length > 1) {
                Destroy(this.gameObject);
            }
            if (scene > 9) {
                Destroy(this.gameObject);
            }

            // carries music between scenes
            DontDestroyOnLoad(this.gameObject);
        }

    void Update() {
        int scene;
        scene = SceneManager.GetActiveScene().buildIndex;
        
        // prevents all non-menu music on menu scene
        if (scene == 0) {
            Destroy(this.gameObject);
        }

        // destroys come music on inappropriate scenes
        if (gameObject.name == "ComeMusic") {
            if (scene > 3 || scene < 1) {
                Destroy(this.gameObject);
            }
        }

        // destroys havok music on inappropriate scenes
        if (gameObject.name == "HHavokMusic") {
            if (scene > 6 || scene < 4) {
                Destroy(this.gameObject);
            }
        }

        // destroys arpanauts music on inappropriate scenes
        if (gameObject.name == "Arpanauts") {
            if (scene > 9 || scene < 7) {
                Destroy(this.gameObject);
            }
        }
    }
        
    }
}
