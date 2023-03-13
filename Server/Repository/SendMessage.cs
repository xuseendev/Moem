using Microsoft.AspNetCore.Mvc;
using MoeSystem.Server.Contracts;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace MoeSystem.Server.Repository
{
    public class SendMessage : ISendMessage
    {
        #region Text Message
        public static string MD5Hashs(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        #endregion
        public async Task SendSms(string body, string phone)
        {
            var Rec = VerifyPhone(phone);
            var Cont = body;
            var Dte = DateTime.Now.ToString("dd/MM/yyyy");
            Cont = Cont.Replace(" ", "%20");
            var Key = MD5Hashs("USERNAME_H3vAxjF6|PASSWORD_YXiSA5wt|" + Rec + "|" + Cont + "|AGBC|" + Dte + "|VV6x3EYfH68DmEmt1eUy3zjRmsANmW79");
            Key = Key.ToUpper();
            string uri = $"https://sms.mytelesom.com/index.php/Gateway/sendsms/AGBC/{Cont}/{Rec}/{Key}";
            try
            {
                //ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var httpResponseMessage = await httpClient.PostAsync(new Uri(uri), null);
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                }
            }
            catch (Exception ex)
            {
            }

        }


        public static string VerifyPhone(string phone)
        {
            string phoneNumber = phone;
            if (phone.StartsWith("63") && phone.Length == 9)
            {
                phoneNumber = "0" + phone;
            }
            else if (phone.StartsWith("063") && phone.Length == 10)
            {
                phoneNumber = phone;
            }
            return phoneNumber;
        }
    }
}
