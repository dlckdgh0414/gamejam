using UnityEngine ;
using UnityEngine.UI ;

public class CaptchaUI : MonoBehaviour
{
   [SerializeField] private Image uiCodeImage;
   [SerializeField] private InputField uiCodeInput;
   [SerializeField] private Text uiErrorsText;
   [SerializeField] private Button uiRefreshButton;
   [SerializeField] private Button uiSubmitButton;

   [SerializeField] private CaptchaGenerator captchaGenerator;
   private Captcha currentCaptcha;

   private void Awake()
    {
        GenerateCaptcha();
        uiRefreshButton.onClick.AddListener(GenerateCaptcha);
        uiSubmitButton.onClick.AddListener(Submit);
   }

   private void GenerateCaptcha()
    {
        currentCaptcha = captchaGenerator.Generate ();
        uiCodeImage.sprite = currentCaptcha.Image;
        uiErrorsText.gameObject.SetActive (false);
   }

    private void Submit()
    {
        string enteredCode = uiCodeInput.text;
        if (captchaGenerator.IsCodeValid(enteredCode, currentCaptcha))
        {
            uiErrorsText.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else uiErrorsText.gameObject.SetActive(true);
    }
}
