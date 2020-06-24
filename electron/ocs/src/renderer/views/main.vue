<style lang="css">
@import "./css/main.css";
@import "./css/demo_styles.css";
@import "./css/demo2.css";
@import "./css/default.css";
</style>

<style lang="less">
  @import "./main.less";
</style>
<template>
  <div class="dm-demo2">
    <button id="createWindowBtn">CreateWindow</button>

    
  </div>
</template>
<script>
  const add = document.querySelector('#createWindowBtn')
  const ipc = require('electron').ipcRenderer
  add.onclick = () => {
    ipc.send('createWindow')
}
  </script>
<script src="http://www.jq22.com/jquery/1.11.1/jquery.min.js"></script>
<script src="./js/plugins.js"></script>
<script src="./js/demo.js"></script>
<script>window.jQuery || document.write('<script src="./js/vendor/jquery-1.10.2.min.js"><\/script>')
</script>
<script lang="ts">
  import { Component, Vue,Inject, Prop,Watch } from 'vue-property-decorator';
  import shrinkableMenu from '../components/shrinkable-menu/shrinkable-menu.vue';
  import tagsPageOpened from '../components/tags-page-opened.vue';
  import breadcrumbNav from '../components/breadcrumb-nav.vue';
  import fullScreen from '../components/fullscreen.vue';
  import lockScreen from '../components/lockscreen/lockscreen.vue';
  import notice from '../components/notices/notice.vue';
  import util from '../lib/util';
  import copyfooter from '../components/Footer.vue'
  import LanguageList from '../components/language-list.vue'
  import AbpBase from '../lib/abpbase'
  @Component({
    components:{shrinkableMenu,tagsPageOpened,breadcrumbNav,fullScreen,lockScreen,notice,copyfooter,LanguageList}
  })
  export default class Main extends AbpBase {
      shrink:boolean=false;
      current:Number=1;
      get userName(){
        return this.$store.state.session.user?this.$store.state.session.user.name:''
      }
      isFullScreen:boolean=false;
      messageCount:string='0';
      greet(){
        this.current=0;
        alert('adsf');
      }
      get openedSubmenuArr(){
        return this.$store.state.app.openedSubmenuArr
      }
      get menuList () {
        return this.$store.state.app.menuList;
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
        let pathArr = util.setCurrentPath(this, this.$route.name as string);
        this.$store.commit('app/updateMenulist');
        if (pathArr.length >= 2) {
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
          this.$store.commit('app/addOpenSubmenu', pathArr[1].name);
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