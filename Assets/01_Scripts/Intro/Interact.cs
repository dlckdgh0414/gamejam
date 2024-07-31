    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{ 
    [SerializeField] private GameObject interactText;
    [SerializeField] private List<string> speech;
    bool _isin;
    bool _istalking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isin = true;
            interactText.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isin = false;
            interactText.SetActive(false);
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isin && !_istalking)
        {
            StartCoroutine(talkwith());
        }
    }

    IEnumerator talkwith()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().active = false;
        WaitForSeconds wait = new WaitForSeconds(1);

        ChatManager.instance.OpenChat("연구원");

        yield return new WaitUntil(() => ChatManager.instance.isclosed); ChatManager.instance.isclosed = false;
        yield return wait;
        ChatManager.instance.Type(speech[0],0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;
        ChatManager.instance.OpenChat("AE70");
        ChatManager.instance.Type(speech[1], 0.1f);
        
        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;
        ChatManager.instance.OpenChat("연구원");
        ChatManager.instance.Type(speech[2], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;

        ChatManager.instance.OpenChat("AE70");
        ChatManager.instance.Type(speech[3], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;

        ChatManager.instance.OpenChat("연구원");
        ChatManager.instance.Type(speech[4], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;

        ChatManager.instance.OpenChat("AE70");
        ChatManager.instance.Type(speech[5], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;

        ChatManager.instance.OpenChat("연구원");
        ChatManager.instance.Type(speech[6], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;

        ChatManager.instance.OpenChat("AE70");
        ChatManager.instance.Type(speech[7], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;

        ChatManager.instance.OpenChat("연구원");
        ChatManager.instance.Type(speech[8], 0.1f);

        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;
        yield return wait;
        ChatManager.instance.Type(speech[9], 0.1f);
        yield return new WaitUntil(() => ChatManager.instance.isended); ChatManager.instance.isended = false;

        KeycardManager.instance.getkeycard();
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().active = true;
        yield return wait;
        yield return wait;

        ChatManager.instance.CloseChat();

    }
}
