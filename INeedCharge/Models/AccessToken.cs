namespace INeedCharge.Models
{
    /// <summary>
    /// TDX 的 Access Token
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// 用於存取API服務的token，格式為JWT
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// token的有效期限，單位為秒，預設為86400秒(1天)
        /// </summary>
        public int expires_in { get; set; }
        public int refresh_expires_in { get; set; }
        /// <summary>
        /// token類型，固定為"Bearer"
        /// </summary>
        public string token_type { get; set; }
        public int notbeforepolicy { get; set; }
        public string scope { get; set; }
    }
}
