using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginUI : MonoBehaviour
{
    public GameObject signUpPanel;
    public GameObject loginPanel;
    public GameObject errorPanel;
    public GameObject errorMessage;
    public GameObject bankUI;
    
    public TMP_InputField userID;
    public TMP_InputField userPS;

    public TMP_InputField signUpID;
    public TMP_InputField signUpName;
    public TMP_InputField signUpPS;
    public TMP_InputField signUpPSConfirm;

    public void OnClickLoginBtn()
    {
        foreach (var user in GameManager.Instance.allUserData.users)
        {
            if (user.userID == userID.text && user.userPW == userPS.text)//로그인 성공
            {
                GameManager.Instance.currentUserData = user;
                loginPanel.SetActive(false);
                bankUI.SetActive(true);
                return;
            }
        }
        //로그인 실패
        errorMessage.SetActive(true);
    }

    public void OnclickSignUpPanelBtn()//회원가입버튼을 눌렀을때
    {
        signUpPanel.SetActive(true);
    }

    public void OnClickSignUpCancelBtn()//회원가입 취소버튼ㄴ을눌렀을때
    {
        signUpPanel.SetActive(false);
        
    }

    public void OnClickSignUpBtn()//회원가입을 눌렀을때
    {
        if(signUpID==null)return;
        if(signUpName==null)return;
        
        //패스워드와 패스워드 확인이 같다면
        if (signUpPS.text == signUpPSConfirm.text)
        {
            foreach (var user in GameManager.Instance.allUserData.users)
            {
                //이미 아이디가있다면
                if (user.userID == signUpID.text)
                {
                    return;
                }
            }
            //생성
            UserData newUser = new UserData(signUpName.text, 100000,100000,signUpID.text,signUpPS.text);
            //데이터저장
            DataManager.Instance.SaveNewUserData(newUser);
            
        }
        else//아니라면
        {
            //에러창 출력
            errorPanel.SetActive(true);
        }
        
        
    }

    public void OnclickInfoErrorOKBtn()//에러창 OK버튼
    {
        errorPanel.SetActive(false);
    }

}
