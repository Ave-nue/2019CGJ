using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CLIP_TYPE
{
    none = 0,
    fade_in,
    fade_out,
    talk,
}

public enum FLASH_STATE
{
    none = 0,
    fade_in,
    fade_out,
    talking,
}

[System.Serializable]
public struct FlashClip
{
    public string name;
    public CLIP_TYPE type;
    public bool needRefresh;
    public Texture2D texture;
    public string text;
    public int nextClipIndex;
}

public class FlashPanel : MonoBehaviour
{
    [SerializeField]
    GameObject ui_flashPanel;
    [SerializeField]
    Image ui_image;
    [SerializeField]
    Text ui_text;
    [SerializeField]
    GameObject ui_black;
    [SerializeField]
    List<FlashClip> flashClips;

    public static FlashPanel flashMgr;

    private bool m_isFlashing;
    private int m_nextIndex;

    private void Awake()
    {
        if (flashMgr)
            Destroy(gameObject);
        else
            flashMgr = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_isFlashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_isFlashing)
                m_isFlashing = false;
            else
                PlayFlash(m_nextIndex);
        }
    }

    public void PlayFlash(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= flashClips.Count)
        {
            ui_flashPanel.SetActive(false);
            return;
        }
        else
        {
            FlashClip thisClip = flashClips[clipIndex];
            if (thisClip.needRefresh)
            {
                RefreshTexture(thisClip);
                RefreshBlack(thisClip);
                RefreshTalkTxt();
            }
            switch (thisClip.type)
            {
                case CLIP_TYPE.none:
                    RefreshTexture(thisClip);
                    break;
                case CLIP_TYPE.fade_in:
                    StartCoroutine(FadeIn(thisClip));
                    break;
                case CLIP_TYPE.fade_out:
                    StartCoroutine(FadeOut(thisClip));
                    break;
                case CLIP_TYPE.talk:
                    RefreshBlack(thisClip);
                    RefreshTalkTxt();
                    StartCoroutine(Talk(thisClip));
                    break;
                default:
                    break;
            }

            m_nextIndex = thisClip.nextClipIndex;
        }
    }

    void RefreshTexture(FlashClip clip)
    {
        m_isFlashing = true;
        ui_image.sprite = Sprite.Create(clip.texture, ui_image.sprite.textureRect, new Vector2(0.5f, 0.5f));
        m_isFlashing = false;
    }

    void RefreshBlack(FlashClip clip)
    {
        m_isFlashing = true;
        ui_black.SetActive(clip.type == CLIP_TYPE.talk);
        m_isFlashing = false;
    }

    void RefreshTalkTxt()
    {
        ui_text.text = "";
    }

    IEnumerator FadeIn(FlashClip clip)
    {
        m_isFlashing = true;
        Rect canvasRect = GetComponent<RectTransform>().rect;
        Vector3 fadePos = new Vector3(canvasRect.width / 2, -canvasRect.height / 2, 0);
        Vector3 centerPos = new Vector3(canvasRect.width / 2, canvasRect.height / 2, 0);
        ui_image.transform.SetPositionAndRotation(fadePos, Quaternion.identity);
        while (ui_image.transform.position.y < centerPos.y)
        {
            if (m_isFlashing == false)
            {
                ui_image.transform.SetPositionAndRotation(centerPos, Quaternion.identity);
                break;
            }

            ui_image.transform.Translate(Vector3.up * 3f);
            if (ui_image.transform.position.y >= centerPos.y)
                ui_image.transform.SetPositionAndRotation(centerPos, Quaternion.identity);
            yield return 0;
        }
    }

    IEnumerator FadeOut(FlashClip clip)
    {
        m_isFlashing = true;
        Rect canvasRect = GetComponent<RectTransform>().rect;
        Vector3 fadePos = new Vector3(canvasRect.width / 2, -canvasRect.height / 2, 0);
        Vector3 centerPos = new Vector3(canvasRect.width / 2, canvasRect.height / 2, 0);
        ui_image.transform.SetPositionAndRotation(centerPos, Quaternion.identity);
        while (ui_image.transform.position.y > fadePos.y)
        {
            if (m_isFlashing == false)
            {
                ui_image.transform.SetPositionAndRotation(fadePos, Quaternion.identity);
                break;
            }

            ui_image.transform.Translate(Vector3.down * 3f);
            if (ui_image.transform.position.y <= fadePos.y)
                ui_image.transform.SetPositionAndRotation(fadePos, Quaternion.identity);
            yield return 0;
        }
    }

    IEnumerator Talk(FlashClip clip)
    {
        m_isFlashing = true;
        foreach (char letter in clip.text.ToCharArray())
        {
            if (m_isFlashing == false)
            {
                ui_text.text = clip.text;
                break;
            }

            ui_text.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
