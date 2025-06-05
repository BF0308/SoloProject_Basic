using TMPro;
using UnityEngine;

public class PasswordInputTMP : MonoBehaviour
{
    public TMP_InputField passwordInputTMP;
    void Start()
    {
        // 입력 시 *** 표시되도록 설정
        passwordInputTMP.contentType = TMP_InputField.ContentType.Password;
        passwordInputTMP.ForceLabelUpdate(); // UI 즉시 반영
    }

}
