using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using YiniCryptLib;

using System.Data.Odbc;
using MicroBSC.Data;

using System.Text;

using System.Web.Security;


using MicroBSC.RolesBasedAthentication;

public partial class BSC_BSC0100S1 : AppPageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //SetPageLayout(phdLayout);
        
        //object OutPut = null;
        //string KEY = "1234567890123456";
        //string IV = "1234567890123456";
        //string InputData = "본 문자열은 SEED/PKCS5/CBC 암호화 후 BASE64 출력 테스트 입니다";

        //YiniCryptLib.Seed seed;
        //seed = new YiniCryptLib.Seed();
        //string InPut = "textBox1.Text";
        //int nRet = seed.ENCRYPT(KEY, IV, InPut, out OutPut);

        //encrypt_test objEncrypt = new encrypt_test();



//        MicroBSC.Integration.ETC.Biz.Biz_Nhis_Hist_Sd bizTest = new MicroBSC.Integration.ETC.Biz.Biz_Nhis_Hist_Sd();

//        bool Result = bizTest.Add_Nhis_Hist_Sd("010-2912-4856", "010-2912-4856", "테스트메시지");


//        Response.Clear();
////        Response.Write(GetEncriptString("aaaa"));
//        Response.Write(Result.ToString());
//        Response.End();        



        //string msg = FormsAuthentication.HashPasswordForStoringInConfigFile("aaaa", "MD5"); // SHA1, MD5 


        //Response.Clear();
        //Response.Write(msg);
        //Response.End();       
    }


    protected string DoConverting(string iStr)
    {
        byte[] plainText = new byte[64];
        byte[] cipherText = new byte[64];

        plainText = System.Text.Encoding.Unicode.GetBytes(iStr.PadRight(8, ' '));
        Encryption objEcy = new Encryption(Encryption.KeySize.Bits128, new byte[64]);
        objEcy.Cipher(plainText, cipherText);
        return (System.Text.Encoding.Unicode.GetString(cipherText));
    }

    private string GetEncriptString(string iStr)
    {
        byte[] plainText = new byte[16];
        byte[] cipherText = new byte[16];

        plainText = Encoding.Unicode.GetBytes(iStr.PadRight(8, ' '));
        Encryption objEcy = new Encryption(Encryption.KeySize.Bits128, new byte[16]);
        objEcy.Cipher(plainText, cipherText);
        return (Encoding.Unicode.GetString(cipherText));
    }
}

public class encrypt_test
{
    public string testFunc()
    {
        //128bit -> 16bytes
        //192bit -> 24bytes
        //256bit -> 32bytes
        MicroBSC.Common.Cryptography objCrypt = new MicroBSC.Common.Cryptography();

        string aaa = MicroBSC.Common.Cryptography.Encrypt("16바이트까지가능", "12345678");


        string bbb = MicroBSC.Common.Cryptography.Decrypt(aaa, "12345678");

        string ccc = GetEncriptString("ccc");


        byte[] outputData = new byte[16];
        byte[] tmpData = new byte[16];
        byte[] byteData = new byte[16];

        string inputStr = "16바이트까지가능";
        string encStr;
        string decStr;

        Encryption objEncrypt = new Encryption(Encryption.KeySize.Bits128, byteData);

        objEncrypt.Cipher(System.Text.Encoding.Default.GetBytes(inputStr), outputData);

        encStr = Convert.ToBase64String(outputData);

        tmpData = Convert.FromBase64String(encStr);

        objEncrypt.InvCipher(tmpData, outputData);

        decStr = System.Text.Encoding.Default.GetString(outputData);

        System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
        strBuilder.Append(string.Format("원문:{0}<br/>", inputStr));
        strBuilder.Append(string.Format("암호화:{0}<br/>", encStr));
        strBuilder.Append(string.Format("복호화:{0}<br/>", decStr));

        return strBuilder.ToString();
    }

    private string GetEncriptString(string iStr)
    {
        byte[] plainText = new byte[16];
        byte[] cipherText = new byte[16];

        plainText = System.Text.Encoding.Unicode.GetBytes(iStr.PadRight(8, ' '));
        Encryption objEcy = new Encryption(Encryption.KeySize.Bits128, new byte[16]);
        objEcy.Cipher(plainText, cipherText);
        return (System.Text.Encoding.Unicode.GetString(cipherText));
    }
}