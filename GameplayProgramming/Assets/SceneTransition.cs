using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator TransitionAnim;
    public string SceneName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Transition());
    }


    IEnumerator Transition()
    {
        TransitionAnim.Play("Transitionpt3");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync(SceneName);

    }
}
