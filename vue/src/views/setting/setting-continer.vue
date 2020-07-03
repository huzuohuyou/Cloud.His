<template>
    <div class="continer">
        <div class="group-info flex-style group-info-menu">
            <shrinkable-menu :shrink="shrink" @on-change="handleSubmenuChange" :theme="menuTheme"
                :before-push="beforePush" :open-names="openedSubmenuArr" :menu-list="menuList">
            </shrinkable-menu>
           
        </div>
        <div class="single-page-con" :style="{left: shrink?'80px':'256px'}">
            <div class="single-page">
                <keep-alive :include="cachePage" >
                    <router-view ></router-view>
                </keep-alive>                
            </div>
            <!-- <copyfooter :copyright="L('CopyRight')"></copyfooter> -->
        </div>
      
    </div>
</template>
<script lang="ts">
    import { Component, Vue, Inject, Prop, Watch } from 'vue-property-decorator';
    import util from '@/lib/util';
    import 'viewerjs/dist/viewer.css'
    import StationButton from "@/components/common/icon-on-button-top.vue";
    import OrderButton from "@/components/common/icon-on-button-right.vue";
    import OutpatientInfo from "@/views/outpatient/outpatient-info.vue";
    import SelectPatient from "@/views/outpatient/select-patient.vue";
    import SelectPatient2 from "@/views/outpatient/select-patient2.vue";
    import SelectOrder from "@/components/order/select-order.vue";
    import SelectDiagnosis from "@/components/diagnosis/select-diagnosis.vue";
    import shrinkableMenu from '@/components/shrinkable-menu/shrinkable-menu.vue';
    import AbpBase from '@/lib/abpbase'

    @Component({
        components: {
            StationButton,
            OrderButton,
            OutpatientInfo,
            SelectPatient,
            SelectPatient2,
            SelectOrder,
            SelectDiagnosis,
            shrinkableMenu
        }
    })
    export default class Setting extends AbpBase {
        shrink:boolean=false;
        theme1: String = "primary"
        modal1: Boolean = false;
        get userName(){
        return this.$store.state.session.user?this.$store.state.session.user.name:''
      }
      isFullScreen:boolean=false;
      messageCount:string='0';
      get openedSubmenuArr(){
        return this.$store.state.app.openedSubmenuArr
      }
      get menuList () {
        return this.$store.state.app.subMenuList;
      }
      get pageTagsList () {
        return this.$store.state.app.pageOpenedList as Array<any>;
      }
      get currentPath () {
        return this.$store.state.app.currentPath;
      }
      get lang(){
        return this.$store.state.app.lang;
      }
      get avatorPath () {
        return localStorage.avatorImgPath;
      }
      get cachePage () {
        return this.$store.state.app.cachePage;
      }
      get menuTheme () {
        return this.$store.state.app.menuTheme;
      }
      get mesCount () {
        return this.$store.state.app.messageCount;
      }
      init () {
          console.log(this.$route.name as string)
        let pathArr = util.setCurrentPath(this, this.$route.name as string);
        this.$store.commit('app/updateMenulist','SettingContiner');
        if (pathArr.length >= 2) {
            console.log('app/addOpenSubmenu'+pathArr[1].name)
          this.$store.commit('app/addOpenSubmenu', pathArr[1].name);
        }
        let messageCount = 3;
        this.messageCount = messageCount.toString();
        this.checkTag(this.$route.name);
      }
      toggleClick () {
        this.shrink = !this.shrink;
      }
      handleClickUserDropdown (name:string) {
        if (name === 'ownSpace') {
          util.openNewPage(this, 'ownspace_index',null,null);
          this.$router.push({
            name: 'ownspace_index'
          });
        } else if (name === 'loginout') {
          this.$store.commit('app/logout', this);
          util.abp.auth.clearToken();
          location.reload();
        }
      }
      checkTag (name?:string) {
        let openpageHasTag = this.pageTagsList.some((item:any) => {
          if (item.name === name) {
            return true;
          }else{
            return false
          }
        });
        if (!openpageHasTag) { 
          util.openNewPage(this, name as string, this.$route.params || {}, this.$route.query || {});
        }
      }
      handleSubmenuChange (val:string) {
        // console.log(val)
      }
      beforePush (name:string) {
        if (name === 'accesstest_index') {
          return false;
        } else {
          return true;
        }
      }
      fullscreenChange (isFullScreen:boolean) {
              // console.log(isFullScreen);
      }
      @Watch('$route')
      routeChange(to:any){
        this.$store.commit('app/setCurrentPageName', to.name);
        let pathArr = util.setCurrentPath(this, to.name);
        if (pathArr.length > 2) {
          this.$store.commit('app/addOpenmenu', pathArr[1].name);
        }
        this.checkTag(to.name);
        localStorage.currentPageName = to.name;
      }
      @Watch('lang')
      langChange(){
        util.setCurrentPath(this, this.$route.name as string);
      }
      mounted () {
          this.init();
      }
      created () {
          this.$store.commit('app/setOpenedList');
      }

    }

</script>
<style>
    .continer {
        height: 98%;
        padding: 0px;
        background-color: #2d8cf000;
    }

    .group-info {
        background-color: white;
        border-radius: 10px;
        margin: 0 0 10px;
        padding: 0 10px;
    }

    .group-info-menu {

        padding: 0px;
    }

    .flex-style {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
    }

    .ivu-menu-primary {
        width: 100% !important;
    }
</style>