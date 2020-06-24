<template>
  <div id="app" class="content">
    <div class="img-container" :style="backgroundColor" @click="modal1 = true">
      <img class="img" :src="imageUrl">
    </div>
    <div class="text-container">{{title}}</div>
    
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
      },
      abcClick: {
        type: String
      }
    },
    components: {
      Viewer
    },
    data () {
      return {
        modal1: false
      }
  },
    methods: {
      ok () {
        this.$Message.info('Clicked ok')
      },
      cancel () {
        this.$Message.info('Clicked cancel')
      },
      inited (viewer) {
        this.$viewer = viewer
      },
      show () {
        this.$viewer.show()
      },
      childClick () {
        this.$emit('abcClick')
      }
    }
  }
</script>
<style>
  .content {
    display: flex;
    flex-direction: column;
    flex-wrap: wrap;
    margin-left: 10px;
    margin-bottom: 10px;
    border-radius: 15%;
    width: 100px;
    height: 100px;
    background-color: #f3f3f3;
  }

  .img {
    border: none;
    height: 100%;
    width: 100%;
  }

  .img-container {
    border: none;
    width: 65%;
    height: 65%;
    margin-left: 17.5%;
    border-radius: 15%;
    margin-top: 8%;
  }

  .text-container {
    font-size: 16px;
    margin-top: 3px;
    text-align: center;
  }
</style>