
using System.ComponentModel.DataAnnotations;

namespace INeedCharge.Models.ChargeStation.Operator
{
    public class Operator
    {
        /// <summary>
        /// 營運業者代碼
        /// </summary>
        [Key]
        public string OperatorID { get; set; }
        /// <summary>
        /// 營運業者名稱
        /// </summary>
        public string OperatorName { get; set; }
        /// <summary>
        /// 營運業者電話
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 營運業者地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 營運業者網址
        /// </summary>
        public string WebURL { get; set; }
        /// <summary>
        /// 營運業者Logo網址
        /// </summary>
        public string LogoURL { get; set; }
        /// <summary>
        /// 公司統一編號
        /// </summary>
        public string BAN { get; set; }
    }
}
