<template>
  <Headerbar></Headerbar>
  <section class="hero">
    <!-- Rendering the map component -->
    <Map v-if="currentTab === 1"></Map>
    <Station v-if="currentTab === 2">2</Station>
    <h1 v-if="currentTab === 3">3</h1>
  </section>
  <Footer v-model="currentTab"></Footer>
</template>

<script>
import Headerbar from './components/layout/Headerbar.vue'
import Footer from './components/layout/Footer.vue'
import Map from './components/Map.vue'
import Station from './components/Station.vue'

export default {
  name: 'App',
  components: {
    Headerbar,
    Footer,
    Map,
    Station
  },
  data() {
    return {
      currentTab: 1
    }
  }
}
</script>