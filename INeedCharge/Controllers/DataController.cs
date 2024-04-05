using INeedCharge.Services;
using Microsoft.AspNetCore.Mvc;

namespace INeedCharge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController: ControllerBase
    {

        private readonly string TOKEN_URI = $"https://tdx.transportdata.tw/auth/realms/TDXConnect/protocol/openid-connect/token";
        private static readonly string API_PREFIX = $"https://tdx.transportdata.tw/api/basic";

        #region 高速公路充電站(樁)資料 API Uri
        /// <summary>
        /// 取得高速公路所有服務區充電站之充電樁基本資料
        /// </summary>
        private readonly string API_FREEWAY_CHARGINGPOINT_URI = $"{API_PREFIX}/v1/EV/ChargingPoint/Freeway/ServiceArea";
        /// <summary>
        /// "取得高速公路所有服務區充電站之充電槍充電費率資料
        /// </summary>
        private readonly string API_FREEWAY_CHARGINGRATE_URI = $"{API_PREFIX}/v1/EV/ChargingRate/Freeway/ServiceArea";
        /// <summary>
        /// 取得高速公路所有服務區充電站之充電槍基本資料
        /// </summary>
        private readonly string API_FREEWAY_CONNECTOR_URI = $"{API_PREFIX}/v1/EV/Connector/Freeway/ServiceArea";
        /// <summary>
        /// 取得高速公路所有服務區充電站之營運業者資料
        /// </summary>
        private readonly string API_FREEWAY_OPERATOR_URI = $"{API_PREFIX}/v1/EV/Operator/Freeway/ServiceArea";
        /// <summary>
        /// 取得高速公路所有服務區充電站之停車費率資料
        /// </summary>
        private readonly string API_FREEWAY_PARKINGRATE_URI = $"{API_PREFIX}/v1/EV/ParkingRate/Freeway/ServiceArea";
        /// <summary>
        /// 取得高速公路所有服務區充電站之營運時間資料
        /// </summary>
        private readonly string API_FREEWAY_SERVICETIME_URI = $"{API_PREFIX}/v1/EV/ServiceTime/Freeway/ServiceArea";
        /// <summary>
        /// 取得高速公路所有服務區充電站之基本資料
        /// </summary>
        private readonly string API_FREEWAY_STATION_URI = $"{API_PREFIX}/v1/EV/Station/Freeway/ServiceArea";
        /// <summary>
        /// 取得高速公路所有服務區充電站之充電槍即時狀態資料
        /// </summary>
        private readonly string API_FREEWAY_CONNECTORLIVESTATUS_URI = $"{API_PREFIX}/v1/EV/ConnectorLiveStatus/Freeway/ServiceArea";
        #endregion

        public DataController()
        {

        }


        [HttpGet]
        public IActionResult Index()
        {
            ///待處理
            //var accessToken = GetToken(TOKEN_URI).Result;
            //accessToken.access_token;

            //var apiResponse = Get(GetParameters(), API_URI, accessToken.access_token).Result;
            //ViewBag.ApiResponse = apiResponse;

            //return Ok(accessToken);
            return Ok();
        }


        #region 靜態資料
        /// <summary>
        /// 取得一筆營運業者資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetOneOperator))]
        public IActionResult GetOneOperator()
        {
            return Ok(ChargeService.GetOneOpertator());
        }

        /// <summary>
        /// 服務區充電站 下拉清單
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetSelectStationList))]
        public IActionResult GetSelectStationList()
        {
            List<dynamic> selectList = new List<dynamic>
            {
                new { stationID = "33029464-S0303", stationName ="湖口服務區南站" },
                new { stationID = "33029464-S0304", stationName ="湖口服務區北站" },
                new { stationID = "33029464-S0305", stationName ="清水服務區" },
                new { stationID = "33029464-S0306", stationName ="東山服務區" },
                new { stationID = "33029464-S0322", stationName ="關西服務區" },
                new { stationID = "33029464-S0324", stationName ="泰安服務區 南向" },
                new { stationID = "33029464-S0325", stationName ="泰安服務區 北向" },
                new { stationID = "33029464-S0326", stationName ="蘇澳服務區" },
                new { stationID = "33029464-S0327", stationName ="仁德服務區南向" },
                new { stationID = "33029464-S0328", stationName ="仁德服務區北向" },
            };
            return Ok(selectList);
        }

        /// <summary>
        ///  服務區充電站資訊
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetStationList))]
        public IActionResult GetStationList()
        {
            return Ok(ChargeService.GetStationList());
        }
        #endregion
    }
}
