using System.Text.Json;
using INeedCharge.DB;
using INeedCharge.Models.ChargeStation.Operator;
using INeedCharge.Models.ChargeStation.Station;

namespace INeedCharge.Services
{
    public class ChargeService
    {
        /// <summary>
        /// 取得一筆營運業者
        /// </summary>
        /// <returns></returns>
        public static Operator GetOneOpertator()
        {
            using (var context = new ApplicationDBContext())
            {
                Operator icharge = new Operator()
                {
                    OperatorID = "33029464",
                    OperatorName = "中興電工機械股份有限公司",
                    Telephone = "02-26551518",
                    Address = "臺北市南港區三重路19之5號2樓",
                    WebURL = "https://www.icharging.com.tw/tw",
                    LogoURL = "https://www.icharging.com.tw/upload/admin/202210221638450.svg",
                    BAN = "33029464"
                };

                var data = context.Operators.Where(x => x.OperatorID == icharge.OperatorID).FirstOrDefault();

                if (data is null)
                {
                    context.Operators.Add(icharge);
                    context.SaveChanges();
                    return icharge;
                }
                else
                {
                    return data;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Station> GetStationList()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Jsons/Stations.json");

            if (!File.Exists(filePath))
                return null;

            string json = File.ReadAllText(filePath);
            var deserializedData = JsonSerializer.Deserialize<Dictionary<string, List<Station>>>(json);
            List<Station> stations = deserializedData["Stations"];

            return stations.ToList();
        }
    }
}
