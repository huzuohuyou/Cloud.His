<template>
  <div data-accent="blue">
    <!-- Prompt IE 6 users to install Chrome Frame. Remove this if you support IE 6.
         chromium.org/developers/how-tos/chrome-frame-getting-started -->
    <!--[if lt IE 7]><p class=chromeframe>Your browser is <em>ancient!</em> <a href="http://browsehappy.com/">Upgrade to a different browser</a> or <a href="http://www.google.com/chromeframe/?redirect=true">install Google Chrome Frame</a> to experience this site.</p><![endif]-->
  
     <!-- Header
     ================================================== -->
     <header id="nav-bar" class="container-fluid">
        <div class="row-fluid">
           <div class="span8">
              <div id="header-container">
                 <a id="backbutton" class="win-backbutton" href="./index.html"></a>
                 <h5>BootMetro</h5>
                 <div class="dropdown">
                    <a class="header-dropdown dropdown-toggle accent-color" data-toggle="dropdown" href="#">
                       Start
                       <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                    <li><a href="./hub.html">Hub</a></li>
                    <li><a href="./tiles-templates.html">Tile Templates</a></li>
                    <li><a href="./listviews.html">ListViews</a></li>
                    <li><a href="./appbar-demo.html">Demo App-Bar</a></li>
                    <li><a href="./table.html">Demo Table</a></li>
                    <li><a href="./icons.html">Icons</a></li>
                    <li><a href="./scaffolding.html">Bootstrap Scaffolding</a></li>
                    <li><a href="./base-css.html">Bootstrap Base CSS</a></li>
                    <li><a href="./components.html">Bootstrap Components</a></li>
                    <li><a href="./javascript.html">Bootstrap Javascript</a></li>
                    <li class="divider"></li>
                    <li><a href="./index.html">Home</a></li>
                 </ul>
              </div>
              </div>
           </div>
           <div id="top-info" class="pull-right">
           <a href="#" class="pull-left">
              <div class="top-info-block">
                 <h3>FirstName</h3>
                 <h4>LastName</h4>
              </div>
              <div class="top-info-block">
                 <b class="icon-user"></b>
              </div>
           </a>
           <hr class="separator pull-left"/>
           <a id="settings" class="pull-left" href="#">
              <b class="icon-settings"></b>
           </a>
        </div>
     </div>
     </header>
     
     <div class="container-fluid">
        <div class="row-fluid">
           <div class="metro span12" style="overflow-x: scroll;">
              <div class="metro-sections">
     
                 <div id="section1" class="metro-section tile-span-4">
     
                    <h2>门诊医生站</h2>
     
                    <metroMenuItem v-for="item in items" 
                    :key="item.message" 
                    :menuIcon="item.menuIcon" 
                    :title="item.title"
                    :page="item.page"></metroMenuItem>
                    <!-- <a class="tile app bg-color-blueDark" href="#" @click="modal11 = true">
                      <div class="image-wrapper">
                         <span class="icon icon-IcoMoon" ></span>
                      </div>
                      <span class="app-label">门诊处方</span>
                   </a>
                  
                  
                  <Modal :styles="{background: '#f3f3f3',padding:'0px',}"  footer-hide  v-model="modal11"   fullscreen  >
                     <component :is="currentView"></component>
                     <Prescription></Prescription>
                  </Modal> -->
              
                    <a class="tile app bg-color-blueDark" href="./icons.html">
                      <div class="image-wrapper">
                         <span class="icon icon-cloud-7" ></span>
                      </div>
                      <span class="app-label">Icons</span>
                   </a>
     
                    <a class="tile app wide bg-color-greenDark" href="./table.html">
                       <div class="image-wrapper">
                        <span class="icon icon-dial"></span>
                       </div>
                       <div class="app-label">Styled Table</div>
                    </a>
     
                    <a class="tile app bg-color-purple" href="./listviews.html">
                       <div class="image-wrapper">
                          <span class="icon icon-list-2"></span>
                       </div>
                       <span class="app-label">ListView</span>
                    </a>
     
                    <a class="tile app bg-color-red" href="./charms-demo.html">
                       <div class="image-wrapper">
                          <span class="icon icon-publish"></span>
                       </div>
                       <span class="app-label">[TODO] Charms</span>
                    </a>
     
                    <a class="tile app bg-color-yellow" href="./images.html">
                       <div class="image-wrapper">
                          <span class="icon icon-images"></span>
                       </div>
                       <span class="app-label">[TODO] Images</span>
                    </a>
     
                    <a class="tile app bg-color-blueDark" href="./icons.html">
                       <div class="image-wrapper">
                          <span class="icon   icon-leaf" ></span>
                       </div>
                       <span class="app-label">Icons</span>
                    </a>
     
                 </div>
     
                 <div id="section2" class="metro-section tile-span-4">
     
                    <h2>Bootstrap Metro</h2>
     
                    <a class="tile app bg-color-blueDark" href="./icons.html">
                      <div class="image-wrapper">
                         <span class="icon icon-mail-3" ></span>
                      </div>
                      <span class="app-label">Icons</span>
                   </a>
     
                   <a class="tile app bg-color-blueDark" href="./icons.html">
                    <div class="image-wrapper">
                       <span class="icon  icon-magnifying-glass" ></span>
                    </div>
                    <span class="app-label">Icons</span>
                 </a>
     
                    <a class="tile app bg-color-orange" href="./components.html">
                       <div class="image-wrapper">
                          <img src="content/img/RegEdit.png" alt="" />
                       </div>
                       <span class="app-label">COMPONENTS</span>
                    </a>
     
                    <a class="tile app bg-color-red" href="./javascript.html">
                       <div class="image-wrapper">
                          <img src="content/img/Devices.png" alt="" />
                       </div>
                       <span class="app-label">JAVASCRIPT</span>
                    </a>
     
                 </div>
              </div>
           </div>
        </div>
     </div>
     
     
     <div id="charms" class="win-ui-dark">
     
        <div id="theme-charms-section" class="charms-section">
           <div class="charms-header">
              <a href="#" class="close-charms win-command">
                 <span class="win-commandimage win-commandring">&#xe05d;</span>
              </a>
              <h2>Settings</h2>
           </div>
     
           <div class="row-fluid">
              <div class="span12">
     
                 <form class="">
                    <label for="win-theme-select">Change theme:</label>
                    <select id="win-theme-select" class="">
                       <option value="metro-ui-semilight">Semi-Light</option>
                       <option value="metro-ui-light">Light</option>
                       <option value="metro-ui-dark">Dark</option>
                    </select>
                 </form>
     
              </div>
           </div>
        </div>
     
     </div>
     
     <div class="footer-banner" style="position:fixed;bottom:37px;right:70px;width:728px;"></div>
  
  </div>
 
