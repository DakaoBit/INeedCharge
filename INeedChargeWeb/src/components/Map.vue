<template>

  <div class="panel-block" style="background-color: #ffdd57;">
    <p class="control has-icons-left">
      <GMapAutocomplete placeholder="搜尋" @place_changed="setPlace" style="font-size: medium" class="input is-warning">
      </GMapAutocomplete>
      <span class="icon is-left">
        <i class="fas fa-search" aria-hidden="true"></i>
      </span>
    </p>
  </div>

  <!-- rendering the map on the page -->
  <GMapMap :center="coords" :zoom="8" map-type-id="terrain" style="width: 100%; height: 450px">
    <GMapMarker v-for="(marker, index) in stationMarker" :key="index" :position="marker.position" :title="marker.stationName"
      :icon="chargeStationIcon" @click="openMarker(marker.stationName)">
      <GMapInfoWindow :opened="openedMarkerID === marker.stationName">
        <iframe width="800" height="500" frameborder="0" style="border:0" referrerpolicy="no-referrer-when-downgrade"
          :src="`https://www.google.com/maps/embed/v1/directions?key=${GOOGLE_MAPS_API_KEY}&origin=${coords.lat},${coords.lng}
  &destination=${marker.stationName}&zoom=8`" allowfullscreen>
        </iframe>
       
      </GMapInfoWindow>
    </GMapMarker>
  </GMapMap>

</template>


<script>
import { onMounted, ref } from 'vue'
import { getApiUrl, fetchGet, fetchPost } from '../utils/url';
import chargeStationIcon from '@/assets/img/ChargeStation.png';
export default {
  name: 'Map',
  setup() {
    // Setting the default coordinates to Taiwan
    const coords = ref({ lat: 22.8625069, lng: 121.8125298 })
    const GOOGLE_MAPS_API_KEY = import.meta.env.VITE_GOOGLE_MAPS_API_KEY
    const api = ref({
      stationPositionList: getApiUrl('GetStationPositionList')
    })

    // Marker Details
    const markerDetails = ref({
      id: 1,
      position: coords.value
    })
    const openedMarkerID = ref(null)
    const stationMarker = ref([])

    // Places Details
    const locationDetails = ref({
      address: '',
      url: ''
    })

    // Get users current location using the browser's geolocation API
    const getUserLocation = () => {
      // Check if Geolocation is supported by the browser
      const isSupported = 'navigator' in window && 'geolocation' in navigator
      if (isSupported) {
        // Retrieve the user's current position
        navigator.geolocation.getCurrentPosition((position) => {
          coords.value.lat = position.coords.latitude
          coords.value.lng = position.coords.longitude
        })
        console.log("user cood:" + coords.value.lat, coords.value.lng)
      }
    }

    // Set the location based on the place selected
    const setPlace = (place) => {
      coords.value.lat = place.geometry.location.lat()
      coords.value.lng = place.geometry.location.lng()
      // console.log("lat: "+place.geometry.location.lat());
      // console.log("lng: "+ place.geometry.location.lng());
      // Update the location details
      locationDetails.value.address = place.formatted_address
      locationDetails.value.url = place.url
    }

    // Open the marker info window
    const openMarker = (name) => {
      openedMarkerID.value = name;
    }

    const getStationPosition = async () => {
      let res = await fetchGet(api.value.stationPositionList);
      let positionList = res.position.map(function (item) {
        return {
          stationName: item.stationName,
          position: {
            lat: item.lat,
            lng: item.lng
          }
        };
      });
      stationMarker.value = positionList;
    }
 

    onMounted(() => {
      getUserLocation(),
        getStationPosition()
    })

    return {
      coords,
      markerDetails,
      openedMarkerID,
      openMarker,
      getUserLocation,
      setPlace,
      locationDetails,
      stationMarker,
      getStationPosition,
      chargeStationIcon,
      GOOGLE_MAPS_API_KEY
    }
  }
}
</script>
<!-- <style scoped>
.location-details {
  color: black;
  font-size: 12px;
  font-weight: 500;
}
</style> -->
