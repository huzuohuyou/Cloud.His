<template>
  <div id="app">
    <viewer  :images="images"
            @inited="inited"
            class="viewer" ref="viewer"
    >
      <template scope="scope">
        <img v-for="src in scope.images" :src="src" :key="src">
        
      </template>
    </viewer>
    <button type="button" @click="show">Show</button>
  </div>
</template>
<script>
  import 'viewerjs/dist/viewer.css'
  import Viewer from "v-viewer/src/component.vue"
  export default {
    components: {
      Viewer
    },
    data() {
      images: ['1.jpg', '2.jpg']
    },
    methods: {
      inited (viewer) {
        this.$viewer = viewer
      },
      show () {
        this.$viewer.show()
      }
    }
  }
</script>