namespace INeedCharge.Models.ChargeStation.ChargingPoint
{
    public class ChargingPointList
    {
        public DateTime UpdateTime { get; set; }
        public int UpdateInterval { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public int SrcUpdateInterval { get; set; }
        /// <summary>
        /// 業管機關簡碼
        /// </summary>
        public string AuthorityCode { get; set; }
        public string VersionID { get; set; }
        public int Count { get; set; }
        public Chargingpoint[] ChargingPoints { get; set; }
    }

    /// <summary>
    /// 充電樁資訊
    /// </summary>
    public class Chargingpoint
    {
        /// <summary>
        /// 充電站代碼
        /// </summary>
        public string StationID { get; set; }
        /// <summary>
        /// 充電樁代碼
        /// </summary>
        public string ChargingPointID { get; set; }
        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 充電槍資訊
        /// </summary>
        public Connector[] Connectors { get; set; }
        /// <summary>
        /// 充電費率
        /// </summary>
        public string ChargingRate { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public Payment Payment { get; set; }
        /// <summary>
        /// 啟動充電操作方式
        /// </summary>
        public Starttype StartType { get; set; }
        /// <summary>
        /// 操作方式說明網址
        /// </summary>
        public string OperationURL { get; set; }
        /// <summary>
        /// 充電樁所在樓層
        /// </summary>
        public string Floor { get; set; }
        /// <summary>
        /// 充電樁使用限制
        /// </summary>
        public string UsageRestriction { get; set; }
    }

    /// <summary>
    /// 付款方式
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// 信用卡
        /// </summary>
        public bool CreditCard { get; set; }
        /// <summary>
        /// 電子票證
        /// </summary>
        public bool SmartCard { get; set; }
        /// <summary>
        /// 電子支付
        /// </summary>
        public bool EPay { get; set; }
        /// <summary>
        /// 其他付款方法
        /// </summary>
        public bool Others { get; set; }
    }

    /// <summary>
    /// 啟動方式
    /// </summary>
    public class Starttype
    {
        /// <summary>
        /// 刷卡啟動
        /// </summary>
        public bool ByCard { get; set; }
        /// <summary>
        /// APP啟動
        /// </summary>
        public bool ByApp { get; set; }
        /// <summary>
        /// 管理員啟動
        /// </summary>
        public bool ByStaff { get; set; }
        /// <summary>
        /// 其他啟動方式
        /// </summary>
        public bool Others { get; set; }
    }

    /// <summary>
    /// 充電槍資訊
    /// </summary>
    public class Connector
    {
        /// <summary>
        /// 充電槍規格 1:'CCS1',2:'CCCS2',3:'CHAdeMO',4:'Tesla_TPC',5:'J1772_Type1',6:'Mennekes_Type2',254:'Others',255:'Unknown'
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 充電槍數量
        /// </summary>
        public int Quantity { get; set; }
    }
}
