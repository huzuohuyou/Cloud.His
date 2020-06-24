<template>
  <div id="app" class="content2" :style="backgroundColor">
    <div class="text-container2">{{title}}</div>
    <div class="img-container2" >
      <img class="img2" :src="imageUrl">
    </div>
    
  </div>
</template>
<script>
  import 'viewerjs/dist/viewer.css'
  import Viewer from 'v-viewer/src/component.vue'
  export default {
    props: {
      backgroundColor: {
        type: Object
      },
      imageUrl: {
        type: String
      },
      title: {
        type: String
      }
    },
    components: {
      Viewer
    },
    data () {
      return {

      }
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
<style>
  .content2 {
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    margin-left: 10px;
    margin-bottom: 10px;
    width: 130px;
    height: 100px;
  }

  .img2 {
    border: none;
    height: 100%;
    width: 100%;
  }

  .img-container2 {
    border: none;
    width: 50%;
    height: 50%;
    margin-top: 20%;
  }

  .text-container2 {
    margin-left: 5%;
    padding: 5px;
    width: 40%;
    height: 40%;
    font-size: 16px;
    margin-top: 17.5%;
    text-align: center;
  }
</style>