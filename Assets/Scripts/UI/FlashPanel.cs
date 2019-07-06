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
    public float fadeTime;
    public string text;
    public int nextClipIndex;
}

public class FlashPanel : MonoBehaviour
{
    [SerializeField]
    GameObject ui_flashPanel;
    [SerializeField]
    SpriteRenderer ui_spriteRenderer;
    [SerializeField]
    Text ui_text;
    [SerializeField]
    GameObject ui_black;
    [SerializeField]
    List<FlashClip> flashClips;

    public static FlashPanel flashMgr;

    private bool m_isFlashing;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                switch (thisClip.type)
                {
                    case CLIP_TYPE.none:
                        break;
                    case CLIP_TYPE.fade_in:
                        break;
                    case CLIP_TYPE.fade_out:
                        break;
                    case CLIP_TYPE.talk:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (thisClip.type)
                {
                    case CLIP_TYPE.none:
                        ui_spriteRenderer.sprite = Sprite.Create(thisClip.texture, ui_spriteRenderer.sprite.textureRect, new Vector2(0.5f, 0.5f)); ;
                        break;
                    case CLIP_TYPE.fade_in:
                        break;
                    case CLIP_TYPE.fade_out:
                        break;
                    case CLIP_TYPE.talk:
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void RefreshTexture(FlashClip clip)
    {
        ui_spriteRenderer.sprite = Sprite.Create(clip.texture, ui_spriteRenderer.sprite.textureRect, new Vector2(0.5f, 0.5f));
    }

    void RefreshBlack(FlashClip clip)
    {
        ui_black.SetActive(clip.type == CLIP_TYPE.talk);
    }

    //IEnumerator FadeIn()
    //{
    //    m_isFlashing = true;
    //}

    //IEnumerator FadeOut()
    //{
    //    m_isFlashing = true;
    //}

    IEnumerator Talk(FlashClip clip)
    {
        m_isFlashing = true;
        foreach (char letter in clip.text.ToCharArray())
        {
            ui_text.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        m_isFlashing = false;
    }
}
