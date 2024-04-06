<template>
    <section class="section is-medium columns has-background-warning-70" style="height: 525px">
        <div class="column is-four-fifths">
            <h1 class="title has-text-black">國道充電站資訊</h1>
            <h2 class="subtitle has-text-black">
                資料由運輸資料流通服務平臺(Transport Data eXchange , TDX) 提供
            </h2>
        </div>
        <div class="column">
            <div class="dropdown" :class="show.isActive === true ? 'is-active' : ''">
                <div class="dropdown-trigger">
                    <button @click="toggleActive" class="button" aria-haspopup="true" aria-controls="dropdown-menu3">
                        <span>選擇充電站</span>
                        <span class="icon is-large">
                            <i class="fas fa-angle-down" aria-hidden="true"></i>
                        </span>
                    </button>
                </div>
                <div class="dropdown-menu" role="menu">
                    <div class="dropdown-content">
                        <a @click="toggleModel(item.stationID, true)" v-for="item in result.selectStation"
                            :key="item.stationID" class="dropdown-item">
                            {{ item.stationName }}
                        </a>
                    </div>
                </div>
            </div>
        </div>
        <div :class="show.isShowModal === true ? 'is-active' : ''" class="modal">
            <div class="modal-background"></div>
            <div class="modal-card">
                <header class="modal-card-head">
                    <p class="modal-card-title">{{ Station.stationName }}</p>
                    <button @click="toggleModel(null, false)" class="delete" aria-label="close"></button>
                </header>
                <section class="modal-card-body">
                    <div class="content">
                        <h4> 充電站代碼: {{ Station.stationID }}</h4>
                        <h6> 營運種類: {{ Station.operationType }}</h6>
                        <table class="table" style="background-color: hsla(42deg,100%,53%,1);">
                            <thead>
                                <tr>
                                    <th style="color:#000;">充電槍規格</th>
                                    <th style="color:#000;">電力輸出方式</th>
                                    <th style="color:#000;">充電槍數量</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in Connector.list" :key="item.connectorID">
                                    <td style="color:#000;">{{ item.type }}</td>
                                    <td style="color:#000;">{{ item.power }}</td>
                                    <td style="color:#000;">{{ item.quantity }}</td>
                                </tr>
                            </tbody>
                        </table>
                        <table>
                            <thead>
                                <tr>
                                    <th>充電車位數</th>
                                    <th>{{ Station.spaces }}</th>
                                </tr>
                                <tr>
                                    <th>充電樁數</th>
                                    <th>{{ Station.chargingPoints }}</th>
                                </tr>
                                <tr>
                                    <th>充電車位停車費率</th>
                                    <th>{{ Station.parkingRate }}</th>
                                </tr>
                                <tr>
                                    <th>充電費率</th>
                                    <th>{{ Station.chargingRate }}</th>
                                </tr>
                                <tr>
                                    <th>充電站使用限制</th>
                                    <th>{{ Station.usageRestriction }}</th>
                                </tr>
                            </thead>
                        </table>
                        <blockquote>
                            <p>地址: {{ Station.address }}</p>
                            <p>電話: {{ Station.telephone }}</p>
                        </blockquote>
                    </div>
                </section>
                <footer class="modal-card-foot">
                    <div class="buttons">
                        <button @click="toggleModel(null, false)" class="button is-warning">關閉</button>
                    </div>
                </footer>
            </div>
        </div>
    </section>
</template>

<script>
import { getApiUrl, fetchGet } from '../utils/url';
export default {
    component: {
        name: 'Station'
    },
    data() {
        return {
            show: {
                isActive: false,
                isShowModal: false
            },
            api: {
                selectStation: getApiUrl('SelectStation'),
                station: getApiUrl('Station')
            },
            result: {
                station: [],
                selectStation: []
            },
            parameters: {
                stationID: ""
            },
            Station: {
                stationID: "",
                stationName: "",
                operationType: "",
                spaces: "",
                chargingPoints: "",
                parkingRate: "",
                chargingRate: "",
                usageRestriction: "",
                address: "",
                telephone: "",
            },
            OperationType: {
                1: "公辦民營",
                2: "公辦公營",
                3: "私有民營",
            },
            Connector: {
                list: [],
                type: {
                    1: "CCS1",
                    2: "CCS2",
                    3: "CHAdeMO",
                    4: "Tesla",
                    5: "J1772_Type1",
                    6: "Mennekes_Type2",
                    254: "其他",
                    255: "不知"
                },
                power: {
                    1: "AC",
                    2: "DC",
                },
                quantity: 0
            }
        }
    },
    async created() {
        await this.getSelectStation();
    },
    methods: {
        toggleActive() {
            this.show.isActive = !this.show.isActive;
        },
        async toggleModel(id, show) {
            this.show.isShowModal = show;
            if (show === true)
                await this.getStation(id);
            else
            {
                this.Station = {
                    stationID: "",
                    stationName: "",
                    operationType: "",
                    spaces: "",
                    chargingPoints: "",
                    parkingRate: "",
                    chargingRate: "",
                    usageRestriction: "",
                    address: "",
                    telephone: "",
                };
                this.Connector.list = [];
            }
 
        },
        async getSelectStation() {
            const res = await fetchGet(this.api.selectStation);
            this.result.selectStation = res;
            console.log(this.result.selectStation);
        },
        async getStation(id) {
            this.parameters.stationID = id;
            const res = await fetchGet(this.api.station, this.parameters);
            this.Station.stationID = res[0].stationID;
            this.Station.stationName = res[0].stationName;
            this.Station.operationType = this.OperationType[res[0].operationType];
            this.Station.spaces = res[0].spaces;
            this.Station.chargingPoints = res[0].chargingPoints;
            this.Station.parkingRate = res[0].parkingRate;
            this.Station.chargingRate = res[0].chargingRate;
            this.Station.usageRestriction = res[0].usageRestriction;
            this.Station.address = this.arrangeAddress(res[0].location.address);
            this.Station.telephone = res[0].telephone;
            let connectorData = [];
            res[0].connectors.forEach(item => {
                item.type = this.Connector.type[item.type];
                item.power = this.Connector.power[item.power];
                connectorData.push(item);
            });
            this.Connector.list = connectorData;
        },
        arrangeAddress(address) {
            let fullAddress = "";
            if (address.city) {
                fullAddress += address.city;
            }
            if (address.town) {
                fullAddress += address.town;
            }
            if (address.road) {
                fullAddress += address.road;
            }
            if (address.lane) {
                fullAddress += address.lane;
            }
            if (address.alley) {
                fullAddress += address.alley;
            }
            if (address.no) {
                fullAddress += address.no;
            }
            return fullAddress;
        }
    }
}
</script>