</template>
<style scoped src="./css2/bootstrap.css"></style>
<style scoped src="./css2/bootstrap-responsive.css"></style>
<style scoped src="./css2/bootmetro.css"></style>
<style scoped src="./css2/bootmetro-tiles.css"></style>
<style scoped src="./css2/bootmetro-charms.css"></style>
<style scoped src="./css2/metro-ui-light.css"></style>
<style scoped src="./css2/icomoon.css"></style>

<style>
  .fades-enter-active, .fades-leave-active {
      transition: opacity 1s
  }
  .fades-enter, .fades-leave-to {
      opacity: 0
  }
  .fades-leave, .fades-enter-to {
    opacity: 1
  }

.ivu-modal-body {
    padding:0px !important;  
    font-size: 12px;
    line-height: 1.5;
}
.ivu-menu-horizontal {
    height: 40px !important;  
    line-height: 40px !important;  
}
</style>

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
  import Prescription from "@/components/outpatient/prescription.vue";
  import metroMenuItem from "@/components/common/metro-menu-item.vue";
  @Component({
    components:{shrinkableMenu,tagsPageOpened,breadcrumbNav,fullScreen,lockScreen,notice,copyfooter,LanguageList,Prescription,metroMenuItem}
  })
  export default class Main extends AbpBase {
      show : boolean= true;
      shrink:boolean=false;
      modal11:boolean=false;
      currentView:String='Prescription';
      items: Array<Object> =[
      { title:'门诊处方12',menuIcon:'icon-list-2',page:'Prescription' ,message: 'Foo' }
    ];
      get userName(){
        return this.$store.state.session.user?this.$store.state.session.user.name:''
      }
      isFullScreen:boolean=false;
      messageCount:string='0';
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
