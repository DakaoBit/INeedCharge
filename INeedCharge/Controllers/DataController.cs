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
