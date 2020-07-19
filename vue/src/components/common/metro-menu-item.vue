<template>
  <a class="tile app bg-color-blueDark" href="#" @click="click">
    <div class="image-wrapper">
      <span :class="['icon',menuIcon]"></span>
    </div>
    <span class="app-label">{{title}}</span>
    <div  v-if="modal11" >
      <Modal :styles="{background: '#f3f3f3',padding:'0px',}"  @on-cancel="cancel" v-model="modal11" fullscreen footer-hide>
        <component :is="currentComponent"></component>
      </Modal>
    </div>
    
  </a>
</template>
<style scoped src="@/statics/css/bootstrap.css"></style>
<style scoped src="@/statics/css/bootstrap-responsive.css"></style>
<style scoped src="@/statics/css/bootmetro.css"></style>
<style scoped src="@/statics/css/bootmetro-tiles.css"></style>
<style scoped src="@/statics/css/bootmetro-charms.css"></style>
<style scoped src="@/statics/css/metro-ui-light.css"></style>
<style scoped src="@/statics/css/icomoon.css"></style>

<style scoped>
  .fades-enter-active,
  .fades-leave-active {
    transition: opacity 1s
  }

  .fades-enter,
  .fades-leave-to {
    opacity: 0
  }

  .fades-leave,
  .fades-enter-to {
    opacity: 1
  }

  .ivu-modal-body {
    padding: 5px !important;
    font-size: 12px;
    line-height: 1.5;
  }

  .ivu-menu-horizontal {
    height: 40px !important;
    line-height: 40px !important;
  }
</style>
<script>

  
  import 'viewerjs/dist/viewer.css'
  import Viewer from "v-viewer/src/component.vue"
  import notImplemented from "@/components/common/not-implemented.vue";
  import SettingContiner from "@/views/setting/setting-continer.vue";
  export default {
    tempComponentUrl1:'@/components/outpatient/prescription.vue',
    props: {
      page: {
        type: String,
      },
      menuIcon: {
        type: String,
      },
      title: {
        type: String,
      },
      componentUrl: {
        type: String,
      },
      componentName: {
        type: String,
      },
     
     
    },
    components: {
      Viewer,
      notImplemented,
      
    },
    data() {
      return {
        
        tempComponentUrl:'@/components/outpatient/prescription.vue',
        currentComponent: '',
        modal11: false,
      };
    },
    methods: {
      click() {
        if (this.page != undefined) {
          this.$store.state.app.currentContiner=this.page;
          this.currentComponent =this.page;
        } else {
          this.currentComponent = 'notImplemented';
        }

        this.modal11 = true;
      },
      inited(viewer) {
        this.$viewer = viewer
      },
      show() {
        this.$viewer.show()
      },
      cancel () {
       console.log( this.modal11)
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