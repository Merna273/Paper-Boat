using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpecify : MonoBehaviour
{
    [SerializeField] int back;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Back", back);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
