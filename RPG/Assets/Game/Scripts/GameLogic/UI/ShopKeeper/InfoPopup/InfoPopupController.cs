using Game.GameLogic.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoPopupController : MonoBehaviour
{
    public static InfoPopupController Instance;
    [SerializeField] private GameObject content;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private ShopKeeperConfigProvider shopKeeperDescriptionConfigProvider;
    [SerializeField] private TextMeshProUGUI textInfo;

    public void Show(string keeperName)
    {
        var config = shopKeeperDescriptionConfigProvider.GetConfig(keeperName);
        textInfo.text = config.Description;
        UIPanelShop.Instance.ShopExplorer.ShopItemsPath = config.ShopItemsPath;
        content.SetActive(true);
        StartCoroutine(AnimationIn());
    }

    public void OpenUIPanelShop()
    {
        UIPanelShop.Instance.Show();
    }

    public void Hide()
    {
        StartCoroutine(AnimationOut());
    }

    private IEnumerator AnimationIn()
    {
        float timer = 0;
        var scale = content.transform.localScale;

        while (timer < 1)
        {
            scale.x = EasingFunction.EaseInCirc(0.2f, 1, timer);
            scale.y = EasingFunction.EaseInCirc(0.2f, 1, timer);
            content.transform.localScale = scale;
            timer += Time.deltaTime * 3f;
            yield return null;
        }

        scale.x = 1;
        scale.y = 1;
        content.transform.localScale = scale;
    }

    private IEnumerator AnimationOut()
    {
        float timer = 0;
        var scale = content.transform.localScale;

        while (timer < 1)
        {
            scale.x = EasingFunction.EaseInCirc(1f, 0.2f, timer);
            scale.y = EasingFunction.EaseInCirc(1f, 0.2f, timer);
            content.transform.localScale = scale;
            timer += Time.deltaTime * 3f;
            yield return null;
        }

        content.SetActive(false);
    }
}
