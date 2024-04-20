namespace INeedCharge.Models.ChargeStation.Station
{
    /// <summary>
    /// 服務區充電站資訊
    /// </summary>
    public class Station
    {
        /// <summary>
        /// 充電站代碼
        /// </summary>
        public string StationID { get; set; }
        /// <summary>
        /// 充電站名稱
        /// </summary>
        public string StationName { get; set; }
        /// <summary>
        /// 充電站服務綜合描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public string OperatorID { get; set; }
        /// <summary>
        /// 營運種類 : [1:'公辦民營',2:'公辦公營',3:'私有民營']
        /// </summary>
        public int OperationType { get; set; }
        /// <summary>
        /// 代表點坐標位置緯度
        /// </summary>
        public float PositionLat { get; set; }
        /// <summary>
        /// 代表點坐標位置經度
        /// </summary>
        public float PositionLon { get; set; }
        /// <summary>
        /// 充電車位數
        /// </summary>
        public int Spaces { get; set; }
        /// <summary>
        /// 充電樁數
        /// </summary>
        public int ChargingPoints { get; set; }
        public Connector[] Connectors { get; set; }
        /// <summary>
        /// 服務時間
        /// </summary>
        public string ServiceTime { get; set; }
        /// <summary>
        /// 充電車位停車費率
        /// </summary>
        public string ParkingRate { get; set; }
        /// <summary>
        /// 充電費率
        /// </summary>
        public string ChargingRate { get; set; }
        /// <summary>
        /// 充電樁所在樓層
        /// </summary>
        public string Floors { get; set; }
        /// <summary>
        /// 充電站使用限制
        /// </summary>
        public string UsageRestriction { get; set; }
        /// <summary>
        /// 充電站照片網址資訊
        /// </summary>
        public object[] PhotoURLs { get; set; }
        /// <summary>
        /// 充電站空間位置資訊
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// 充電站連絡電話
        /// </summary>
        public string Telephone { get; set; }
    }

    public class Location
    {
        public Freeway Freeway { get; set; }
        public Address Address { get; set; }
    }

    public class Freeway
    {
        /// <summary>
        /// 高速公路名稱
        /// </summary>
        public string Road { get; set; }
        /// <summary>
        /// 服務區名稱
        /// </summary>
        public string ServiceArea { get; set; }
    }

    public class Address
    {
        /// <summary>
        /// 縣市名
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 行政區名
        /// </summary>
        public string Town { get; set; }
        /// <summary>
        /// 路名
        /// </summary>
        public string Road { get; set; }
        /// <summary>
        /// 巷名
        /// </summary>
        public string Lane { get; set; }
        /// <summary>
        /// 弄名
        /// </summary>
        public string Alley { get; set; }
        /// <summary>
        /// 號
        /// </summary>
        public string No { get; set; }
    }

    public class Connector
    {
        /// <summary>
        /// 充電槍規格 [1:'CCS1',2:'CCCS2',3:'CHAdeMO',4:'Tesla_TPC',5:'J1772_Type1',6:'Mennekes_Type2',254:'Others',255:'Unknown']
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 充電電力輸出方式  [1:'AC',2:'DC']
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        ///  充電槍數量
        /// </summary>
        public int Quantity { get; set; }
    }

    public class position
    {
        public string StationName { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

}
